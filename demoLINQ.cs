using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    class Employee
    {
        public String Name { get; set; }
        public double Salary { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> doubleNumber = (x) =>
            {
                 return 2 * x;
            };
            Func<double, double, double> multiply = (x, y) =>
              {
                  return x * y;
              };
            Console.WriteLine(doubleNumber(4));
            Console.WriteLine(multiply(4.4,2.0));

            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee { Name = "Papa", Salary = 45.333 });
            empList.Add(new Employee { Name = "Sala", Salary = 32.77 });
            empList.Add(new Employee { Name = "HeyHey", Salary = 6755.55 });
            foreach (var item in empList)
            {
                Console.WriteLine(item.Name + ": " + item.Salary );
            }
            var searchEmp = empList.Where(x => x.Salary < 60);
            Console.WriteLine("Search Employee: ");
            foreach (var item in searchEmp)
            {
                Console.WriteLine(item.Name);
            }
            var sala = empList.SingleOrDefault(e => e.Name.Equals("Sala"));
            Console.WriteLine($"Sala's slary {sala.Salary}");

            //LINQ
            var empSearch = from e in empList
                            where e.Salary < 60.0
                            orderby e.Name
                            select e;
            Console.WriteLine("LINQ");
            foreach (var item in empSearch)
            {
                Console.WriteLine($"Name: {item.Name} and Salary: {item.Salary}");
            }
            var empSearch2 = from e in empList
                             where e.Salary < 60.0
                             orderby e.Name descending
                             select new { EmpName = e.Name,DoubleSalary= e.Salary*2,TripleSalary= e.Salary*3 };
            Console.WriteLine("Search2 ");
            foreach (var item in empSearch2)
            {
                Console.WriteLine($"Name: {item.EmpName} and Double Salary: {item.DoubleSalary}");
            }
            var xxyyzzz = empSearch2.Max(x => x.DoubleSalary);
            var avgSalary = empSearch2.Average(x => x.DoubleSalary);

            Console.WriteLine($"Max Double Salary {xxyyzzz}");
            Console.ReadLine();
        }
    }
}
