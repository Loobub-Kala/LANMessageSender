using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LANMessageSender
{
    public partial class FormChat : Form
    {
        // 申明变量
        private TcpClient tcpClient = null;
        private NetworkStream networkStream = null;
        private BinaryReader reader;
        private BinaryWriter writer;

        //初始状态
        //字体：宋，黑，楷
        private String isFont = "宋体";
        //字体大小：9为小号(小五)，15为中号(小三)，24为大号(小一)
        private Int32 isTt = 9;
        //是否斜体
        private Boolean isItalic = false;
        //是否粗体
        private Boolean isBold = false;
        //是否有效
        //private Boolean isValid = true;

        public FormChat()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            richSendContent.Focus();
        }

        private void richSendContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            //回车键则调用
            if (e.KeyChar == (char)13)
            {
                if (richSendContent.Text != String.Empty)
                {
                    richSendContent.Text = richSendContent.Text.Remove(richSendContent.Text.Length - 1);
                    SendMessage();
                }
            }
        }

        private void FormChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            //isValid = false;
            DeleteTcp();
            FormLogin.formLogin.Show();
            this.Dispose();
        }

        private void 宋体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isFont = "宋体";
            宋体ToolStripMenuItem.Enabled = false;
            黑体ToolStripMenuItem.Enabled = true;
            楷体ToolStripMenuItem.Enabled = true;
            newShow();
        }

        private void 黑体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isFont = "黑体";
            宋体ToolStripMenuItem.Enabled = true;
            黑体ToolStripMenuItem.Enabled = false;
            楷体ToolStripMenuItem.Enabled = true;
            newShow();
        }

        private void 楷体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isFont = "楷体";
            宋体ToolStripMenuItem.Enabled = true;
            黑体ToolStripMenuItem.Enabled = true;
            楷体ToolStripMenuItem.Enabled = false;
            newShow();
        }

        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            isItalic = !isItalic;
            if(isItalic)
            {
                toolStripButtonItalic.BackColor = SystemColors.ControlDark;
            }
            else
            {
                toolStripButtonItalic.BackColor = SystemColors.Control;
            }
            newShow();
        }

        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
            isBold = !isBold;
            if (isBold)
            {
                toolStripButtonBold.BackColor = SystemColors.ControlDark;
            }
            else
            {
                toolStripButtonBold.BackColor = SystemColors.Control;
            }
            newShow();
        }

        private void 小号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isTt = 9;
            小号ToolStripMenuItem.Enabled = false;
            中号ToolStripMenuItem.Enabled = true;
            大号ToolStripMenuItem.Enabled = true;
            newShow();
        }

        private void 中号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isTt = 15;
            小号ToolStripMenuItem.Enabled = true;
            中号ToolStripMenuItem.Enabled = false;
            大号ToolStripMenuItem.Enabled = true;
            newShow();
        }

        private void 大号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isTt = 24;
            小号ToolStripMenuItem.Enabled = true;
            中号ToolStripMenuItem.Enabled = true;
            大号ToolStripMenuItem.Enabled = false;
            newShow();
        }

        private void newShow()
        {
            if (isItalic && isBold)
            {
                richChatContent.SelectionFont = new Font(isFont, isTt, FontStyle.Italic | FontStyle.Bold);
                richSendContent.Font = new Font(isFont, isTt, FontStyle.Italic | FontStyle.Bold);
            }
            else if (isItalic && !isBold)
            {
                richChatContent.SelectionFont = new Font(isFont, isTt, FontStyle.Italic);
                richSendContent.Font = new Font(isFont, isTt, FontStyle.Italic);
            }
            else if (!isItalic && isBold)
            {
                richChatContent.SelectionFont = new Font(isFont, isTt, FontStyle.Bold);
                richSendContent.Font = new Font(isFont, isTt, FontStyle.Bold);
            }
            else
            {
                richChatContent.SelectionFont = new Font(isFont, isTt, FontStyle.Regular);
                richSendContent.Font = new Font(isFont, isTt, FontStyle.Regular);
            }
            
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (richSendContent.Text != String.Empty)
                SendMessage();
        }

        // 清空消息
        private void ResetMessage()
        {
            richSendContent.Clear();
            richSendContent.Focus();
        }

        // 接收消息
        private void ReceiveMessage()
        {
            try
            {
                while (reader != null)
                {
                    String receivemessage = reader.ReadString();
                    String[] sArray = receivemessage.Split(new Char[] { ' ' }, 3, StringSplitOptions.RemoveEmptyEntries);
                    if (sArray[0] == "`")
                    {
                        //添加时间
                        richChatContent.Invoke(new EventHandler(delegate
                        {
                            richChatContent.SelectionColor = Color.Orange;
                            newShow();
                            richChatContent.AppendText(" " + DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss") + Environment.NewLine);
                        }));

                        //添加内容
                        if (String.Compare(sArray[1], FormLogin.formLogin.Get_myName) == 0)
                        {
                            richChatContent.Invoke(new EventHandler(delegate
                            {
                                richChatContent.SelectionColor = SystemColors.Highlight;
                                newShow();
                                richChatContent.AppendText(sArray[1] + "(我):" + sArray[2] + Environment.NewLine);
                            }));

                        }
                        else if (sArray[1] == "服务器")
                        {
                            richChatContent.Invoke(new EventHandler(delegate
                            {
                                richChatContent.SelectionColor = Color.Green;
                                newShow();
                                richChatContent.AppendText(sArray[1] + "通知:" + sArray[2] + Environment.NewLine);
                            }));
                        }
                        else
                        {
                            richChatContent.Invoke(new EventHandler(delegate
                            {
                                richChatContent.SelectionColor = SystemColors.WindowText;
                                newShow();
                                richChatContent.AppendText(sArray[1] + ":" + sArray[2] + Environment.NewLine);
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("5系统错误，请再试一次吧〒▽〒" + "\n" + ex.Message);
            }
        }

        private void SendMessage()
        {
            try
            {
                writer.Write("' "+FormLogin.formLogin.Get_myName+" "+richSendContent.Text);
                writer.Flush();

                //发完消息清空
                ResetMessage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("6系统错误，请再试一次吧〒▽〒" + "\n" + ex.Message);
            }
        }

        private void DeleteTcp()
        {
            try
            {
                writer.Write("~ DeleteTcp " + FormLogin.formLogin.Get_myName);
                writer.Flush();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("7系统错误，请再试一次吧〒▽〒" + "\n" + ex.Message);
            }
        }

        private void FormChat_Shown(object sender, EventArgs e)
        {
            if (FormLogin.formLogin.Get_tcpClient != null)
            {
                tcpClient = FormLogin.formLogin.Get_tcpClient;
                networkStream = tcpClient.GetStream();
                reader = new BinaryReader(networkStream);
                writer = new BinaryWriter(networkStream);
                //启动接受消息的子线程
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start();
            }
            else
            {
                MessageBox.Show("当前TCP连接出错，请重试。");
                FormLogin.formLogin.Show();
                this.Close();
            }
        }

        /*private void toolStripButtonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "选择文件";
            openfile.Filter = "Files(*.*)|*.*";
            if (openfile.ShowDialog() == DialogResult.OK && (openFileDialog1.FileName != ""))
            {
                //richSendContent.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                Image imge = Properties.Resources.发送文件_32_;
                Graphics g = richSendContent.CreateGraphics(); //这句是关键哦
                g.DrawImage(imge, 10, 10);
                richSendContent.Clear();
            }
            openfile.Dispose();
        }*/
    }
}
