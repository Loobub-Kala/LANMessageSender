using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LANMessageServer
{
    public partial class FormServer : Form
    {
        // 申明变量
        private TcpListener tcpListen = null;
        private TcpMember[] tcpMembers = new TcpMember[10];
        private Boolean[] isUsed = new Boolean[10];
        private Int32 tcpNum = 0;
        
        
        public FormServer()
        {
            InitializeComponent();
            //工具栏无法获得焦点
            //toolStripTextBoxIP.Focus();
            Control.CheckForIllegalCrossThreadCalls = false;
            for (int i = 0; i < 10; i++)
                tcpMembers[i] = new TcpMember();
        }

        private void toolStripTextBoxIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //不为数字，不为‘.’，不为退格键，则输入无效
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)46 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void toolStripButtonListen_Click(object sender, EventArgs e)
        {

            IPAddress ipAddress = IPAddress.Parse(toolStripTextBoxIP.Text);
            Int32 port = Int32.Parse("888");

            if (toolStripButtonListen.Text == "启动")
            {
                try
                {
                    //通过线程发起请求，多线程
                    tcpListen = new TcpListener(ipAddress, port);
                    tcpListen.Start();

                    // 启动一个线程来接受请求
                    Thread acceptThread = new Thread(new ThreadStart(AcceptClientConnect));
                    acceptThread.Start();

                    toolStripButtonListen.Text = "等待连接";
                    toolStripButtonListen.ToolTipText = "等待连接";
                    toolStripButtonListen.Image = Properties.Resources.等待_16_;
                    MessageBox.Show("启动成功了\\(≧▽≦)/");
                }
                catch
                {
                    MessageBox.Show("启动不了，请仔细检查一下错误吧〒▽〒");
                }
            }
        }

        // 接受请求
        private void AcceptClientConnect()
        {
            toolStripButtonListen.Text = "启动监听";
            toolStripButtonListen.ToolTipText = "启动监听";
            Thread.Sleep(300);
            try
            {
                // 启动一个线程来一直接受连接
                Thread listenThread = new Thread(new ThreadStart(ListenMonitor));
                listenThread.Start();
            }
            catch
            {
                toolStripButtonListen.Text = "停止监听";
                toolStripButtonListen.ToolTipText = "停止监听";
                Thread.Sleep(300);
                toolStripButtonListen.Text = "就绪";
                toolStripButtonListen.ToolTipText = "就绪";
            }
        }

        //监听，一直
        private void ListenMonitor()
        {
            int i;
            while (true)
            {
                if(tcpNum<10)
                {
                    for (i=0;i<10; i++)
                    {
                        if (!isUsed[i])
                        {
                            tcpMembers[i].tcpClient = tcpListen.AcceptTcpClient();
                            tcpMembers[i].state = true;
                            tcpMembers[i].networkStream= tcpMembers[i].tcpClient.GetStream();
                            tcpMembers[i].reader = new BinaryReader(tcpMembers[i].networkStream);
                            tcpMembers[i].writer = new BinaryWriter(tcpMembers[i].networkStream);
                            //TcpNumChange(1);
                            isUsed[i] = true;
                            Thread threadread = new Thread(new ParameterizedThreadStart(ReceiveMessage));
                            threadread.Start(i);
                            //MessageBox.Show("g   tcpnum=" + tcpNum + "  i=" + i);
                        }
                    }
                }
            }
        }

        // 接收消息
        private void ReceiveMessage(Object Data)
        {
            int i = int.Parse(Data.ToString());
            String str = null;
            try
            {
                while (tcpMembers[i].reader != null)
                {
                    String receivemessage = tcpMembers[i].reader.ReadString();
                    String[] sArray = receivemessage.Split(new Char[] { ' ' }, 3, StringSplitOptions.RemoveEmptyEntries);
                    if (sArray[0] == "'")
                    {
                        //添加时间
                        richChatContent.SelectionColor = Color.Orange;
                        richChatContent.AppendText(" " + DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss") + Environment.NewLine);

                        //添加内容
                        richChatContent.SelectionColor = SystemColors.WindowText;
                        richChatContent.AppendText(sArray[1] + ":" + sArray[2] + Environment.NewLine);

                        //发送给各个客户端
                        Thread sendThread = new Thread(new ParameterizedThreadStart(SendMessage));
                        str = "-1_` " + sArray[1] + " " + sArray[2];
                        sendThread.Start(str);
                        //SendMessage("` " + sArray[1] + " " + sArray[2],-1);
                    }
                    else if (sArray[0] == "~")
                    {
                        if (sArray[1] == "Authentication")
                        {
                            //以下是名字,验证名字是否重复
                            if (tcpNum < 10)
                            {
                                Boolean isOK = false;
                                for (int j = 0; j < 10; j++)
                                {
                                    if (isUsed[j] && String.Compare(tcpMembers[j].name, sArray[2]) == 0)
                                    {
                                        isOK = true;
                                        //发送给某个客户端
                                        Thread sendThread = new Thread(new ParameterizedThreadStart(SendMessage));
                                        str = i + "_~ AuthenticationRepeat";
                                        sendThread.Start(str);
                                    }
                                }
                                if (!isOK)
                                {
                                    TcpNumChange(1);
                                    Thread sendThread = new Thread(new ParameterizedThreadStart(SendMessage));
                                    str = i + "_~ AuthenticationOk";
                                    sendThread.Start(str);
                                    tcpMembers[i].name = sArray[2];
                                    //Thread sendThread = new Thread(new ParameterizedThreadStart(SendMessage));
                                    Thread sendThread1 = new Thread(new ParameterizedThreadStart(SendMessage));
                                    str = "-1_` 服务器 " + sArray[2] + "加入了聊天室";
                                    sendThread1.Start(str);

                                    //添加时间
                                    richChatContent.SelectionColor = Color.Orange;
                                    richChatContent.AppendText(" " + DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss") + Environment.NewLine);

                                    //添加内容
                                    richChatContent.SelectionColor = SystemColors.WindowText;
                                    richChatContent.AppendText("服务器通知:" + sArray[2] + "加入了聊天室" + Environment.NewLine);

                                }
                            }
                            else
                            {
                                Thread sendThread = new Thread(new ParameterizedThreadStart(SendMessage));
                                str = i + "_~ AuthenticationFull";
                                sendThread.Start(str);
                            }
                        }
                        else if (sArray[1] == "DeleteTcp")
                        {
                            if(String.Compare(tcpMembers[i].name,sArray[2])==0)
                            {
                                tcpMembers[i].state = false;
                                tcpMembers[i].networkStream = null;
                                tcpMembers[i].reader.Close();
                                tcpMembers[i].writer.Close();
                                tcpMembers[i].tcpClient.Close();
                                TcpNumChange(-1);
                                isUsed[i] = false;
                                
                                Thread sendThread1 = new Thread(new ParameterizedThreadStart(SendMessage));
                                str = "-1_` 服务器 " + sArray[2] + "离开了聊天室";
                                sendThread1.Start(str);

                                //添加时间
                                richChatContent.SelectionColor = Color.Orange;
                                richChatContent.AppendText(" " + DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss") + Environment.NewLine);

                                //添加内容
                                richChatContent.SelectionColor = SystemColors.WindowText;
                                richChatContent.AppendText("服务器通知:" + sArray[2] + "离开了聊天室" + Environment.NewLine);

                                break;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("3系统错误，请再试一次吧〒▽〒" + "\n" + ex.Message);
            }
        }
        
        private void SendMessage(Object data)
        {
            //为-1则为聊天室消息，否则为认证消息
            String[] str = data.ToString().Split(new Char[] { '_' }, 2, StringSplitOptions.RemoveEmptyEntries);
            String s = str[1];
            int n = int.Parse(str[0]);
            try
            {
                if (n == -1)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (isUsed[i])
                        {
                            tcpMembers[i].writer.Write(s);
                            tcpMembers[i].writer.Flush();
                        }
                    }
                }
                else
                {
                    tcpMembers[n].writer.Write(s);
                    tcpMembers[n].writer.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("4系统错误，请再试一次吧〒▽〒" + "\n" + ex.Message);
            }
        }

        public void TcpNumChange(int i)
        {
            tcpNum += i;
            toolStripTextBoxNum.Text = tcpNum.ToString();
            if (tcpNum > 0 && tcpNum < 10)
            {
                toolStripButtonListen.Text = "已连接";
                toolStripButtonListen.ToolTipText = "已连接";
                toolStripButtonListen.Image = Properties.Resources.已连接_16_;
            }
            else if (tcpNum == 0)
            {
                toolStripButtonListen.Text = "等待连接";
                toolStripButtonListen.ToolTipText = "等待连接";
                toolStripButtonListen.Image = Properties.Resources.等待_16_;
            }
            else if (tcpNum == 10)
            {
                toolStripButtonListen.Text = "连接已满";
                toolStripButtonListen.ToolTipText = "连接已满";
                toolStripButtonListen.Image = Properties.Resources.连接已满_16_;

            }
            else
            {
                toolStripButtonListen.Text = "连接出错";
                toolStripButtonListen.ToolTipText = "连接出错";
                toolStripButtonListen.Image = Properties.Resources.连接错误_16_;
            }
        }

        private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
