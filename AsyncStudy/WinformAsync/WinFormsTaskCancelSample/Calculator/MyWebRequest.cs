using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinFormsTaskCancelSample.Calculator
{
    public class MyWebRequest
    {

        public static async Task<string> GetUrlContent(string url, CancellationToken cancellationToken)
        {
           
            using (HttpClient client=new HttpClient())
            {

                var response = client.GetStringAsync(url, cancellationToken);
                await Task.Delay(30000);
                return await response;

            }
        }

    }
}
