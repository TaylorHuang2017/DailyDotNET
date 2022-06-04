using Microsoft.Extensions.Configuration;
using System;

namespace CommandLineConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddCommandLine(args);
        }
    }
}
