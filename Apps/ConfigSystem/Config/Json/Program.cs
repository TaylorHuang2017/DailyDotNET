using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            


            //读取Json文件
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            //AddJsonFile 扩展方法
            configBuilder.AddJsonFile("config.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configRoot = configBuilder.Build();

            //绑定
            services.AddOptions().Configure<Config>(e => configRoot.Bind(e));
            services.AddScoped<OptionsClass>();

            using (var sp = services.BuildServiceProvider())
            {
                var c = sp.GetRequiredService<OptionsClass>();
                c.Test();
            }

            //----------------------------method 1: read config directly
            //string name = configRoot["name"];
            //Console.WriteLine($"name = {name}");
            //string address = configRoot.GetSection("proxy:address").Value;
            //Console.WriteLine($"address = {address}");

            //---------------------------method 2 use predefined class
            //Proxy proxy = configRoot.GetSection("proxy").Get<Proxy>();
            //Console.WriteLine(proxy.Address + " " + proxy.Port);

        }

        public class Config
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Proxy  Proxy { get; set; }
        }

        public class Proxy
        {
            public string Address { get; set; }
            public int Port { get; set; }
        }
    }
}
