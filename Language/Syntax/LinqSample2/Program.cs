using System;
using System.Collections.Generic;

namespace LinqSample2
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] developers = new Employee[]
                {
                    new Employee{ Id = 1, Name = "Scott"},
                    new Employee{ Id = 2, Name = "Chris" }
                };
            List<Employee> sales = new List<Employee>()
            {
                new Employee{ Id = 3, Name = "Alex" }
            };
        }
    }
}
