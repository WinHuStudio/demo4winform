using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.WinFormDemo
{
    public class AppSettings
    {
        private static AppSettings _mySetting;
        public static AppSettings Instance
        {
            get
            {
                if (_mySetting == null)
                    _mySetting = new AppSettings();
                return _mySetting;
            }
        }

        private string _account, _ticket;
        private string _urlRegister, _urlLogin, _urlLogout, urlCheckTicket;

        public bool IsUsed { get { return !string.IsNullOrEmpty(Ticket); } }
        public string Account
        {
            get
            {
                if (string.IsNullOrEmpty(_account))
                    _account = ConfigSettings.ReadSetting("Account");
                return _account;
            }
            set
            {
                _account = value;
                ConfigSettings.WriteSetting("Account", _account);
            }
        }
        public string Ticket
        {
            get
            {
                if (string.IsNullOrEmpty(_ticket))
                    _ticket = ConfigSettings.ReadSetting("Ticket");
                return _ticket;
            }
            set
            {
                _ticket = value;
                ConfigSettings.WriteSetting("Ticket", _ticket);
            }
        }
        public string UrlLogin
        {
            get
            {
                if (string.IsNullOrEmpty(_urlLogin))
                    _urlLogin = ConfigSettings.ReadSetting("iTripUrlLogin");
                return _urlLogin;
            }
        }
        public string UrlLogout
        {
            get
            {
                if (string.IsNullOrEmpty(_urlLogout))
                    _urlLogout = ConfigSettings.ReadSetting("iTripUrlLogout");
                return _urlLogout;
            }
        }
        public string UrlCheckTicket
        {
            get
            {
                if (string.IsNullOrEmpty(urlCheckTicket))
                    urlCheckTicket = ConfigSettings.ReadSetting("iTripUrlCheckTicket");
                return urlCheckTicket;
            }
        }
        public string UrlRegister
        {
            get
            {
                if (string.IsNullOrEmpty(_urlRegister))
                    _urlRegister = ConfigSettings.ReadSetting("iTripUrlRegister");
                return _urlRegister;
            }
        }
    }
}
