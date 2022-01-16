using System;
using System.Text;

namespace Encoding
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            Console.WriteLine("-------Get ASCII/Unicode ------ ");
            Console.WriteLine("One character allowed. Press Enter to Exit.");
            while (flag)
            {                         
                Console.Write("Please type a key: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || input.Length > 1)
                {
                    flag = false;
                    Console.WriteLine("invalid input.");
                    break;
                }
                short result = (short)Convert.ToChar(input);
                Console.WriteLine("code: "+ result);

            }
            
        }
    }
}
