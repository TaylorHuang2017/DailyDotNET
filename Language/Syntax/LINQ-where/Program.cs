using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_where
{
    class Program
    {
        //Customized Where
        static IEnumerable<int> MyWhere1(IEnumerable<int> items, Func<int, bool> f)
        {
            List<int> result = new List<int>();
            foreach (var item in items)
            {
                if (f(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        //Customized Where with yield return
        static IEnumerable<int> MyWhere2(IEnumerable<int> items, Func<int, bool> f)
        {

            foreach (var item in items)
            {
                if (f(item))
                {
                    yield return item;
                }
            }

        }
        static void Main(string[] args)
        {
            int[] num = new int[] {2,44,712,23,96,1 };

            //LINQ
            //IEnumerable<int> numgreaterthanten = num.Where(i => i > 10);

            //MyWhere1
            //IEnumerable<int> numgreaterthanten = MyWhere1(num, i => i > 100) ;

            //MyWhere2
            //IEnumerable<int> numgreaterthanten = MyWhere2(num, i => i > 50);

            //foreach (var item in numgreaterthanten)
            //{
            //    Console.WriteLine(item);
            //}

            //实验数据
            List<Employee> list = new List<Employee>();
            list.Add(new Employee { Id = 1, Name = "jerry", Age = 28, Gender = true, Salary = 5000 });
            list.Add(new Employee { Id = 2, Name = "jim", Age = 33, Gender = true, Salary = 3000 });
            list.Add(new Employee { Id = 3, Name = "lily", Age = 35, Gender = false, Salary = 9000 });
            list.Add(new Employee { Id = 4, Name = "lucy", Age = 16, Gender = false, Salary = 2000 });
            list.Add(new Employee { Id = 5, Name = "kimi", Age = 25, Gender = true, Salary = 1000 });
            list.Add(new Employee { Id = 6, Name = "nancy", Age = 35, Gender = false, Salary = 8000 });
            list.Add(new Employee { Id = 7, Name = "zack", Age = 35, Gender = true, Salary = 8500 });
            list.Add(new Employee { Id = 8, Name = "jack", Age = 33, Gender = true, Salary = 8000 });

            IEnumerable<Employee> list1 = list.Where(e => e.Salary > 2500 && e.Age < 35);
            //foreach (Employee e in list1)
            //{
            //    Console.WriteLine(e.ToString());
            //}            

            //int count1 = list.Count(e => e.Salary > 5000 || e.Age < 30);
            //int count2 = list.Where(e => e.Salary > 5000 || e.Age < 30).Count();

            //bool b1 = list.Any(e => e.Salary > 8000);
            ////Console.WriteLine(list.FirstOrDefault(e => e.Salary > 3000));

            //var items2 = list.OrderBy(e => e.Age);
            ////foreach (var a in items2)
            ////{
            ////    Console.WriteLine(a);
            ////}

            //var items3 = list.Where(e => e.Age >30).OrderBy(e => e.Age).Skip(1).Take(2);
            //foreach (var a in items3)
            //{
            //    Console.WriteLine(a);
            //}

            //var highestSalary = list.Max(e => e.Salary);
            //Console.WriteLine("最高的工资是：" + highestSalary);

            //var avgSalary = list.Where(e => e.Age >= 30).Average(e => e.Salary);
            //Console.WriteLine("年龄大于30岁的平均工资是：" + avgSalary);

            ////select age, max(salary) from table group by age;
            //IEnumerable<IGrouping<int, Employee>> epByAge = list.GroupBy(e => e.Age);
            //foreach (var item in epByAge)
            //{
            //    Console.WriteLine(item.Key);
            //    Console.WriteLine("本组最高工资："+ item.Max(i => i.Salary));
            //    foreach (var e in item)
            //    {
            //        Console.WriteLine(e);
            //    }
            //    Console.WriteLine("-----------------------------------------------------");
            //}

            //IEnumerable<string> itemsNameAge = list.Select(e => e.Name + "," + e.Age);
            //foreach (var i in itemsNameAge)
            //{
            //    Console.WriteLine(i);
            //}

            //var groupsbyage = list.GroupBy(e => e.Age); //key: age, value: multiple employees
            //var items5 = groupsbyage.Select(g => 
            //      new { age = g.Key, maxs = g.Max(e => e.Salary), mins = g.Min(e => e.Salary), count = g.Count() });
            //foreach (var e in items5)
            //{
            //    Console.WriteLine(e.age + "," + e.maxs + "," + e.mins + "," + e.count);
            //}

            //var items = from e in list
            //            where e.Salary > 5000
            //            select new { e.Age, e.Name, sex = e.Gender ? "男" : "女" };
            //foreach (var i in items)
            //{
            //    Console.WriteLine(i);
            //}

            string myFamily = "huangtairanwangleihuangjialexinzhuangjiangchuanlu";
            var items = myFamily.Where(c => char.IsLetter(c)).Select(c => char.ToLower(c)).GroupBy(c=>c).Select(g => new { letter=g.Key, count = g.Count()}).OrderByDescending(g => g.count).Where(g => g.count >2);
            foreach (var c in items)
            {
                Console.WriteLine(c);
            }
            


            string[] strArr = new string[] { "1", "2", "3", "4", "5" };
            //LINQ
            //var pStr = strArr.Skip(1).Take(3).ToArray();
            //Slicer
            var pStr = strArr[1..4];
            foreach (var i in pStr)
            {
                Console.WriteLine(i);
            }



            Console.ReadLine();
        }

        

    }
}
