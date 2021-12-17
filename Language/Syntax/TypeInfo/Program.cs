using System;

namespace TypeInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 1, 2,3,4,5};
            var type = numbers.GetType();
            Console.WriteLine(type.FullName);
        }
    }
}
