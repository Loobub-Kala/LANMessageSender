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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LANMessageSender
{
    public partial class FormLogin : Form
    {
        // 申明变量
        private TcpClient tcpClient = null;
        private NetworkStream networkStream = null;
        private BinaryReader reader;
        private BinaryWriter writer;

        public static FormLogin formLogin = null;
        private String myName = null;

        private String errorMessage = null;
        //取名是否合法
        private Boolean isValidate = false;
        //是否有效
        private Boolean isValid = true;

        public FormLogin()
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;
            formLogin = this;
            textName.Focus();
        }
        
        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char Key_Char = e.KeyChar;//判斷按鍵的 Keychar 
            //MessageBox.Show(((int)(Key_Char)).ToString());//轉成整數顯示
            
            //不为数字，不为‘.’，不为退格键，则输入无效
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)46 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textName_Validating(object sender, CancelEventArgs e)
        {
            //只含有汉字、数字、字母、下划线，下划线位置不限的1-16位字符的正则表达式
            //^[ a-z A-Z 0-9 _ \u4e00-\u9fa5 ]{1,16}$
            Regex rg = new Regex("^[a-zA-Z0-9_\u4e00-\u9fa5]{1,16}$");
            //MessageBox.Show("Length ="+ textName.Text.Length+ "  bool ="+ rg.IsMatch(textName.Text));
            if (rg.IsMatch(textName.Text))
            {
                errorMessage = "您输入的名字合法\\(≧▽≦)/";
                pictureName.Image = Properties.Resources.正确_32_;
                isValidate = true;
            }
            else if (textName.Text.Length == 0)
            {
                errorMessage = "名字不能为空哦，请重新输入<(－︿－)>";
                pictureName.Image = Properties.Resources.错误_32_;
                textName.Select(0, textName.Text.Length);
                isValidate = false;
            }
            else if (textName.Text.Length >= 17)
            {
                errorMessage = "您输入的名字长度太长了，请重新输入<(－︿－)>";
                pictureName.Image = Properties.Resources.错误_32_;
                textName.Select(0, textName.Text.Length);
                isValidate = false;
            }
            else if (!rg.IsMatch(textName.Text))
            {
                errorMessage = "您输入的名字非法诶，请重新输入<(－︿－)>";
                pictureName.Image = Properties.Resources.错误_32_;
                textName.Select(0, textName.Text.Length);
                isValidate = false;
            }
        }

        private void textName_Validated(object sender, EventArgs e)
        {
            labelError.Text = errorMessage;
        }

        private void buttonEntry_Click(object sender, EventArgs e)
        {
            if(isValidate)
            {
                //测试用
                /*toolStripButton1.Image = Properties.Resources.连接正常_32_;
                pictureName.Image = Properties.Resources.正确_32_;
                labelError.Text = "欢迎~";
                myName = textName.Text;
                isValidate = false;

                //休眠一秒
                Thread.Sleep(1);
                
                FormChat formChat = new FormChat();
                formChat.Show();
                this.Hide();*/

                try
                {
                    //通过线程发起请求，多线程
                    Thread connectThread = new Thread(ConnectToServer);
                    connectThread.Start();
                }
                catch
                {
                    MessageBox.Show("出错了，请仔细检查一下错误吧〒▽〒");
                }
            }
        }

        //连接服务器
        private void ConnectToServer()
        {
            try
            {
                while(toolStripTextBoxIP.Text == String.Empty)
                {
                    MessageBox.Show("您的服务器的IP地址没写吧(⊙_⊙)?");
                }
                IPAddress ipAddress = IPAddress.Parse(toolStripTextBoxIP.Text);
                Int32 port = Int32.Parse("888");
                tcpClient = new TcpClient();
                tcpClient.Connect(ipAddress, port);
                // 延时操作
                Thread.Sleep(300);

                //服务器已连上后
                if (tcpClient != null)
                {
                    //MessageBox.Show("c1");
                    networkStream = tcpClient.GetStream();
                    reader = new BinaryReader(networkStream);
                    writer = new BinaryWriter(networkStream);
                    

                    //MessageBox.Show("c2---write");
                    writer.Write("~ Authentication " + textName.Text);
                    writer.Flush();

                    //MessageBox.Show("c3--r1");
                    //启动接受消息的子线程
                    Thread receiveThread = new Thread(ReceiveMessage);
                    receiveThread.Start();

                    //MessageBox.Show("c4");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("1系统错误，请再试一次吧〒▽〒" + "\n" + ex.Message);
            }
        }

        // 接收消息
        private void ReceiveMessage()
        {
            try
            {
                while (isValid&&reader != null)
                {
                    //MessageBox.Show("1");
                    String receivemessage = reader.ReadString();
                    //String[] sArray = receivemessage.Split(new Char[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
                    if (receivemessage == "~ AuthenticationOk")
                    {
                        toolStripButton1.Image = Properties.Resources.连接正常_32_;
                        pictureName.Image = Properties.Resources.正确_32_;
                        errorMessage = "欢迎~";
                        myName = textName.Text;
                        //labelError.Text = errorMessage;
                        labelError.Invoke(new EventHandler(delegate
                        {
                            labelError.Text = errorMessage;
                        }));
                        isValidate = false;
                        
                        FormChat formChat = new FormChat();
                        //休眠一秒
                        //Thread.Sleep(100);
                        formLogin.Invoke(new EventHandler(delegate
                        {
                            //MessageBox.Show("我要藏了啊");
                            formLogin.Hide();
                        }));
                        formChat.ShowDialog();

                        //除非关闭子窗口，否则不向下运行，即关闭子窗口则关闭父窗口

                        isValid = false;

                    }
                    else if (receivemessage == "~ AuthenticationRepeat")
                    {
                        errorMessage = "您输入的名字有重复，请重新输入<(－︿－)>";
                        labelError.Invoke(new EventHandler(delegate
                        {
                            labelError.Text = errorMessage;
                        }));
                        toolStripButton1.Image = Properties.Resources.连接异常_32_;
                        pictureName.Image = Properties.Resources.问题_32_;
                        //textName.Select(0, textName.Text.Length);
                        isValidate = false;
                    }
                    else if (receivemessage == "~ AuthenticationFull")
                    {
                        errorMessage = "聊天室满了〒▽〒";
                        labelError.Invoke(new EventHandler(delegate
                        {
                            labelError.Text = errorMessage;
                        }));
                        toolStripButton1.Image = Properties.Resources.连接异常_32_;
                        pictureName.Image = Properties.Resources.问题_32_;
                        //textName.Select(0, textName.Text.Length);
                        isValidate = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("2系统错误，请再试一次吧〒▽〒" + "\n" + ex.Message);
            }
            if (reader != null)
            {
                reader.Close();
            }
            if (writer != null)
            {
                writer.Close();
            }
            // 断开连接
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
            formLogin.Invoke(new EventHandler(delegate
            {
                //formLogin.Close();
            }));
        }

        public TcpClient Get_tcpClient
        {
            get { return formLogin.tcpClient; }
        }
        public String Get_myName
        {
            get { return formLogin.myName; }
        }

        /*public NetworkStream Get_networkStream()
        {
            return networkStream;
        }
        public void Set_networkStream(NetworkStream stream)
        {
            networkStream = stream;
        }*/
    }
}
