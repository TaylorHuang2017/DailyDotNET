using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleToWebApp2
{
    class Startup
    {
        public void ConfigurationServices(IServiceCollection service)
        { 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints( endpoints => {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello, ASPNetCore");
                });
            });
        }
    }
}
