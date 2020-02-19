using System;

namespace EXA
{
    class Extensions
    {
        public static void RunExtensions()
        {
            A a = new A();
            A aa = new A();
            //B b = new B();
            //var t = (II)b;
            //Console.WriteLine(t);
            //a.SetF();

            var result = aa.GetF();
            Console.WriteLine(result);
            //StCl.St(a);
            int w = a.St();
            Console.WriteLine(w);
        }

        //public struct B : II
        //{

        //}

        //public interface II
        //{

        //}
    }

    public static class StCl
    {
        public static int St(this A n)
        {
            return 6;
        }
    }

    public class A
    {
        public static int F;

        public void SetF()
        {
            F = 5;
        }

        public int GetF()
        {
            return F;
        }
    }
}
