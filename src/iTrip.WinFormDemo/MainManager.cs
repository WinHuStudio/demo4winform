using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.WinFormDemo.Business;
using iTrip.WinFormDemo.Core;

namespace iTrip.WinFormDemo
{
    public class MainManager
    {
        private static MainManager _instance = new MainManager();
        public static MainManager Instance { get { return _instance; } }

        private ISuperBusiness _currentBusiness = new BusiContainer();
        public ISuperBusiness DefaultBusiness { get { return _currentBusiness; } }

        private List<ISuperBusiness> _businesses = new List<ISuperBusiness>();

        private void RegisterBusiness()
        {
            _businesses.Add(_currentBusiness);
            _businesses.Add(new BusiLogin());
            _businesses.Add(new BusiMainFrom());
            _businesses.Add(new BusiContacts());
            _businesses.Add(new BusiChatting());

            _businesses.ForEach(b => b.RegisterWSEvent());
        }

        public void Init()
        {
            RegisterBusiness();

            if (!ReqAccount.Instance.IsValidatedUser())
            {
                Show(UCFregments.Login, null);
            }
            else
            {
                Show(UCFregments.MainFrom, null);
                //ReqWebSocket.Instance.Connected();
            }
        }

        public void Back()
        {
            if (_currentBusiness == null || _currentBusiness.Parent == null) return;
            _currentBusiness.Hide();
            _currentBusiness = _currentBusiness.Parent;
            if (_currentBusiness.Code == UCFregments.Container)
            {
                ReqWebSocket.Instance.Close();
                _currentBusiness.Load(null);
                Show(UCFregments.Login, null);
            }
        }
        public void Show(UCFregments fregment, Dao.SuperDao dao)
        {
            ISuperBusiness next = _businesses.Find(b => b.Code == fregment);
            if (next == null) return;
            next.SetParent(_currentBusiness);
            _currentBusiness = next;
            _currentBusiness.Show();
            _currentBusiness.Load(dao);
        }

        public ISuperBusiness GetBusi(UCFregments fregment)
        {
            return _businesses.Find(b => b.Code == fregment);
        }
    }
}
