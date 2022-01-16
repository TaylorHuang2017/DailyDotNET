using System;

namespace Generics_Delegate
{
    delegate void TwoStringDel<T>(T value);

    class Simple
    {
        static public void PrintString(string s)
        {
            Console.WriteLine(s);
        }
        static public void PrintUpperString(string s)
        {
            Console.WriteLine($"{s.ToUpper()}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myDel = new TwoStringDel<string>(Simple.PrintString);
            myDel += Simple.PrintUpperString;
            myDel("Hi There.");
        }
    }
}
