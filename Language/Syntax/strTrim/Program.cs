using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Trim 不能去掉字符串中间位置的空格
namespace TrimInMiddle 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a string with whitespaces: ");
            string myStr = Console.ReadLine();
            char[] p = myStr.ToCharArray();
            StringBuilder sbToShow = new StringBuilder();
            foreach (var chr in p)
            {
                sbToShow.Append(
                    chr != ' ' ? chr.ToString() : string.Empty
                    );
            }
            Console.WriteLine("Converted: " + sbToShow.ToString());
        }
    }
}
