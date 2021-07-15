using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
namespace CrawlSample
{
    class MyCrawl
    {
        string url = "https://www.cnblogs.com/";
        public async Task<string> GetMainPage(string url)
        {
            using (HttpClient client = new HttpClient())
            {

                string html = await client.GetStringAsync(url);

                return html;
            }
        }

        public void anlysisHtml(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var articleRoot = doc.GetElementbyId("post_list");
            if (articleRoot != null)
            {
                var nodeCollection = articleRoot.SelectNodes("//article");
                foreach (var item in nodeCollection)
                {
                    Console.WriteLine(item.InnerText);
                }
            }
        }

        public async  void Test()
        {
           string htmlContent =   await     GetMainPage(url);

            anlysisHtml(htmlContent);
        }

    }
}
