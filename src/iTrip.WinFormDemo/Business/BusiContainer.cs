using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.WinFormDemo.Core;

namespace iTrip.WinFormDemo.Business
{
    public class BusiContainer : SuperBusiness
    {
        public BusiContainer() : base(new UC.ucContainer()) { }


        public override void Load(Dao.SuperDao dao)
        {
            //if (ReqAccount.Instance.Logout(AppSettings.Instance.Ticket).ret)
            //{
            //    AppSettings.Instance.Account = string.Empty;
            //    AppSettings.Instance.Ticket = string.Empty;
            //}
            //Ctrl.Init(null);
        }
    }
}
