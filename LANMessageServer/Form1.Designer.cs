namespace LANMessageServer
{
    partial class FormServer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServer));
            this.richChatContent = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelIP = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxIP = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelNum = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxNum = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonListen = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richChatContent
            // 
            this.richChatContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richChatContent.Location = new System.Drawing.Point(0, 28);
            this.richChatContent.Name = "richChatContent";
            this.richChatContent.ReadOnly = true;
            this.richChatContent.Size = new System.Drawing.Size(584, 433);
            this.richChatContent.TabIndex = 0;
            this.richChatContent.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelIP,
            this.toolStripTextBoxIP,
            this.toolStripSeparator1,
            this.toolStripLabelNum,
            this.toolStripTextBoxNum,
            this.toolStripButtonListen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelIP
            // 
            this.toolStripLabelIP.Name = "toolStripLabelIP";
            this.toolStripLabelIP.Size = new System.Drawing.Size(67, 22);
            this.toolStripLabelIP.Text = "服务器IP：";
            // 
            // toolStripTextBoxIP
            // 
            this.toolStripTextBoxIP.Name = "toolStripTextBoxIP";
            this.toolStripTextBoxIP.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBoxIP.Text = "10.161.62.181";
            this.toolStripTextBoxIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxIP_KeyPress);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelNum
            // 
            this.toolStripLabelNum.Name = "toolStripLabelNum";
            this.toolStripLabelNum.Size = new System.Drawing.Size(92, 22);
            this.toolStripLabelNum.Text = "当前聊天人数：";
            // 
            // toolStripTextBoxNum
            // 
            this.toolStripTextBoxNum.AutoSize = false;
            this.toolStripTextBoxNum.Name = "toolStripTextBoxNum";
            this.toolStripTextBoxNum.ReadOnly = true;
            this.toolStripTextBoxNum.Size = new System.Drawing.Size(40, 25);
            this.toolStripTextBoxNum.Text = "0";
            // 
            // toolStripButtonListen
            // 
            this.toolStripButtonListen.Image = global::LANMessageServer.Properties.Resources.启动_16_;
            this.toolStripButtonListen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonListen.Name = "toolStripButtonListen";
            this.toolStripButtonListen.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonListen.Text = "启动";
            this.toolStripButtonListen.Click += new System.EventHandler(this.toolStripButtonListen_Click);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.richChatContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormServer";
            this.Text = "服务器   ---Kala聊天室";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServer_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richChatContent;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelIP;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxIP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelNum;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxNum;
        private System.Windows.Forms.ToolStripButton toolStripButtonListen;
    }
}

