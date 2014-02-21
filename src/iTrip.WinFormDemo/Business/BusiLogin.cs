using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.WinFormDemo.Dao;
using iTrip.WinFormDemo.UC;

namespace iTrip.WinFormDemo.Business
{
    public interface ISuperBusiness
    {
        SuperUserControl Ctrl { get; }
        void Show();
        void Hide();
        void Back();
        UCFregments Code { get; }
        void Load(SuperDao dao);
        ISuperBusiness Parent { get; }
        void SetParent(ISuperBusiness parent);

        string BaseDictory { get; }
        string GetDictory(string sub, string folder);
        string GetDictoryFile(string sub, string folder, string filename);

        void RegisterWSEvent();
    }
    public abstract class SuperBusiness : ISuperBusiness
    {
        private SuperUserControl _ctrl;
        private ISuperBusiness _parent;
        public SuperBusiness(SuperUserControl ctrl)
        {
            _ctrl = ctrl;
        }

        public SuperUserControl Ctrl { get { return _ctrl; } }
        public ISuperBusiness Parent { get { return _parent; } }
        public virtual void SetParent(ISuperBusiness parent) { _parent = parent; }
        public virtual void Show()
        {
            if (Parent != null)
            {
                Parent.Ctrl.Controls.Remove(Ctrl);
                Parent.Ctrl.Controls.Add(Ctrl);
            }
            Ctrl.Show();
            Ctrl.Dock = System.Windows.Forms.DockStyle.Fill;
            Ctrl.BringToFront();
        }
        public virtual void Hide() { Ctrl.Hide(); }
        public virtual void Back() { Ctrl.Hide(); Parent.Ctrl.Show(); }
        public virtual UCFregments Code { get { return Ctrl.Code; } }

        public abstract void Load(SuperDao dao);

        public virtual string BaseDictory
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
            }
        }


        public virtual string GetDictory(string sub, string folder)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppSettings.Instance.Account, sub, folder ?? string.Empty);
        }


        public string GetDictoryFile(string sub, string folder, string filename)
        {
            return string.Format("{0}\\{1}", GetDictory(sub, folder), filename);
        }


        public virtual void RegisterWSEvent()
        {
        }
    }

    public class BusiLogin : SuperBusiness
    {
        public BusiLogin() : base(new UC.ucLogin()) { }

        public override void Load(SuperDao dao)
        {

        }
    }
}
