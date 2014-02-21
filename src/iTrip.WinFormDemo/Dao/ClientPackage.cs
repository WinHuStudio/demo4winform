using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.IProxy;

namespace iTrip.WinFormDemo.Dao
{
    public class ClientPackage : SuperDao
    {
        IPackage _package;
        public IPackage Package { get { return _package; } }
        public ClientPackage(IPackage package)
        {
            _package = package;
        }
        public ClientPackage(string ippv, string uid, string pd, string pt, string pct, string ps, string pr, string pcn, string pc)
        {
            _package = new iPP.Proxy.ipp_Package(Guid.Parse(uid), pd.ToDateTime(), ps, pc, (PackageType)pt.ToInt(0), (PackageContentType)pct.ToInt(0), pr, pcn, ippv);
        }

        public DateTime PD { get { return _package.PD; } }
        public string PS { get { return _package.PS; } }
        public string PR { get { return _package.PR; } }
        public override string ToFileLine()
        {
            if (_package.PCT == (int)PackageContentType.T)
                return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                _package.IPPV,
                _package.UID,
                _package.PD.ToString("yyyy-MM-dd HH:mm:ss"),
                _package.PT,
                _package.PCT,
                _package.PS,
                _package.PR,
                _package.PCN,
                _package.GetContent<string>());
            return string.Empty;
        }
    }
}
