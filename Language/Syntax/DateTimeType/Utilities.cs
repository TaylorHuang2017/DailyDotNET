using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeType
{
    class Utilities
    {
        /// <summary>
        /// future date after XXX months
        /// </summary>
        /// <param name="current"></param>
        /// <param name="months"></param>
        /// <returns></returns>
        public static DateTimeOffset ExtendContract(DateTimeOffset current, int months)
        {
            var newContractDate = current.AddMonths(months).AddTicks(-1);
            return new DateTimeOffset(newContractDate.Year,
                newContractDate.Month,
                DateTime.DaysInMonth(newContractDate.Year, newContractDate.Month),
                23, 59, 59, current.Offset);
        }

        /// <summary>
        /// How old are you? 
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static int GetAge(DateTimeOffset birthday)
        {
            var today = DateTimeOffset.UtcNow;
            var age = today.Year - birthday.Year;
            if (today.Date.AddYears(-age) < birthday.Date )
            {
                age = age - 1;
            }
            return age;
        }

        /// <summary>
        /// How many days are left until the next birthday
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static int DaysBeforeBirthday(DateTime birthday)
        {
            var today = DateTime.UtcNow.Date;
            var target = new DateTime(today.Year, birthday.Month, 1);
            target = target.AddDays(birthday.Day - 1);

            if (target < today)
            {
                target = new DateTime(today.Year + 1, birthday.Month, 1);
                target = target.AddDays(birthday.Day - 1);
            }

            return (int) (target - today).TotalDays;
        }

        public static bool IsLeapYear(DateTime date)
        {
            return DateTime.IsLeapYear(date.Year);
        }

        public static int DifferenceInDays(DateTime dts, DateTime dte)
        {
            DateTime end = dte; // new DateTime(y,m,d,h,m,s)
            DateTime start = dts;
            TimeSpan ts = end - start;
            return ts.Days;

        }

        /// <summary>
        /// 根据年份判断生肖，也可以用指定的年份除12求余数，余数为0为猴年，依此类推。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetShenXiao(DateTime dt)
        {
            System.Globalization.ChineseLunisolarCalendar chinCaleandar = new System.Globalization.ChineseLunisolarCalendar();
            string TreeYear = "鼠牛虎兔龙蛇马羊猴鸡狗猪";
            int intYear = chinCaleandar.GetSexagenaryYear(dt); // 用于计算与指定日期对应的甲子循环中的一个从1到60的数字
            string Tree = TreeYear.Substring(chinCaleandar.GetTerrestrialBranch(intYear) - 1, 1);//接收一个从1-60的整型参数，返回甲子循环中的一年
            return Tree;
        }
    }
}
