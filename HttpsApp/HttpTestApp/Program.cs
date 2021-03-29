using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://wx.koudl.cn/";

          var data=  PostHelper.PostWebRequest(url, "", Encoding.Unicode);
            Console.Write(data);
        }
    }
}
