using System;
using System.IO;

namespace Reflection_AssemblyLocation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(FileStream).Assembly.Location);
        }
    }
}
