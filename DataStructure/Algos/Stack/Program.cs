using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            Console.WriteLine("Stack pointer: "+ stack.position);
            Console.WriteLine("Pushing one item");
            stack.Push("sausage");
            Console.WriteLine("Stack pointer: " + stack.position);
            string s = (string)stack.Pop();
            Console.WriteLine("Stack pointer: " + stack.position);
            Console.WriteLine("Poping up one item " + s);

            var stackG = new Stack<int>();
            stackG.Push(5);
            Console.WriteLine(stackG.Pop());

        }
    }
}
