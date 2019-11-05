//using System;

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
