using System;

namespace Delegate_PluginMethod
{
    public delegate int Transformer(int x); //委托
    
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1,2,3,4};
            Util.Transform(arr1, Square);
            Util.Transform(arr1, x => x * x * x);
            foreach (var i in arr1)
            {
                Console.WriteLine(i);
            }

        }
        static int Square(int x) => x * x; //委托连接的目标方法

    }

    class Util
    {
        public static void Transform(int[] array, Transformer t) //以委托变量做参数，实现了插件方法
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = t(array[i]);
            }
        }

    }


}
