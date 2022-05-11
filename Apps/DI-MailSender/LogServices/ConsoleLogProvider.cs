﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServices
{
    public class ConsoleLogProvider : ILogProvider
    {
        public void LogError(string msg)
        {
            Console.WriteLine($"ERROR: {msg}"); 
        }

        public void LogInfo(string msg)
        {
            Console.WriteLine($"INFO: {msg}");
        }
    }
}
