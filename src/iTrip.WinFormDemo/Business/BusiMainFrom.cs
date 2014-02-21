using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.IProxy;
using iTrip.WinFormDemo.Common;
using iTrip.WinFormDemo.Core;
using iTrip.WinFormDemo.Dao;
using iTrip.WinFormDemo.UC;

namespace iTrip.WinFormDemo.Business
{
    public class BusiMainFrom : SuperBusiness
    {
        public BusiMainFrom() : base(new UC.ucMainForm()) { }

        FileOperator fileOp;
        public override void Load(SuperDao dao)
        {
            string path = GetDictoryFile(typeof(ClientPackage).Name, null, typeof(ClientPackage).Name);
            fileOp = new FileOperator(path);

            ReqWebSocket.Instance.ReceivedHandler += new ReceivedEventHandler(ReceivedPackage);
            ReqWebSocket.Instance.SendResultHandler += new SendResultEventHandler(SendResultHandler);
            ReqWebSocket.Instance.Connected();
            Ctrl.Init(null);
            Ctrl.Show();
        }

        private void ReceivedPackage(IPackage package)
        {
            fileOp.SaveOne(new ClientPackage(package));
        }
        private void SendResultHandler(Guid guid, bool result)
        {
        }
    }
}
