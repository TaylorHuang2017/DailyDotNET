using System;

namespace Fibonachi
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0, preFibo = 1, curFibo =1; i < 10; i++)
            {
                Console.Write($"{preFibo}, ");                
                sum = preFibo + curFibo;
                preFibo = curFibo;
                curFibo = sum;                  
            }
        }
    }
}
