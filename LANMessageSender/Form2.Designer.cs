namespace LANMessageSender
{
    partial class FormChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChat));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonFont = new System.Windows.Forms.ToolStripDropDownButton();
            this.宋体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.黑体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.楷体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonItalic = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBold = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.小号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.richChatContent = new System.Windows.Forms.RichTextBox();
            this.richSendContent = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonFont,
            this.toolStripButtonItalic,
            this.toolStripButtonBold,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 295);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 33);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonFont
            // 
            this.toolStripButtonFont.AutoSize = false;
            this.toolStripButtonFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFont.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.宋体ToolStripMenuItem,
            this.黑体ToolStripMenuItem,
            this.楷体ToolStripMenuItem});
            this.toolStripButtonFont.Image = global::LANMessageSender.Properties.Resources.字体_16_;
            this.toolStripButtonFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFont.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.toolStripButtonFont.Name = "toolStripButtonFont";
            this.toolStripButtonFont.Size = new System.Drawing.Size(30, 30);
            this.toolStripButtonFont.Text = "字体";
            this.toolStripButtonFont.ToolTipText = "字体";
            // 
            // 宋体ToolStripMenuItem
            // 
            this.宋体ToolStripMenuItem.Enabled = false;
            this.宋体ToolStripMenuItem.Image = global::LANMessageSender.Properties.Resources.宋体_16_;
            this.宋体ToolStripMenuItem.Name = "宋体ToolStripMenuItem";
            this.宋体ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.宋体ToolStripMenuItem.Text = "宋体";
            this.宋体ToolStripMenuItem.Click += new System.EventHandler(this.宋体ToolStripMenuItem_Click);
            // 
            // 黑体ToolStripMenuItem
            // 
            this.黑体ToolStripMenuItem.Image = global::LANMessageSender.Properties.Resources.黑体_16_;
            this.黑体ToolStripMenuItem.Name = "黑体ToolStripMenuItem";
            this.黑体ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.黑体ToolStripMenuItem.Text = "黑体";
            this.黑体ToolStripMenuItem.Click += new System.EventHandler(this.黑体ToolStripMenuItem_Click);
            // 
            // 楷体ToolStripMenuItem
            // 
            this.楷体ToolStripMenuItem.Image = global::LANMessageSender.Properties.Resources.楷体_16_;
            this.楷体ToolStripMenuItem.Name = "楷体ToolStripMenuItem";
            this.楷体ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.楷体ToolStripMenuItem.Text = "楷体";
            this.楷体ToolStripMenuItem.Click += new System.EventHandler(this.楷体ToolStripMenuItem_Click);
            // 
            // toolStripButtonItalic
            // 
            this.toolStripButtonItalic.AutoSize = false;
            this.toolStripButtonItalic.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButtonItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonItalic.Image = global::LANMessageSender.Properties.Resources.斜体_16_;
            this.toolStripButtonItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonItalic.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.toolStripButtonItalic.Name = "toolStripButtonItalic";
            this.toolStripButtonItalic.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripButtonItalic.Size = new System.Drawing.Size(30, 30);
            this.toolStripButtonItalic.Text = "斜体";
            this.toolStripButtonItalic.Click += new System.EventHandler(this.toolStripButtonItalic_Click);
            // 
            // toolStripButtonBold
            // 
            this.toolStripButtonBold.AutoSize = false;
            this.toolStripButtonBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBold.Image = global::LANMessageSender.Properties.Resources.粗体_32_;
            this.toolStripButtonBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBold.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.toolStripButtonBold.Name = "toolStripButtonBold";
            this.toolStripButtonBold.Size = new System.Drawing.Size(30, 30);
            this.toolStripButtonBold.Text = "粗体";
            this.toolStripButtonBold.Click += new System.EventHandler(this.toolStripButtonBold_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoSize = false;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.小号ToolStripMenuItem,
            this.中号ToolStripMenuItem,
            this.大号ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::LANMessageSender.Properties.Resources.字体大小_16_;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(30, 30);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // 小号ToolStripMenuItem
            // 
            this.小号ToolStripMenuItem.Enabled = false;
            this.小号ToolStripMenuItem.Name = "小号ToolStripMenuItem";
            this.小号ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.小号ToolStripMenuItem.Text = "小号";
            this.小号ToolStripMenuItem.Click += new System.EventHandler(this.小号ToolStripMenuItem_Click);
            // 
            // 中号ToolStripMenuItem
            // 
            this.中号ToolStripMenuItem.Name = "中号ToolStripMenuItem";
            this.中号ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.中号ToolStripMenuItem.Text = "中号";
            this.中号ToolStripMenuItem.Click += new System.EventHandler(this.中号ToolStripMenuItem_Click);
            // 
            // 大号ToolStripMenuItem
            // 
            this.大号ToolStripMenuItem.Name = "大号ToolStripMenuItem";
            this.大号ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.大号ToolStripMenuItem.Text = "大号";
            this.大号ToolStripMenuItem.Click += new System.EventHandler(this.大号ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // richChatContent
            // 
            this.richChatContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.richChatContent.Location = new System.Drawing.Point(0, 0);
            this.richChatContent.Name = "richChatContent";
            this.richChatContent.ReadOnly = true;
            this.richChatContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richChatContent.Size = new System.Drawing.Size(584, 292);
            this.richChatContent.TabIndex = 4;
            this.richChatContent.Text = "";
            // 
            // richSendContent
            // 
            this.richSendContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richSendContent.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richSendContent.Location = new System.Drawing.Point(0, 331);
            this.richSendContent.Name = "richSendContent";
            this.richSendContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richSendContent.Size = new System.Drawing.Size(448, 130);
            this.richSendContent.TabIndex = 5;
            this.richSendContent.Text = "";
            this.richSendContent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richSendContent_KeyPress);
            // 
            // sendButton
            // 
            this.sendButton.Image = global::LANMessageSender.Properties.Resources.发送_48_;
            this.sendButton.Location = new System.Drawing.Point(454, 331);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(130, 130);
            this.sendButton.TabIndex = 3;
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.richSendContent);
            this.Controls.Add(this.richChatContent);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormChat";
            this.Text = "Kala聊天室";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChat_FormClosed);
            this.Shown += new System.EventHandler(this.FormChat_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonFont;
        private System.Windows.Forms.ToolStripMenuItem 宋体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 黑体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 楷体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonItalic;
        private System.Windows.Forms.ToolStripButton toolStripButtonBold;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox richChatContent;
        private System.Windows.Forms.RichTextBox richSendContent;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 小号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 大号ToolStripMenuItem;
    }
}