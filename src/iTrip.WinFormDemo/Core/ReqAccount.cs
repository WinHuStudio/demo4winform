using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using iTrip.Service.Wcf.Passport.IAuthentication;

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

            return CheckTicket().Ret;
        }

        public StandardResult Login(string account, string pwd)
        {
            IServiceAuthenticationReception servAuth = ReqWcfService.Instance.GetService<IServiceAuthenticationReception>();
            var ret = servAuth.Login(account, pwd.ToMD5(), DeviceType.WinPhone, "wp123456abc");
            return ret;
            //string data = string.Format("account={0}&password={1}&clientype={2}&clientsn={3}", account, pwd.ToMD5(), 1, "winform");
            //string ret = HttpHelper.SendRequest(AppSettings.Instance.UrlLogin, data, new HttpCookieCollection());
            //return ret.ToiTripJsonRet();
        }
        public StandardResult Logout(string ticket)
        {
            IServiceAuthenticationReception servAuth = ReqWcfService.Instance.GetService<IServiceAuthenticationReception>();
            return servAuth.Logout(ticket);
            //string data = string.Format("ticket={0}", ticket);
            //string ret = HttpHelper.SendRequest(AppSettings.Instance.UrlLogout, data, new HttpCookieCollection());
            //return ret.ToiTripJsonRet();
        }
        public StandardResult Register(string account, string pwd)
        {
            IServiceAuthenticationReception servAuth = ReqWcfService.Instance.GetService<IServiceAuthenticationReception>();
            return servAuth.Register(account, pwd.ToMD5());
            //string data = string.Format("account={0}&password={1}", account, pwd.ToMD5());
            //string ret = HttpHelper.SendRequest(AppSettings.Instance.UrlRegister, data, new HttpCookieCollection());
            //return ret.ToiTripJsonRet();
        }
        public StandardResult CheckTicket()
        {
            IServiceAuthenticationReception servAuth = ReqWcfService.Instance.GetService<IServiceAuthenticationReception>();
            return servAuth.CheckTicket(AppSettings.Instance.Ticket);
            //string data = string.Format("ticket={0}", AppSettings.Instance.Ticket);
            //string ret = HttpHelper.SendRequest(AppSettings.Instance.UrlCheckTicket, data, new HttpCookieCollection());
            //return ret.ToiTripJsonRet();
        }
    }
}
