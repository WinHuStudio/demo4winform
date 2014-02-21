namespace iTrip.WinFormDemo.UC
{
    partial class ucChatting
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvChatting = new ChattingContainer();
            this.lbChattingFriend = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbContent = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvChatting);
            this.splitContainer1.Panel1.Controls.Add(this.lbChattingFriend);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSend);
            this.splitContainer1.Panel2.Controls.Add(this.tbContent);
            this.splitContainer1.Size = new System.Drawing.Size(229, 414);
            this.splitContainer1.SplitterDistance = 347;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvChatting
            // 
            this.lvChatting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvChatting.Location = new System.Drawing.Point(0, 20);
            this.lvChatting.Name = "lvChatting";
            this.lvChatting.ShowItemToolTips = true;
            this.lvChatting.Size = new System.Drawing.Size(229, 327);
            this.lvChatting.TabIndex = 0;
            this.lvChatting.UseCompatibleStateImageBehavior = false;
            this.lvChatting.View = System.Windows.Forms.View.Tile;
            // 
            // lbChattingFriend
            // 
            this.lbChattingFriend.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbChattingFriend.Location = new System.Drawing.Point(0, 0);
            this.lbChattingFriend.Name = "lbChattingFriend";
            this.lbChattingFriend.Size = new System.Drawing.Size(229, 20);
            this.lbChattingFriend.TabIndex = 1;
            this.lbChattingFriend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(133, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(43, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbContent
            // 
            this.tbContent.Location = new System.Drawing.Point(3, 3);
            this.tbContent.Multiline = true;
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(124, 57);
            this.tbContent.TabIndex = 0;
            // 
            // ucChatting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucChatting";
            this.Size = new System.Drawing.Size(229, 414);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbContent;
        private ChattingContainer lvChatting;
        private System.Windows.Forms.Label lbChattingFriend;
    }
}
