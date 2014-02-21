using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTrip.WinFormDemo.Core;
using iTrip.WinFormDemo.Business;
using iTrip.WinFormDemo.Dao;

namespace iTrip.WinFormDemo.UC
{
    public partial class ucContainer : SuperUserControl
    {
        public ucContainer()
        {
            InitializeComponent();
        }
        public override UCFregments Code
        {
            get
            {
                return UCFregments.Container;
            }
        }

        public override void Init(iTrip.WinFormDemo.Dao.SuperDao dao)
        {
            base.Init(dao);

        }

    }
}
