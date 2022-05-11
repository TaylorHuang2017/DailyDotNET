using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HttpClient_simple;

namespace Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            await ThreadSwitch();
            Console.WriteLine("Thread Id: " + Thread.CurrentThread.ManagedThreadId);

        }

        static async Task ThreadSwitch()
        {

            //method 1
            //Console.WriteLine("Thread Id: "+Thread.CurrentThread.ManagedThreadId);
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < 10000; i++)
            //{
            //    sb.Append("xxxxxxxxxxxxxxxxxxxx");
            //}
            //await HttpClient_simple.Program.DownloadHtmlAsync("http://huangtairan.cn/", @"c:\pool\myblog.txt");
            //Console.WriteLine("Thread Id: " + Thread.CurrentThread.ManagedThreadId);

            //method 2: Task.Run()
            await Task.Run(() => {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 5000; i++)
                {
                    sb.Append("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                }                
            });

        }
    }
}
