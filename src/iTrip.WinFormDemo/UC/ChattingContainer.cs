using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTrip.iPP.IProxy;
using iTrip.WinFormDemo.Dao;

namespace iTrip.WinFormDemo.UC
{

    public class ChattingContainer : ListView
    {
        delegate void ShowReceivedPackage(IPackage package, bool state);
        delegate void ShowReceivedResult(Guid uid, bool state);

        private Contact _contact;

        public void SetContact(Contact contact) { _contact = contact; }

        List<ChattingItem> _items = new List<ChattingItem>();

        public void AddPackage(IPackage package, bool state = true)
        {
            ShowReceivedPackage delegate_ShowPackage = new ShowReceivedPackage(DisplayPackage);
            if (this.InvokeRequired)
                this.BeginInvoke(delegate_ShowPackage, package, true);
            else
            {
                DisplayPackage(package, state);
            }
        }

        private void DisplayPackage(IPackage package, bool state)
        {
            var item = new ChattingItem(package, _contact);
            Items.Add(item);
            _items.Add(item);
        }
        private void UpdatePackage(Guid uid, bool state)
        {
            var item = _items.Find(i => i.UID == uid);
            if (item == null) return;
            item.UpdateState();
        }

        public void UpdateItemState(Guid uid, bool state)
        {
            ShowReceivedResult delegate_UpdatePackage = new ShowReceivedResult(UpdatePackage);
            if (this.InvokeRequired)
                this.BeginInvoke(delegate_UpdatePackage, uid, state);
            else
            {
                delegate_UpdatePackage(uid, state);
            }
        }
    }
}
