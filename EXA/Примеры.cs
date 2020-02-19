using System;
namespace EXA
{
    public static class Example
    {
        public static void RunExample1()
        {
            Console.WriteLine("Enter the first number");
            var x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"First number is {x}");
            Console.WriteLine("Enter the second number");
            var y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Second number is {y}");
            Console.WriteLine();
            Max(x, y);

        }
        public static void Max(int x, int y)
        {
            int z;
            z = (x < y) ? y : x;
            Console.WriteLine($"The biggest number is {z}");

        }

        public static void RunExample2()
        {

            Func<int, int> retFunc = Factorial;
            int n1 = GetInt(6, retFunc);
            Console.WriteLine(n1);

            int n2 = GetInt(6, x => x * x);
            Console.WriteLine(n2);
        }

        //с обычным делегатом
        public delegate int MyDelegate(int d);
        static int GetTInt(int x1, MyDelegate retF)
        {
            int result = 0;
            if (x1 > 0)
                result = retF(x1);
            return result;
        }
        //аналог с Func
        static int GetInt(int x1, Func<int, int> retF)
        {

            int result = 0;
            if (x1 > 0)
                result = retF(x1);
            return result;
        }

        static int Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }

        public static void RunExample3()
        {
            string Q = "q";
            string Strin = "Hello";

            char Ch = 'C';
            int i = Strin.St(Ch);
            Console.WriteLine(i);
        }
    }

    public static class Str
    {
        public static int St(this string s, char c)
        {
            Console.WriteLine(s);
            Console.WriteLine(c);

            return 8;
        }
    }

    

   
    //public class A1
    //{
    //    public A1(int a1, int a2, int a3)
    //    {
            
    //    }
    //}

    //public class B1:A1
    //{
    //    public B1(int b1, int b2)
    //    {

    //    }
    //}

    //public class C1:B1
    //{
    //    public C1(int c1)
    //    {
            
    //    }
    //}
}