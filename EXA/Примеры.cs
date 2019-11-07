////////using System;
////////namespace EXA
////////{
////////    public class Примеры
////////    {
////////        static void Main()
////////        {
////////            Param(z: 3, x: 4, y: 5);
////////            var o = new Object();

////////            int P;
////////            int x = 2;
////////            int y = 3;
////////            Ref(ref x, y, ref o);

////////            Out(out x, y);

////////            Person person = new Person() { Name = "AA", Surname = "BB" };

////////           Person [] array = {
////////                new Person { Name = "1" },
////////                new Person { Name = "2" },
////////                new Person { Name = "3" }
////////            };
////////            //анонимный тип
////////            var Pofig = new {Name = "Pofig_Name", Surname = "Pofig_Surname" };
////////            Console.WriteLine(Pofig.Surname);
////////            dynamic user = new { Name = "Tom ", Age = 34 };
////////            MyMethod(user);
////////        }

////////        public static int Param(int x, int y, int z = 2)
////////        {
////////            return (x + y) * z;
////////        }

////////        static void Ref(ref int x, int y, ref object o)
////////        {
////////            var p = new object();
////////            x = x * y;
////////            o = p;
////////        }

////////        static void Out(out int x, int y)
////////        {
////////            x = 3;
////////            y += x;
////////        }
////////        public static void MyMethod(dynamic parameter)
////////        {
////////            Console.WriteLine(parameter.Name + "" + parameter.Age);
////////        }
////////    }

////////    class Person
////////    {
////////        public string Name { get; set; }
////////        public string Surname { get; set; }
////////    }

////////}
////using System;

////class Program
////{
////    private static void Main(string[] args)
////    {
////        int x = 7;
////        int y = 25;
////        Swap<int>(ref x, ref y); // или так Swap(ref x, ref y);
////        Console.WriteLine($"x={x}    y={y}");   // x=25   y=7

////        string s1 = "hello";
////        string s2 = "bye";
////        Swap<string>(ref s1, ref s2); // или так Swap(ref s1, ref s2);
////        Console.WriteLine($"s1={s1}    s2={s2}"); // s1=bye   s2=hello

////        Console.Read();
////    }
////    public static void Swap<T>(ref T x, ref T y)
////    {
////        T temp = x;
////        x = y;
////        y = temp;
////    }
////}


//using System;
//namespace ExtensionMethods
//{
//    class Program
//    {
//        static void Main()
//        {
//            string Q = "q";
//            string Strin = "Hello";

//            char Ch = 'C';
//            int i = Strin.St(Ch);
//            Console.WriteLine(i);
//        }

//    }
//    public static class Str
//    {
//        public static int St(this string s, char c)
//        {
//            Console.WriteLine(s);
//            Console.WriteLine(c);

//            return 8;
//        }
//    }
//}

//using System;

//namespace ConsoleProgram
//{
//    class Program
//    {
//        static void Main()
//        {

//            Func<int, int> retFunc = Factorial;
//            int n1 = GetInt(6, retFunc);
//            Console.WriteLine(n1);

//            int n2 = GetInt(6, x => x * x);
//            Console.WriteLine(n2);
//        }

//        //с обычным делегатом
//        public delegate int MyDelegate(int d);
//        static int GetTInt(int x1, MyDelegate retF)
//        {
//            int result = 0;
//            if (x1 > 0)
//                result = retF(x1);
//            return result;
//        }
//        //аналог с Func
//        static int GetInt(int x1, Func<int,int> retF)
//        {

//            int result = 0;
//            if (x1 > 0)
//                result = retF(x1);
//            return result;
//        }

//        static int Factorial(int x)
//        {
//            int result = 1;
//            for (int i= 1; i<=x; i++)
//            {
//                result *= i;
//            }
//            return result;
//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ConsoleApplication1
//{
//    class Program
//    {
//        static void Main()
//        {
//            var Driver1 = new User
//            { Name = "Name1", Surname = "Surname1", Age = 33, CarID = "ID2" };

//            var Mers = new Car { Id = "ID", Color = "Red" };

//            var drivers = new[]{ Driver1,
//                new User{ Name = "Name2", Surname = "Surname2", Age = 34, CarID = "ID7" },
//                new User{ Name = "Name3", Surname = "Surname3", Age = 35, CarID = "1qw" }};


//            var cars = new[]{Mers,
//                new Car { Id = "ID2", Color = "GREEN" },
//                new Car { Id = "ID3", Color = "BLUE" } };

//            var selectCar = cars.Where(c => c.Id.Equals(Driver1.CarID));
//            var select2car = cars.Join(drivers, c => c.Id, u => u.CarID, (c, u) => new { Driver = u.Name, c.Color });
//            var f = select2car.FirstOrDefault();
//            Console.WriteLine(f.Color + f.Driver);

//            var SC = selectCar.FirstOrDefault();
//            Console.WriteLine(SC);

//        }

//        class User
//        {
//            public string Name { get; set; }
//            public string Surname { get; set; }
//            public int Age { get; set; }
//            public string CarID { get; set; }

//        }

//        class Car
//        {
//            public string Id { get; set; }
//            public string Color { get; set; }
//            public override string ToString()
//            {
//                return Id;
//            }
//        }
//    }
//}


//using System;
//using System.Drawing;

//namespace ConsoleApplication1
//{
//    class Program
//    {
//        static void Main()
//        {
//            Console.WriteLine("Enter the first number");
//            var x = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine($"First number is {x}");
//            Console.WriteLine("Enter the second number");
//            var y = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine($"Second number is {y}");
//            Console.WriteLine();
//            Max(x, y);

//        }
//        public static void Max(int x, int y)
//        {
//            int z;
//            z = (x < y)? y: x;
//            Console.WriteLine($"The biggest number is {z}");

//        }
//    }
//}

//using System;

//namespace IEnumerable
//{
//    class Program
//    {
//        public static void Main()
//        {
//            int Clr = (int)Color.Black;
//            Console.WriteLine(Clr);
//        }
//        public enum Color
//        {
//            White,
//            Red,
//            Green,
//            Blue,
//            Orange,
//            Black
//        }

//    }
   
    
//}
