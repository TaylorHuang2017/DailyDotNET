using System;
using System.IO;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowLargeFilesWithLinq(path);
            //ShowLargeFilesWithoutLinq(path);

        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query1 = from file in new DirectoryInfo(path).GetFiles()                  
                        orderby file.Length descending
                        select file;

            var query2 = new DirectoryInfo(path).GetFiles()
                .OrderByDescending(f => f.Length)
                .Take(5);

            foreach (var file in query1.Take(5))
            {
                Console.WriteLine($"{file.Name, -20} : {file.Length, 10:N0}");
            }

            Console.WriteLine("===================================");

            foreach (var file in query2)
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
        }

        //private static void ShowLargeFilesWithoutLinq(string path)
        //{
        //    DirectoryInfo directory = new DirectoryInfo(path);
        //    FileInfo[] files =  directory.GetFiles();
        //    //Array.Sort(files);
        //    foreach (FileInfo file in files)
        //    {
        //        Console.WriteLine($"{file.Name} : {file.Length}");
        //    }
        //}       
    }

    
}
