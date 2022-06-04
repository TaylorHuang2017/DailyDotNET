using System;
using ConfigServices;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;

namespace DI_MailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();

            //服务注册
            //services.AddScoped<IConfigService, EnvVarConfigService>();
            services.AddScoped(typeof(IConfigService), s => new IniFileConfigService { FilePath = "mail.ini" } );

            //services.AddScoped<ILogProvider, ConsoleLogProvider>();
            //引入Extension methods进行服务注册
            services.AddConsoleLog();

            services.AddScoped<IMailService, MailService>();

            using (var sp = services.BuildServiceProvider())
            {
                var mailService = sp.GetRequiredService<IMailService>(); //第一个根对象只能用service locator
                mailService.Send("hello", "taylorw@126.com", "test message");
            }

            Console.ReadKey();

        }
    }
}
