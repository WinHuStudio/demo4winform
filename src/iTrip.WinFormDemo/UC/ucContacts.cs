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
using iTrip.WinFormDemo.Business;

namespace iTrip.WinFormDemo.UC
{
    public partial class ucContacts : SuperUserControl
    {
        public ucContacts() 
        {
            InitializeComponent();
        }

        public override UCFregments Code
        {
            get
            {
                return UCFregments.Contacts;
            }
        }

        public void LoadContacts(List<Contact> contacts)
        {
            this.lvContacts.Items.Clear();
            contacts.ForEach(delegate(Contact contact)
            {
                ListViewItem item = new ListViewItem();
                item.Text = contact.Name;
                item.Name = contact.Account;
                item.Tag = contact;
                this.lvContacts.Items.Add(item);
            });
        }

        private void lvContacts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in lvContacts.SelectedItems)
            {
                MainManager.Instance.Show(UCFregments.Chatting, item.Tag as Contact);
            }
        }
    }
}
