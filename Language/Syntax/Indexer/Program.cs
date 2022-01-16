using System;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee();
            employee[0] = "Tairan";
            employee[1] = "Huang";
            employee[2] = "Jingmen";
            Console.WriteLine($"{employee[0] } {employee[1] } was born in {employee[2] }");
        }
    }

    class Employee
    {
        public string LastName;
        public string FirstName;
        public string CityOfBirth;
        public string this[int index] // 为Employee类声明了一个索引器，读写string类型的值，3个字段被索引为整数0，1，2
        {
            set
            {
                switch (index)
                {
                    case 0:
                        LastName = value;
                        break;
                    case 1:
                        FirstName = value;
                        break;
                    case 2:
                        CityOfBirth = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("index");
                }
            }

            get
            {
                switch (index)
                {
                    case 0: return LastName;
                    case 1: return FirstName;
                    case 2: return CityOfBirth;
                    default:
                        throw new ArgumentOutOfRangeException("index");
                }
            }
        }
    }
}
