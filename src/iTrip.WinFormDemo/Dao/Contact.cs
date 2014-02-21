using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.WinFormDemo.Dao
{
    public class SuperDao
    {
        public virtual string Account { get; set; }
        public virtual string ToFileLine() { return string.Empty; }
    }
    public class SuperContact : SuperDao
    {
        public string Name { get; set; }

        public string Photo { get; set; }

        public int Gender { get; set; }

        public DateTime CreatedTime { get; set; }

        public override string ToFileLine()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}", Account, Name, Photo, Gender, CreatedTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }

    public class Contact : SuperContact
    {
        public Contact(string account, string name, string photo, int gender)
        {
            Account = account;
            Name = name;
            Photo = photo;
            Gender = gender;
            CreatedTime = DateTime.Now;
        }
        public Contact(string contact)
        {
            string[] items = contact.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length != 5) throw new Exception("Unvalid Contact");
            Account = items[0];
            Name = items[1];
            Photo = items[2];
            Gender = items[3].ToInt(0);
            CreatedTime = items[4].ToDateTime();
        }
    }
}
