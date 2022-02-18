using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringEssentials
{
    class Helper
    {
        public static string StrTrim(string s)
        {
            char[] p = s.ToCharArray();
            StringBuilder sbToShow = new StringBuilder();
            foreach (var chr in p)
            {
                sbToShow.Append(
                    chr != ' ' ? chr.ToString() : string.Empty
                    );
            }
            return sbToShow.ToString();
        }

        public static string SplitJoin(string s)
        {
            string[] message = s.Split(" ");
            string[] newMessage = new string[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                char[] letters = message[i].ToCharArray();
                Array.Reverse(letters);
                newMessage[i] = new string(letters);
            }
            return string.Join(" ", newMessage);
        }
    }
}
