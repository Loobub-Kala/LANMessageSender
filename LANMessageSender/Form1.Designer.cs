namespace LANMessageSender
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.labelName = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelHelp = new System.Windows.Forms.Label();
            this.buttonEntry = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelIP = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxIP = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pictureName = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureName)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(40, 70);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(77, 14);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "您的名称：";
            // 
            // textName
            // 
            this.textName.AllowDrop = true;
            this.textName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textName.Location = new System.Drawing.Point(120, 63);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(180, 23);
            this.textName.TabIndex = 1;
            this.textName.WordWrap = false;
            this.textName.Validating += new System.ComponentModel.CancelEventHandler(this.textName_Validating);
            this.textName.Validated += new System.EventHandler(this.textName_Validated);
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Location = new System.Drawing.Point(38, 40);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(305, 12);
            this.labelHelp.TabIndex = 2;
            this.labelHelp.Text = "【请输入中文、英文大小写、数字或下划线(1-16字符)】";
            // 
            // buttonEntry
            // 
            this.buttonEntry.Location = new System.Drawing.Point(155, 121);
            this.buttonEntry.Name = "buttonEntry";
            this.buttonEntry.Size = new System.Drawing.Size(75, 23);
            this.buttonEntry.TabIndex = 3;
            this.buttonEntry.Text = "进入聊天室";
            this.buttonEntry.UseVisualStyleBackColor = true;
            this.buttonEntry.Click += new System.EventHandler(this.buttonEntry_Click);
            // 
            // labelError
            // 
            this.labelError.Location = new System.Drawing.Point(43, 95);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(300, 12);
            this.labelError.TabIndex = 5;
            this.labelError.Text = "欢迎~";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelIP,
            this.toolStripTextBoxIP,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(384, 25);
            this.toolStrip1.TabIndex = 6;
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
            this.toolStripTextBoxIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox1_KeyPress);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::LANMessageSender.Properties.Resources.连接_32_;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            // 
            // pictureName
            // 
            this.pictureName.Location = new System.Drawing.Point(310, 63);
            this.pictureName.Name = "pictureName";
            this.pictureName.Size = new System.Drawing.Size(23, 23);
            this.pictureName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureName.TabIndex = 4;
            this.pictureName.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.pictureName);
            this.Controls.Add(this.buttonEntry);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.Opacity = 0.95D;
            this.Text = "欢迎进入Kala聊天室";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.Button buttonEntry;
        private System.Windows.Forms.PictureBox pictureName;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelIP;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxIP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

