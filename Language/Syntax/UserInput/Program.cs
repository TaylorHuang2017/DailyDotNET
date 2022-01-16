using System;

namespace UserInput
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How old are you? ");
            string userInput = Console.ReadLine();
            int age;
            bool success = int.TryParse(userInput, out age); // if not successful, age will become zero.
            if (success)
            {
                Console.WriteLine($"{age} is still young. ");
            }
            else
                Console.WriteLine($"{userInput} is not an age. ");
            
        }
    }
}
