﻿//////using System;

//////namespace ConsoleApplication1
//////{
//////    class Program
//////    {
//////        static void Main()
//////        {
//////            Counter c = new Counter(new Random().Next(10));
//////            c.ThresholdReached += c_ThresholdReached;

//////            Console.WriteLine("press 'a' key to increase total");
//////            while (Console.ReadKey(true).KeyChar == 'a')
//////            {
//////                Console.WriteLine("adding one");
//////                c.Add(1);
//////            }
//////        }

//////        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
//////        {
//////            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
//////            Environment.Exit(0);
//////        }
//////    }

//////    class Counter
//////    {
//////        private int threshold;
//////        private int total;

//////        public Counter(int passedThreshold)
//////        {
//////            threshold = passedThreshold;
//////        }

//////        public void Add(int x)
//////        {
//////            total += x;
//////            if (total >= threshold)
//////            {
//////                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
//////                args.Threshold = threshold;
//////                args.TimeReached = DateTime.Now;
//////                OnThresholdReached(args);
//////            }
//////        }

//////        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
//////        {
//////            ThresholdReached?.Invoke(this, e);
//////        }

//////        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
//////    }

//////    public class ThresholdReachedEventArgs : EventArgs
//////    {
//////        public int Threshold { get; set; }
//////        public DateTime TimeReached { get; set; }
//////    }
//////}

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
//using static ConsoleApplication1.Program;

//namespace ConsoleApplication1
//{
//    class Program
//    {
//        static void Main()
//        {

//            A a = new A();
//            A aa = new A();
//            B b = new B();
//            //b = (B)a;
//            //a = (A)b;
//            var t = (II)b;
//            Console.WriteLine(t);
//            a.SetF();

//            var result = aa.GetF();
//            Console.WriteLine(result);
//            StCl.St(a);
//            int w = a.St();
//            Console.WriteLine(w);

//        }

//        public struct B : II
//        {

//        }

//        public interface II
//        {

//        }
//    }

//    public static class StCl
//    {
//        public static int St(this A n)
//        {
//            //Console.WriteLine(a.ToString());
//            return 5;
//        }
//    }

//    public class A
//    {
//        //public static explicit operator A(B v)
//        //{
//        //    throw new NotImplementedException();
//        //}
//        public static int F;


//        public void SetF()
//        {
//            F = 5;
//        }

//        public int GetF()
//        {
//            return F;
//        }

//    }
//}

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

using System;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            var Driver1 = new User
            { Name = "Name1", Surname = "Surname1", Age = 33, CarID = "ID2" };

            var Mers = new Car { Id = "ID", Color = "Red" };

            var drivers = new[]{ Driver1,
                new User{ Name = "Name2", Surname = "Surname2", Age = 34, CarID = "ID7" },
                new User{ Name = "Name3", Surname = "Surname3", Age = 35, CarID = "1qw" }};


            var cars = new[]{Mers,
                new Car { Id = "ID2", Color = "GREEN" },
                new Car { Id = "ID3", Color = "BLUE" } };

            var selectCar = cars.Where(c => c.Id.Equals(Driver1.CarID));
            var select2car = cars.Join(drivers, c => c.Id, u => u.CarID, (c, u) => new { Driver = u.Name, c.Color });
            var f = select2car.FirstOrDefault();
            Console.WriteLine(f.Color + f.Driver);
            //var SC = selectCar.FirstOrDefault();
            //Console.WriteLine(SC);

        }

        class User
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
            public string CarID { get; set; }

        }

        class Car
        {
            public string Id { get; set; }
            public string Color { get; set; }
            public override string ToString()
            {
                return Id;
            }
        }
    }
}
