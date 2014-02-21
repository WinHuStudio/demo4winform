using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTrip.WinFormDemo.Dao;

namespace iTrip.WinFormDemo.UC
{
    public partial class ucMainForm : SuperUserControl
    {
        public ucMainForm()
        {
            InitializeComponent();
        }
        public override UCFregments Code
        {
            get
            {
                return UCFregments.MainFrom;
            }
        }

        private void tsslbContacts_Click(object sender, EventArgs e)
        {
            MainManager.Instance.Show(UCFregments.Contacts, null);
        }

        public override void Init(SuperDao dao)
        {
            base.Init(dao);
            this.lbAccountName.Text = AppSettings.Instance.Account;
        }
    }
}
