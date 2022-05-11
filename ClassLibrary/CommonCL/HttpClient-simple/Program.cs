using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClient_simple
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000); //设置5秒自动超时
            //cts.Cancel(); //根据输入值取消

            await DownloadHtmlAsync("http://www.shmh.gov.cn/mh-app-front/f/wxArticle/articles", @"c:\pool\myblog2.txt", cts.Token);
        }

        static public async Task DownloadHtmlAsync(string url, string filename, CancellationToken ctoken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string html = await httpClient.GetStringAsync(url);
                if (ctoken.IsCancellationRequested)
                {
                    Console.WriteLine("请求超时或被用户取消");
                }
                await File.WriteAllTextAsync(filename, html);
            }
        }
    }
}
