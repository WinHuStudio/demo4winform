namespace iTrip.WinFormDemo.UC
{
    partial class ucContacts
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
            this.lvContacts = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvContacts
            // 
            this.lvContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvContacts.Location = new System.Drawing.Point(0, 25);
            this.lvContacts.MultiSelect = false;
            this.lvContacts.Name = "lvContacts";
            this.lvContacts.Size = new System.Drawing.Size(232, 305);
            this.lvContacts.TabIndex = 0;
            this.lvContacts.UseCompatibleStateImageBehavior = false;
            this.lvContacts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvContacts_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contact Book";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvContacts);
            this.Controls.Add(this.label1);
            this.Name = "ucContacts";
            this.Size = new System.Drawing.Size(232, 330);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvContacts;
        private System.Windows.Forms.Label label1;
    }
}
