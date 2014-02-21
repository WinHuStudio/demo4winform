using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.IProxy;
using iTrip.iPP.Proxy;
using iTrip.WinFormDemo.Dao;
using WebSocket4Net;

namespace iTrip.WinFormDemo.Core
{
    public delegate void ReceivedEventHandler(IPackage package);
    public delegate void SendResultEventHandler(Guid uid, bool state);
    public class ReqWebSocket
    {
        public ReqWebSocket() { }

        private static ReqWebSocket _instance = new ReqWebSocket();
        public static ReqWebSocket Instance { get { return _instance; } }

        private WebSocket socket;
        private void InitSocket()
        {
            if (socket == null)
            {
                socket = new WebSocket(string.Format("ws://itripping.cn:9200/{0}_{1}", AppSettings.Instance.Account, AppSettings.Instance.Ticket));

                socket.DataReceived += socket_DataReceived;
                socket.Closed += socket_Closed;
                socket.Opened += socket_Opened;
                socket.Error += socket_Error;
            }
        }
        public void Connected()
        {
            InitSocket();
            if (socket.State == WebSocketState.None || socket.State == WebSocketState.Closed || socket.State == WebSocketState.Closing)
            {
                socket.Open();
            }
        }

        public void Close()
        {
            if (socket.State == WebSocketState.Open)
                socket.Close();
            //if (socket.State != WebSocketState.Closed || socket.State != WebSocketState.Closing)
            //{
            //    socket.Close();
            //}
        }

        void socket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
        }

        void socket_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("ws opened");
        }

        void socket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("ws closed");
        }

        public ReceivedEventHandler ReceivedHandler;
        public SendResultEventHandler SendResultHandler;
        private void socket_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data.Length);
            if (e.Data.Length == 0)
            {
                if (SendResultHandler != null)
                    SendResultHandler(Guid.Empty, false);
            }
            else if (e.Data.Length == 24)
            {
                Guid guid = e.Data.FromiTripByteArray(Encoding.UTF8);
                if (SendResultHandler != null)
                    SendResultHandler(guid, true);
                Console.WriteLine(guid.ToString());
            }
            else
            {
                IPackage package = new ipp_Package(e.Data);
                if (ReceivedHandler != null)
                    ReceivedHandler(package);
            }
        }

        private IPackage Send(string pc, PackageType pt, PackageContentType pct, string ps, string pr, string pcn = "")
        {
            IPackage package = new ipp_Package(ps, pc, pt, pct, pr, pcn, "1.0.0.0");
            var bytes = package.ToServerBytes();
            string s = Convert.ToBase64String(bytes);
            if (socket.State == WebSocketState.Open)
            {
                socket.Send(bytes, 0, bytes.Length);
                return package;
            }
            else { return null; }
        }

        public IPackage SendTextMessage(string pc, string pr)
        {
            return Send(pc, PackageType.MI, PackageContentType.T, AppSettings.Instance.Account, pr);
        }
    }
}
