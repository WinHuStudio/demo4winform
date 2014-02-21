using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace iTrip.WinFormDemo
{
    public class iTripResult
    {
        public bool ret { get; set; }

        public string msg { get; set; }

        public int id { get; set; }
    }
    public static class JsonExtensions
    {
        public static iTripResult ToiTripJsonRet(this string jsonstring)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //var json = serializer.Serialize(p);
            //Console.WriteLine(json);

            var json = serializer.Deserialize<iTripResult>(jsonstring);
            return json;

            //JsonReader jr = new JsonTextReader(new StringReader(jsonstring));
            //IDictionary<string, string> dic = new Dictionary<string, string>();
            //while (jr.Read())
            //{
            //    if (jr.Value != null)
            //        dic.Add(jr.TokenType.ToString(), jr.Value.ToString());
            //}
            //return dic;
        }
    }
}
