using System;

namespace TypeInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 1, 2,3,4,5};
            var type = numbers.GetType();// === typeof(int[])

            do
            {
                Console.WriteLine($"Type: {type.FullName}");
                Console.WriteLine($"Namespace: {type.Namespace}");
                int c = type.GetMethods().Length;
                Console.WriteLine($"There are {c} methods for {type.Name}");
                foreach (var mi in type.GetMethods())
                {
                    Console.WriteLine("--" + mi.Name);
                }
                type = type.BaseType;
                Console.WriteLine("=========================");
            } while (type != null);
            
        }
    }
}
