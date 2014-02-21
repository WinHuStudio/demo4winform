using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.IProxy;
using iTrip.WinFormDemo.Common;
using iTrip.WinFormDemo.Core;
using iTrip.WinFormDemo.Dao;
using iTrip.WinFormDemo.UC;

namespace iTrip.WinFormDemo.Business
{
    public class BusiChatting : SuperBusiness
    {
        delegate void ShowReceivedPackage(IPackage package, bool state);
        delegate void ShowReceivedResult(Guid uid, bool state);
        public BusiChatting() : base(new UC.ucChatting()) { }

        //public void AddPackage(IPackage package, bool state = true)
        //{
        //    ShowReceivedPackage delegate_ShowPackage = new ShowReceivedPackage(DisplayPackage);
        //    if (Ctrl.InvokeRequired)
        //        Ctrl.BeginInvoke(delegate_ShowPackage, package);
        //    else
        //    {
        //        DisplayPackage(package, state);
        //    }
        //}

        //private void DisplayPackage(IPackage package, bool state)
        //{

        //    var item = new ChattingItem(package, _contact);
        //    Items.Add(item);
        //    _items.Add(item);
        //}
        //private void UpdatePackage(Guid uid, bool state)
        //{
        //    var item = _items.Find(i => i.UID == uid);
        //    if (item == null) return;
        //    item.UpdateState();
        //}

        //public void UpdateItemState(Guid uid, bool state)
        //{
        //    ShowReceivedResult delegate_UpdatePackage = new ShowReceivedResult(UpdatePackage);
        //    if (Ctrl.InvokeRequired)
        //        Ctrl.BeginInvoke(delegate_UpdatePackage, uid, state);
        //    else
        //    {
        //        delegate_UpdatePackage(uid, state);
        //    }
        //}

        FileOperator fileOp;
        public override void Load(SuperDao dao)
        {
            ucChatting ChattingCtrl = Ctrl as UC.ucChatting;
            ChattingCtrl.Init(dao);
            ChattingCtrl.OnSendPackage = new OnSendPackageEventHandler(AfterSendPackage);

            string path = GetDictoryFile(typeof(ClientPackage).Name, null, typeof(ClientPackage).Name);
            fileOp = new FileOperator(path);

            List<ClientPackage> packages = new List<ClientPackage>();
            fileOp.ReadAll().ForEach(delegate(string s)
            {
                var ps = s.Split(new char[] { '|' });
                var cp = new ClientPackage(ps[0], ps[1], ps[2], ps[3], ps[4], ps[5], ps[6], ps[7], ps[8]);
                if ((cp.PS == dao.Account && cp.PR == AppSettings.Instance.Account) || cp.PR == dao.Account)
                    packages.Add(cp);
            });

            ChattingCtrl.LoadClientPackage(packages.OrderBy(p => p.PD).ToList());
        }

        public void AfterSendPackage(IPackage package)
        {
            fileOp.SaveOne(new ClientPackage(package));
        }

        private void HandleReceivedPackage(IPackage package)
        {
            Ctrl.WSReceivedPackage(package);
        }
        private void HandleReceivedResult(Guid uid, bool state)
        {
            if (state)
                Ctrl.WSReceivedResult(uid, state);
        }

        public override void RegisterWSEvent()
        {
            base.RegisterWSEvent();
            ReqWebSocket.Instance.ReceivedHandler += new ReceivedEventHandler(HandleReceivedPackage);
            ReqWebSocket.Instance.SendResultHandler += new SendResultEventHandler(HandleReceivedResult);
        }
    }
}
