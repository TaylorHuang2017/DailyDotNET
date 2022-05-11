using System;

namespace LambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Action f1 = delegate ()
            {
                Console.WriteLine("I'm an anonymous method.");
            };

            f1();

            Action<string, int> f2 = delegate (string n, int a)
            {
                Console.WriteLine($"n={n}, a = {a}");
            };

            f2("htr", 1);

            Action<string, int> f3 = (n, a) => Console.WriteLine($"n={n}, a = {a}");

            f3("from lambda", 10);

        }
    }
}
