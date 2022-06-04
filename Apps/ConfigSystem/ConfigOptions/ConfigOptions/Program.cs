using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConfigOptions
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            using (var sp = services.BuildServiceProvider())
            { 
            }
        }
    }
}
