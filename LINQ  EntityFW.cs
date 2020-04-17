using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            names.Add("Jonh Adam");
            names.Add("Matt");
            names.Add("Dell Dell");
            names.Add("Mike");
            //List<string> r1 = names.Where(n => n.Contains("M")).ToList();
            //var r1 = names.Where(n => n.Contains("M"));
            //foreach (var item in r1)
            //{
            //    Console.WriteLine(item);
            //}
            //Get the first elemen from the result
            var r2 = names.Where(n => n.Length == 4).First();//Firstly (Matt,Mike) secondly =>Matt
            Console.WriteLine(r2);
            List<int> myNumbers = new List<int> { 44,225,6,227,33,378,62};
            var evenNumbers = myNumbers.Where(n=> n% 2 ==0);
            Console.WriteLine("Even numbers");
            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }
            //find Odd numbers but less than 100
            var r4 = myNumbers.Where(n => n % 2 == 1).Where(n => n < 100);
            Console.WriteLine("Odd numbers and less than 100");
            foreach (var item in r4)
            {
                Console.WriteLine(item);
            }
            List<Person> persons = new List<Person>();
            persons.Add(new Person { Name = "BCC DD", Age = 20 });
            persons.Add(new Person {Name="Linda",Age=32 });
            persons.Add(new Person { Name = "Lisa", Age = 22 });
            persons.Add(new Person { Name = "Tomas", Age = 30 });
            persons.Add(new Person { Name = "AABB", Age = 23 });
            var r5 = persons.Where(p => p.Age < 32).OrderBy(p=>p.Age).ThenBy(p=>p.Name.Length);
            Console.WriteLine("All persons less than 32 Order by Age then by length of name");
            foreach (var item in r5)
            {
                Console.WriteLine($"Name {item.Name} and Age {item.Age}");
            }
            var r6 = from p
                     in persons
                     where(p.Name.Length > 4 && p.Age >23)
                     select p.Name;
            Console.WriteLine("LINQ select");
            foreach (var item in r6)
            {
                Console.WriteLine(item);
            }
            var r7 = from p
                     in persons
                     where (p.Name.Length == 4 || p.Name.Length == 5)
                     select new {PName =p.Name, PAge = p.Age, NameLength= p.Name.Length };
            foreach (var item in r7)
            {
                Console.WriteLine($"Name {item.PName} Age {item.PAge} Name' Length {item.NameLength}");
            }
            ProductWarehouseEntities db = new ProductWarehouseEntities();
            //p1 and p2 are the same result
            var p1 = db.Products.Where(p => p.price > 0);
            var p2 = from p in db.Products
                     where p.price > 0
                     select p;
            foreach (var item in p2)
            {
                Console.WriteLine($"{item.name} and {item.price}");
            }
            //var newP1 = new Product {name ="Office 360", price =888 };
            //db.Products.Add(newP1);
            //db.SaveChanges();
            //Console.WriteLine("Insertion done!");
            decimal priceToSearch = 300;
            var r8 = from p in db.Products
                     where p.price > priceToSearch
                     orderby p.price
                     select p;
            //update database
            var updateProduct = db.Products.Where(p=>p.id==1).SingleOrDefault();
            updateProduct.price = 77889;
            db.SaveChanges();

            Console.ReadLine();
        }
    }
}
