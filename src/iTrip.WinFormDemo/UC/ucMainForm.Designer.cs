namespace iTrip.WinFormDemo.UC
{
    partial class ucMainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslbContacts = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbFind = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbMe = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainerSub = new System.Windows.Forms.SplitContainer();
            this.lbAccountName = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSub)).BeginInit();
            this.splitContainerSub.Panel1.SuspendLayout();
            this.splitContainerSub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslbContacts,
            this.tsslbFind,
            this.tsslbMe});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(351, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslbContacts
            // 
            this.tsslbContacts.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsslbContacts.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.tsslbContacts.Name = "tsslbContacts";
            this.tsslbContacts.Size = new System.Drawing.Size(49, 15);
            this.tsslbContacts.Text = "Contact";
            this.tsslbContacts.Click += new System.EventHandler(this.tsslbContacts_Click);
            // 
            // tsslbFind
            // 
            this.tsslbFind.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.tsslbFind.Name = "tsslbFind";
            this.tsslbFind.Size = new System.Drawing.Size(30, 15);
            this.tsslbFind.Text = "Find";
            // 
            // tsslbMe
            // 
            this.tsslbMe.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.tsslbMe.Name = "tsslbMe";
            this.tsslbMe.Size = new System.Drawing.Size(24, 15);
            this.tsslbMe.Text = "Me";
            // 
            // splitContainerSub
            // 
            this.splitContainerSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSub.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerSub.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSub.Name = "splitContainerSub";
            this.splitContainerSub.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSub.Panel1
            // 
            this.splitContainerSub.Panel1.Controls.Add(this.lbAccountName);
            this.splitContainerSub.Size = new System.Drawing.Size(351, 388);
            this.splitContainerSub.SplitterDistance = 26;
            this.splitContainerSub.TabIndex = 0;
            // 
            // lbAccountName
            // 
            this.lbAccountName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAccountName.Location = new System.Drawing.Point(0, 0);
            this.lbAccountName.Name = "lbAccountName";
            this.lbAccountName.Size = new System.Drawing.Size(351, 26);
            this.lbAccountName.TabIndex = 0;
            this.lbAccountName.Text = "Account";
            this.lbAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitContainerSub);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer.Size = new System.Drawing.Size(351, 417);
            this.splitContainer.SplitterDistance = 388;
            this.splitContainer.TabIndex = 0;
            // 
            // ucMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer);
            this.Name = "ucMainForm";
            this.Size = new System.Drawing.Size(351, 417);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainerSub.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSub)).EndInit();
            this.splitContainerSub.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslbContacts;
        private System.Windows.Forms.ToolStripStatusLabel tsslbFind;
        private System.Windows.Forms.ToolStripStatusLabel tsslbMe;
        private System.Windows.Forms.SplitContainer splitContainerSub;
        private System.Windows.Forms.Label lbAccountName;
        private System.Windows.Forms.SplitContainer splitContainer;


    }
}
