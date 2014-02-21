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
using iTrip.WinFormDemo.Core;
using iTrip.iPP.IProxy;

namespace iTrip.WinFormDemo.UC
{
    public delegate void OnSendPackageEventHandler(IPackage package);
    public partial class ucChatting : SuperUserControl
    {
        public ucChatting()
        {
            InitializeComponent();
        }
        public override UCFregments Code
        {
            get
            {
                return UCFregments.Chatting;
            }
        }

        private Contact chattingwith;
        public override void Init(Dao.SuperDao dao)
        {
            if (dao != null)
            {
                base.Init(dao);
                chattingwith = dao as Contact;
                lvChatting.SetContact(chattingwith);
                this.lbChattingFriend.Text = chattingwith.Name;
                this.lbChattingFriend.Tag = chattingwith.Account;
            }
            lvChatting.Clear();
        }
        public void LoadClientPackage(List<ClientPackage> packages)
        {
            packages.ForEach(p => AddOnePackage(p.Package, true));
        }
        public void LoadClientPackage(ClientPackage package)
        {
            AddOnePackage(package.Package, true);
        }
        public override void WSReceivedPackage(IPackage package)
        {
            lvChatting.AddPackage(package, true);
        }
        public override void WSReceivedResult(Guid uid, bool state)
        {
            lvChatting.UpdateItemState(uid, state);
        }
        public OnSendPackageEventHandler OnSendPackage;
        private void btnSend_Click(object sender, EventArgs e)
        {
            IPackage package = ReqWebSocket.Instance.SendTextMessage(this.tbContent.Text.Trim(), chattingwith.Account);
            if (package == null)
            {
                MessageBox.Show("发送失败！请检查ws连接状态");
            }
            else
            {
                if (OnSendPackage != null)
                {
                    OnSendPackage(package);
                }
                AddOnePackage(package, false);
                this.tbContent.Clear();
            }
        }

        private void AddOnePackage(IPackage package, bool state)
        {
            lvChatting.AddPackage(package);
            //lvChatting.Items.Add(NewListViewItem(package.UID.ToString(), package.PD.ToString("yyyyMMddHHmmss"), package.GetContent<string>()));
        }
    }
}
