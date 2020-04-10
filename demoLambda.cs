using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Employee
    {
        public String Name { get; set; }
    }
    class Manager : Employee
    {
        public int YearOfExperience { get; set; }
    }
    class NumberMustLessThan20Exception : ApplicationException
    {

    }
    class InputNumber
    {
        public static int InputLessThan20()
        { 
            Console.WriteLine("Enter a number: ");
            var number = Convert.ToInt32(Console.ReadLine());
            if (number >= 20)
                throw new NumberMustLessThan20Exception();
            return number;
        }
    }
    static class MyClassAnyThing
    {
        public static bool isValidEmail(this string email)
        {
            if (email.Contains("@"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int GetEmailLength(this string email)
        {
            return email.Length;
        }
    }
    
    class Program
    {
        delegate int DelegatePointer(int a, int b);
        static int Add(int num1,int num2)
        {
            return num1 + num2;
        }
        static int Substract(int num1, int num2)
        {
            return num1 - num2;
        }

        static void Main(string[] args)
        {
            //var e1 = new Employee();
            //var e2 = new Manager();
            //if (e1 is Manager)
            //{
            //    var m = (Manager)e1;
            //    Console.WriteLine("A kind of Employee");
            //}
            //else
            //{
            //    Console.WriteLine("E1 is not a manager!");
            //}
            //var number=0;
            ////Console.WriteLine("Enter a number: ");
            //try
            //{
            //    number = InputNumber.InputLessThan20();
            //    Console.WriteLine($"You have entered {number}");
            //}
            //catch (FormatException e1)
            //{
            //    Console.WriteLine("It is not a valid integer!");
            //    Console.WriteLine($"Error details {e1.Message}");

            //}catch (OverflowException e2)
            //{
            //    Console.WriteLine("The number is too big or too small");
            //    Console.WriteLine($"Error details {e2.Message}");
            //}
            //catch(NumberMustLessThan20Exception e3)
            //{
            //    Console.WriteLine("The number is greater than 20 which is not allowed");
            //}catch(Exception e3)
            //{
            //    Console.WriteLine("Unknown exception!!!!");
            //}
            //var e1 = "myabcgmail.com";
            //Console.WriteLine( e1.isValidEmail());
            //  Console.WriteLine(e1.GetEmailLength());

            //List<int> numbers = new List<int>();
            //numbers.Add(5);

            //List<String> names = new List<string>();
            //names.Add("Pelle");

            //Nullable<int> studentAgeFromDatabase;
            //studentAgeFromDatabase = null;

            //int? salaryFromDatabase;
            //salaryFromDatabase = null;
            //if (salaryFromDatabase == null)
            //{
            //    Console.WriteLine("Salary has not entered from the DB");
            //}


            //C# 1.0
            DelegatePointer pointer = Add;
            Console.WriteLine(pointer(4,5));
            pointer = Substract;
            Console.WriteLine(pointer(6,2));


            //C# 2.0
            pointer = delegate( int a,  int b) { return a * b; };
            Console.WriteLine(pointer(2,5));

            //C# 3.0
            pointer = (x, y) =>
            {
                return x * y * 2;
            };

            //C# 3.5
            Func<int,int,int> add = (x, y) => { return x + y; };
            add(4, 5);//> output 9

            Func<int,int,int,int> add3 = (a, b, c) => { return a + b + c; };
            add3(3, 5, 6);//14

            //Void; no return
            Action<string> displayMessage = (msg) => { Console.WriteLine(msg.ToUpper()); };
            displayMessage("Hello world");
            //predeciate: method return true or false;and accept 1 parameter
            //Generic, Annoymimous method, delegate, lambda
            Predicate<int> checkEven = (n) =>
            {
                if (n % 2 == 0)
                {
                    return true;
                }
                else
                    return false;
            };

            List<int> numbers = new List<int>();
            numbers.Add(1); numbers.Add(3); numbers.Add(33); numbers.Add(20); numbers.Add(30);

            //C# 2.0
            var numberGreaterThan5 = numbers.FindAll(delegate (int n)
            {
                if (n > 5)
                    return true;
                else
                    return false;
            });

            //C# 3.5
            numberGreaterThan5 = numbers.FindAll(n =>
            {
                if (n > 5)
                    return true;
                else
                    return false;
            });
            Console.WriteLine("Numbers are > 5");
            foreach (var item in numberGreaterThan5)
            {
                Console.WriteLine(item);
            }

            //first number which is even
            var xyz = numbers.FirstOrDefault(n =>
            {
                if (n % 2 == 0)
                    return true;
                else
                    return false;
            });
            numbers.FirstOrDefault()
            Console.WriteLine("First even number " + xyz);


            Console.ReadLine();
        }
    }
}
