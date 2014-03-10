using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.IO;
using iTrip.WinFormDemo.Core;
using iTrip.WinFormDemo.Dao;

namespace iTrip.WinFormDemo.UC
{
    public partial class ucLogin : SuperUserControl
    {
        public ucLogin()
        {
            InitializeComponent();
        }

        public override void Init(SuperDao dao)
        {
            this.Dock = DockStyle.Fill;
        }

        public override UCFregments Code
        {
            get
            {
                return UCFregments.Login;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var ret = ReqAccount.Instance.Login(this.tbAccount.Text, this.tbPassword.Text);

            if (!ret.Ret) { this.lbMsg.Text = ret.Msg; }
            else
            {
                AppSettings.Instance.Account = tbAccount.Text.Trim();
                AppSettings.Instance.Ticket = ret.Msg;

                MainManager.Instance.Show(UCFregments.MainFrom, null);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var ret = ReqAccount.Instance.Register(this.tbAccount.Text, this.tbPassword.Text);

            if (!ret.Ret) { this.lbMsg.Text = ret.Msg; }
            else
            {
                AppSettings.Instance.Account = tbAccount.Text.Trim();
            }
        }
    }
}
