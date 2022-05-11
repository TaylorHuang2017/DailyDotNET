using System;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<Controller>();
            services.AddScoped<ILog, LogImpl>();
            services.AddScoped<IStorage, StorageImpl>();
            services.AddScoped<IConfig, ConfigImpl>();

            using (var sp = services.BuildServiceProvider())
            {
                var c = sp.GetRequiredService<Controller>();
                c.Test();
            }

            Console.ReadKey();
        }
    }

    class Controller
    {
        private readonly ILog log;
        private readonly IStorage storage;

        public Controller(ILog log, IStorage storage)
        {
            this.log = log;
            this.storage = storage;
        }

        public void Test()
        {
            log.Log("开始上传");
            storage.Save("........","1.txt");
            log.Log("上传完毕");

        }
    }

    interface ILog
    {
        public void Log(string msg);
    }
    interface IConfig
        {
            public string GetValue(string name);
        }
    interface IStorage
    {
        public void Save(string content, string filename);
    }
    
    class LogImpl : ILog
    {
        public void Log(string msg)
        {
            Console.WriteLine($"记录日志: {msg}");
        }
    }

    class ConfigImpl : IConfig
    {
        public string GetValue(string name)
        {
            return "valueFor"+name;
        }
    }

    class StorageImpl : IStorage
    {
        //依赖注入；不关心具体实现，要就行了
        private readonly IConfig config;

        public StorageImpl(IConfig config)  //带构造函数，config实现对象由框架自动注入
        {
            this.config = config;
        }
        public void Save(string content, string filename)
        {
            //存储之前读取配置，获取服务器地址
            string server = config.GetValue("server");
            Console.WriteLine($"向服务器{server}的文件名为{filename}上传{content}");
        }
    }
}
