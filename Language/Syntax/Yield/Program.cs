using System;
using System.Collections.Generic;

namespace Yield
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Test2())
            {
                Console.WriteLine(item);
            }
        }

        static IEnumerable<string> Test1()
        {
            List<string> list1 = new List<string>();
            list1.Add("tahuan");
            list1.Add("@");
            list1.Add("microsoft.com");
            return list1;
        }

        static IEnumerable<string> Test2()
        {
            yield return "tahuan";
            yield return "@";
            yield return "microsoft.com";
        }
    }
}
