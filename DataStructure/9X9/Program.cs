using System;

namespace _9X9
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= a; b++)
                {
                    Console.Write("{0}x{1}={2}\t",a,b,a*b);
                }
                Console.WriteLine();
            }
        }
    }
}
