using System;

namespace Numbers
{
    class Program
    {
        static Random random = new Random();//static field
        static void Main(string[] args)
        {
            //Random numbers
            var array = new int[20];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(10); // 0-9
            }
            Console.WriteLine(string.Join(",", array)); //random int

            var array2 = new double[20];
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = random.NextDouble();
            }
            Console.WriteLine(string.Join(",", array2)); //random doubles

            Console.ReadLine();

        }

        
    }
}
