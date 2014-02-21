using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTrip.WinFormDemo.Business;
using iTrip.WinFormDemo.Core;
using iTrip.WinFormDemo.UC;

namespace iTrip.WinFormDemo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();


            this.splitContainer.Panel1.Controls.Add(MainManager.Instance.DefaultBusiness.Ctrl);
            MainManager.Instance.DefaultBusiness.Show();
            MainManager.Instance.DefaultBusiness.Load(null);
            MainManager.Instance.Init();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainManager.Instance.Back();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReqWebSocket.Instance.Close();
        }
    }
}
