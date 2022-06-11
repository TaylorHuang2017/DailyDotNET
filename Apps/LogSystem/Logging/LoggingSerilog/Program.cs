using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Json;
using System;

namespace LoggingSerilog
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddLogging(logBuilder => {
                Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Debug()
                 .Enrich.FromLogContext()
                 .WriteTo.Console(new JsonFormatter())
                 .CreateLogger();
                logBuilder.AddSerilog();
            });

            services.AddScoped<Test1>();
            using (var sp = services.BuildServiceProvider())
            {
                var test1 = sp.GetRequiredService<Test1>();
                test1.Test();
            }
        }
    }
}
