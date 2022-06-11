using System;

namespace Swap
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            int y = 10;
            Console.WriteLine($"{x}, {y}");
            Swap<int>(ref x, ref y);
            Console.WriteLine($"{x}, {y}");

        }

        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp; 
        }
    }
}
