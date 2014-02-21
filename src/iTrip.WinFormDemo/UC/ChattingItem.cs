using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTrip.iPP.IProxy;
using iTrip.WinFormDemo.Dao;

namespace iTrip.WinFormDemo.UC
{
    public class ChattingItem : ListViewItem
    {
        Color _defColor;
        public Guid UID { get; set; }
        public ChattingItem(IPackage package, SuperDao dao, bool state = true)
        {
            _defColor = BackColor;
            Text = string.Format("{0} - {1}", AppSettings.Instance.Account == package.PS ? "ME" : package.PR, package.GetContent<string>());

            UID = package.UID;

            ToolTipText = package.PD.ToString("yyyy-MM-dd HH:mm:ss");
            if (!state)
                BackColor = Color.LightGray;
        }

        public void UpdateState()
        {
            BackColor = _defColor;
        }
    }
}
