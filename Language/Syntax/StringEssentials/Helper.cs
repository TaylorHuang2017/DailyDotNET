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
    }
}
