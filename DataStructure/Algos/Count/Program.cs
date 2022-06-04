using System;

namespace Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var pr = new Program();
            pr.Count(3);
        }

        public void Count(int n)
        {
            if (n == 0)
                return;
            Count(n - 1);
            Console.WriteLine($"{n}");
        }
    }
}
