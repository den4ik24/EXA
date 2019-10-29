//////using System;

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
           
//        }

//        public struct B:II
//        {

//        }

//        public interface II
//        {

//        }
//    }

//    public static class StCl
//    {
//        public static int St(this A a)
//        {
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
