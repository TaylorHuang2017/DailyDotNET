using System;
using System.Globalization;

namespace DateTimeType
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now; // local time
            DateTimeOffset startTime = DateTimeOffset.Now; // local time with time zone information, recommended

            
            //TimeZone Id
            //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Time Zones
            TimeZoneInfo redmondTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            TimeZoneInfo indiaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            TimeZoneInfo romaniaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. Europe Standard Time");

            Console.WriteLine("------------------Day/Month/Year------------------");
            Console.WriteLine($"Today is {start.ToShortDateString()} {CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(start.DayOfWeek)}");
            Console.WriteLine($"Today is {start.ToString("yyyy年MM月dd日 HH时mm分sss")}");            
            Console.WriteLine($"There are {DateTime.DaysInMonth(start.Year, start.Month)} days in this month. ");
            Console.WriteLine($"Today is the {start.DayOfYear} day of this year. ");
            Console.WriteLine($"Today is {start.DayOfWeek}");
            string rn = Utilities.IsLeapYear(start) ? "a leap year" : "not a leap year";
            Console.WriteLine($"This year is {rn}");



            Console.WriteLine("------------------Current Time------------------");
            Console.WriteLine($"current local time: {start}");
            Console.WriteLine($"current local time and time zone: {startTime}");
            Console.WriteLine($"current time in UTC: {DateTime.UtcNow}");
            Console.WriteLine($"current time in UTC via DateTimeOffset: {DateTimeOffset.UtcNow}");
            Console.WriteLine($"current time via DateTimeOffset: {DateTimeOffset.UtcNow.ToLocalTime()}");
            Console.WriteLine($"current time in Redmond: {TimeZoneInfo.ConvertTime(start, redmondTimeZone)}");
            Console.WriteLine($"current time in Bangalore: {TimeZoneInfo.ConvertTime(start, indiaTimeZone)}");
            Console.WriteLine($"current time in Romania: {TimeZoneInfo.ConvertTime(start, romaniaTimeZone)}");

            Console.WriteLine("------------------Future Time and Time Difference ------------");

            //Console.WriteLine($"current time + Long Date: {start.ToLongDateString()}");
            //Console.WriteLine($"current time + short Date: {start.ToShortDateString()}");
            Console.WriteLine($"14 days from now: {start.AddDays(14)}");
            Console.WriteLine($"24 hours from now: {start.Add(new TimeSpan(24, 0, 0 ))}");
            Console.WriteLine($"Is daylight saving? : {start.IsDaylightSavingTime()}");
            Console.WriteLine($"New contract date after 6 months is {Utilities.ExtendContract(startTime, 6)}");

            Console.WriteLine("------------------Age and Birthday ------------");

            Console.WriteLine($"Your age is {Utilities.GetAge(new DateTimeOffset(new DateTime(1979, 2, 5)))}");
            Console.WriteLine($"You are {Utilities.DifferenceInDays(new DateTime(1979, 2, 5), start) / 365} years old");
            Console.WriteLine($"You are {Utilities.GetShenXiao(new DateTime(1979, 2, 5))}");

            var daysUntilBirthday = Utilities.DaysBeforeBirthday(new DateTime(1979, 2, 5));
            if (daysUntilBirthday == 0)
            {
                Console.WriteLine("Happy Birthday!!!");
            }
            else
                Console.WriteLine($"You are {daysUntilBirthday} days before your birthday");

            
            var startOfSchool = new DateTime(2021, 9, 1);
            Console.WriteLine($"The 19th week is : {startOfSchool.Add(new TimeSpan(19*7, 0, 0, 0))}"); //AddWeeks() implementation

            Console.WriteLine("------------------Execution Time------------");

            DateTime end = DateTime.Now;
            //end - start is a TimeSpan
            Console.WriteLine($"Time elapsed in milli-seconds: {(end - start).TotalMilliseconds}");

            Console.ReadLine();
        }


    }
}
