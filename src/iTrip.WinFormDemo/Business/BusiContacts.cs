using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using iTrip.WinFormDemo.Common;
using iTrip.WinFormDemo.Dao;

namespace iTrip.WinFormDemo.Business
{
    public class BusiContacts : SuperBusiness
    {
        public BusiContacts() : base(new UC.ucContacts()) { }

        public override void Load(SuperDao dao)
        {
            string path = GetDictoryFile(this.GetType().Name, null, this.GetType().Name);
            FileOperator fileOp = new FileOperator(path);

            List<Contact> contacts = new List<Contact>();
            fileOp.ReadAll().ForEach(s => contacts.Add(new Contact(s)));
            (this.Ctrl as UC.ucContacts).LoadContacts(contacts);
        }
    }
}
