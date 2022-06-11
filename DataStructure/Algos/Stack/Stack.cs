using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack
    {
        public int position;
        object[] data = new object[10];
        public void Push(object obj) => data[position++] = obj;
        public object Pop() =>  data[--position];
       
    }

    public class Stack<T>
    {
        public int position;
        T[] data = new T[100];
        public void Push(T obj) => data[position++] = obj;
        public T Pop() => data[--position];
    }
}
