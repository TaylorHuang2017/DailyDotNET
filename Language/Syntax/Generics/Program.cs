using System;


namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stackInt = new MyStack<int>();
            MyStack<string> stackString = new MyStack<string>();
            stackInt.Push(3);
            stackInt.Push(5);
            stackInt.Push(7);
            stackInt.Push(9);
            stackInt.Print();
            Console.WriteLine("----------------------");
            Console.WriteLine(stackInt.Pop());
            stackInt.Print();
            stackString.Push("This is fun");
            stackString.Push("hi there");
            stackString.Print();
        }
    }

    class MyStack<T>
    {
        T[] StackArray;
        int StackPointer = 0;
        const int MaxStack = 10;
        bool IsStackFull { get { return StackPointer >= MaxStack; } }
        bool IsStackEmpty { get { return StackPointer <= 0; } }

        public MyStack()
        {
            StackArray = new T[MaxStack];
        }

        public void Push(T x)
        {
            if (!IsStackFull)
            {
                StackArray[StackPointer++] = x;
            }
        }

        public T Pop()
        {
            return (!IsStackEmpty) ? StackArray[--StackPointer] : StackArray[0];
        }

        public void Print()
        {
            for (int i = StackPointer-1; i >=0; i--)
            {
                Console.WriteLine($"   Value: {StackArray[i]}");
            }
        }
    }
}
