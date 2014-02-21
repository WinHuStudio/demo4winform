using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.IProxy;

namespace iTrip.WinFormDemo.Dao
{
    public class ClientPackage
    {
        private string _ps, _pc, _pr, _pcn;
        PackageContentType _pct;
        PackageType _pt;
        DateTime _pd = DateTime.Now;
        public ClientPackage(string ps, string pc, PackageType pt, PackageContentType pct, string pr, string pcn)
        {
            _ps = ps;
            _pc = pc;
            _pr = pr;
            _pct = pct;
            _pt = pt;
            _pcn = pcn;

            _byte_content = new List<byte>();
            _byte_header = new List<byte>();
        }
        private Guid _uid = Guid.NewGuid();
        public Guid UID { get { return _uid; } }
        public string Cmd
        {
            get
            {
                if (_pt == PackageType.MI)
                {
                    return "ipp_MSG ";
                }
                return string.Empty;
            }
        }

        public string IPPV { get { return "1.0.0.0"; } }
        public DateTime CreatedTime { get { return _pd; } }
        private List<byte> _byte_content;
        private List<byte> _byte_header;

        public byte[] GetBytes()
        {
            _byte_header.AddRange(Encoding.UTF8.GetBytes(Cmd));
            var pc = Encoding.UTF8.GetBytes(_pc);
            var ps = Encoding.UTF8.GetBytes(_ps);
            var pr = Encoding.UTF8.GetBytes(_pr);
            //PCC=(PD(ddHHmmss)|PCL)|(PT|PCT)
            string pcc = ((_pd.ToString("ddHHmmss").ToInt(0) | pc.Length) | ((int)_pt | (int)_pct)).ToLitString();

            Build(pcc, false);
            Build(UID);
            Build(_pd.ToString("yyyyMMddHHmmss"), false);
            Build(IPPV);
            Build((int)_pt);
            Build((int)_pct);
            Build(pc.Length);
            Build(ps.Length, false);
            Build(pr.Length, false);
            Build(_pcn);
            _byte_header.AddRange(new byte[] { 0, 0, 0 });
            _byte_header.AddRange(_byte_content);
            _byte_header.AddRange(ps);
            _byte_header.AddRange(pr);
            _byte_header.AddRange(pc);
            return _byte_header.ToArray();
        }

        private void Build(string c, bool h = true)
        {
            byte[] bytes = Encoding.Default.GetBytes(c);
            _byte_content.AddRange(bytes);
            if (h)
                _byte_header.Add((byte)bytes.Length);
        }
        private void Build(int i, bool c = true)
        {
            if (i < 256 && !c)
                _byte_header.Add((byte)i);
            else
            {
                byte[] bytes = BitConverter.GetBytes(i);
                _byte_header.Add((byte)bytes.Length);
                if (c)
                    _byte_content.AddRange(bytes);
            }
        }
        private void Build(Guid uid)
        {
            byte[] bytes = uid.ToiTripByteArray();// Encoding.UTF8.GetBytes(Convert.ToBase64String(uid.ToByteArray()));
            //_byte_header.Add((byte)bytes.Length);
            _byte_content.AddRange(bytes);
        }
    }
}
