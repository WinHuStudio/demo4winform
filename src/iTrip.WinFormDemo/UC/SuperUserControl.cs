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
using iTrip.iPP.IProxy;

namespace iTrip.WinFormDemo.UC
{
    public interface ISuperCtrl
    {
        UCFregments Fregment { get; }
        ISuperCtrl DefCtrl { get; }
        ISuperCtrl Parent { get; }
        List<ISuperCtrl> Children { get; }

        void Register();
        void ShowChildren();
        void ShowParent();

        void Load();
        void Load(string account);

        void WSReceivedPackage(IPackage package);
        void WSReceivedResult(Guid uid, bool state);
    }
    public abstract class SuperCtrl : ISuperCtrl
    {
        public abstract UCFregments Fregment { get; }

        public abstract ISuperCtrl DefCtrl { get; }
        public abstract ISuperCtrl Parent { get; }
        public abstract List<ISuperCtrl> Children { get; }

        public abstract void Register();
        public abstract void ShowChildren();
        public abstract void ShowParent();
        public abstract void Load();
        public abstract void Load(string account);



        public virtual void WSReceivedPackage(IPackage package)
        {
        }

        public virtual void WSReceivedResult(Guid uid, bool state)
        {
        }
    }

    public partial class SuperUserControl : UserControl
    {
        public SuperUserControl()
        {
            InitializeComponent();
        }

        public virtual UCFregments Code { get { return UCFregments.Unknown; } }
        public virtual void Init(SuperDao dao)
        {
            this.Dock = DockStyle.Fill;
        }

        protected ListViewItem NewListViewItem(string key, string timespan, string text)
        {
            ListViewItem item = new ListViewItem(text);
            item.Name = key;
            item.ToolTipText = timespan;
            return item;
        }
        public virtual void WSReceivedPackage(IPackage package)
        {
        }

        public virtual void WSReceivedResult(Guid uid, bool state)
        {
        }


    }
}
