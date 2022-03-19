using System;
using System.IO;
using System.Reflection;

namespace AssemblyLocation
{
    public class Class1
    {
        public void Test()
        {
            Console.WriteLine(typeof(FileStream).Assembly.Location);
        }
    }
}
