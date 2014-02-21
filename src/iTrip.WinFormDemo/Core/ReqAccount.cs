using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace iTrip.WinFormDemo.Core
{
    public class ReqAccount
    {
        private static ReqAccount _reqAccount;
        public static ReqAccount Instance
        {
            get
            {
                if (_reqAccount == null)
                    _reqAccount = new ReqAccount();
                return _reqAccount;
            }
        }

        public bool IsValidatedUser()
        {
            if (string.IsNullOrEmpty(AppSettings.Instance.Account) || string.IsNullOrEmpty(AppSettings.Instance.Ticket))
                return false;

            return CheckTicket().ret;
        }

        public iTripResult Login(string account, string pwd)
        {
            string data = string.Format("account={0}&password={1}&clientype={2}&clientsn={3}", account, pwd.ToMD5(), 1, "winform");
            string ret = HttpHelper.SendRequest(AppSettings.Instance.UrlLogin, data, new HttpCookieCollection());
            return ret.ToiTripJsonRet();
        }
        public iTripResult Logout(string ticket)
        {
            string data = string.Format("ticket={0}", ticket);
            string ret = HttpHelper.SendRequest(AppSettings.Instance.UrlLogout, data, new HttpCookieCollection());
            return ret.ToiTripJsonRet();
        }
        public iTripResult Register(string account, string pwd)
        {
            string data = string.Format("account={0}&password={1}", account, pwd.ToMD5());
            string ret = HttpHelper.SendRequest(AppSettings.Instance.UrlRegister, data, new HttpCookieCollection());
            return ret.ToiTripJsonRet();
        }
        public iTripResult CheckTicket()
        {
            string data = string.Format("ticket={0}", AppSettings.Instance.Ticket);
            string ret = HttpHelper.SendRequest(AppSettings.Instance.UrlCheckTicket, data, new HttpCookieCollection());
            return ret.ToiTripJsonRet();
        }
    }
}
