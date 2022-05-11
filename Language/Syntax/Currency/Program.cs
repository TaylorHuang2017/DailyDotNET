using System;
using System.Globalization;

namespace Currency
{
    class Program
    {
        static void Main(string[] args)
        {
            //Default currency format
            decimal price = 1234.56m;
            string formatted = string.Format("{0:C}", price);
            Console.WriteLine(formatted);

            //Custom currency format
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            NumberFormatInfo format = culture.NumberFormat;
            format.CurrencyGroupSeparator = " ";
            string customFormatted = price.ToString("C", format);
            Console.WriteLine(customFormatted);
            Console.ReadLine();
        }
    }
}
