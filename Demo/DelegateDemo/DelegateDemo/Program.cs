// See https://aka.ms/new-console-template for more information
using DelegateDemo;

String email = "hello america.com";
bool result = email.isValidEmail();
Console.WriteLine("{0} is valid email: {1}",email,result);

int k = 1;
Console.WriteLine(k.isInRange10_100());

List<int> numbers = new List<int>();
List<String> names = new List<string>();

numbers.Add(2); numbers.Add(6);numbers.Add(19);
names.Add("Alex"); names.Add("Q.Hai"); names.Add("Messi");

foreach (var item in names)
{
    Console.WriteLine(item.ToUpper());
}
foreach (var item in numbers)
{
    Console.WriteLine(item.isInRange10_100());
}


int? k2 = 10;
k2 = null;
Nullable<int> k3 = 19;
int add2Number(int a, int b)
{
    return a + b;
}
int mul2Number(int a, int b)
{
    return a * b;
}


myDel d = add2Number;
Console.WriteLine(d(10, 20)); // output30
d = mul2Number;
Console.WriteLine(d(10, 20)); // output 200
d = delegate (int x, int y)
{
    return x / y;
};
Console.WriteLine(d(10, 2)); // output 5

d = (x, y) =>
{
    return x - y;
};
Console.WriteLine(d(10, 2)); // output 8

Func<int, int, int, long> d2 = (x, y, z) =>
{
    return x * y * z;
};

Console.WriteLine(d2(10, 2,2)); // output 40
Action<String> d3 = x =>
{
    Console.WriteLine(x);
};
d3("hello world");

Action<int,int> d31 = (x, y) =>
{
    Console.WriteLine(x * y);
};

Predicate<int> d4 = (x) =>
{
    return x % 2 == 0;
};

List<int> nums = new List<int>();
for (int i = 0; i < 10; i++)
{
    nums.Add(i);
}
List<int> result2 = nums.FindAll(no => no % 2==0);

DateTime n = new DateTime(2022, 9, 17);
Console.WriteLine(n.isFriday());

delegate int myDel(int x, int y);
//delegate void MyDel2(String msg);
//delegate void MyDel3(int a, int b);
//delegate bool MyDel4(int a);
