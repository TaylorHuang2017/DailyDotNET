using System;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTPClient_spider
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://music.douban.com/artists/tag/Rock";

            /*
             <a href="https://site.douban.com/gala/" style="font-size:14px">GALA</a>
             <a href="https://site.douban.com/kulu/" style="font-size:14px">梁晓雪</a>
             */
            using (HttpClient httpClient = new HttpClient())
            {
                string html = await httpClient.GetStringAsync(url);
                Regex reg = new Regex("14px\">(.+)</a>");
                MatchCollection matches = reg.Matches(html);
                for (int i = 0; i < matches.Count; i++)
                {
                    Console.WriteLine(matches[i]);
                }
            }
            

        }
    }
}
