using System;

namespace StringEssentials
{
    class Program
    {
        static void Main(string[] args)
        {
            //去除空格
            Console.WriteLine(Helper.StrTrim(" Hello World!"));

            //反转
            Console.WriteLine(Helper.SplitJoin("The quick brown fox jumps over the lazy dog"));
            Console.ReadLine();
        }
    }
}
