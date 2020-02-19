using System;
using System.Collections;
using System.Collections.Generic;

namespace EXA
{
    class Interfaces
    {
        public static void RunInterfaces1()
        {
            var b = new Base();
            b.Dispose();
            ((IDisposable)b).Dispose();
            Console.WriteLine("");

            var d = new Derived();
            d.Dispose();
            ((IDisposable)d).Dispose();
            Console.WriteLine();

            b = new Derived();
            b.Dispose();
            ((IDisposable)b).Dispose();
            b.Dispose();
            //IEnumerable<T>;
            //    IEnumerable
        }

        public static void RunInterfaces2()
        {
            Slave slave = new Slave();
            // slave.P
            slave.III();
            IMaster master = slave;
            master.Power();
            //master.Freedom();
            ((IMaster)slave).Freedom();
        }

        public static void RunInterfaces3()
        {
            var n = new Number();

            IComparable<int> cInt32 = n;
            int result = cInt32.CompareTo(5);

            IComparable<string> cString = n;
            result = cString.CompareTo("5");
        }
    }
    public class Base : IDisposable
    {
        public virtual void Dispose()
        {
            Console.WriteLine("Base's dispose");
        }
    }
    public class Derived : Base
    {
        public override void Dispose()
        {
            Console.WriteLine("Derived's dispose");
            //base.Dispose();
        }
    }

     
    public interface IMaster
    {
        public void Power();
        public void Freedom()
        {
            Console.WriteLine("A-A-A-A-a");
        }
    }

    public class Slave : IMaster
    {
        //public void Power()
        // {
        //     Console.WriteLine("I am a power");
        //}

        //явная релизация интерфейсного метода
        //(Explicit Interface Method Implementation, EIMI
        //при явной реализации интерфейсного метода в C#
        //нельзя указывать уровень доступа (открытый или закрытый)

        void IMaster.Power()
        {
            Console.WriteLine("-.-");
        }

        void IMaster.Freedom()
        {
            Console.WriteLine("FREEDOM !");
        }

        public void III()
        {
            ((IMaster)this).Freedom();
        }
    }


    public sealed class Number : IComparable<int>, IComparable<string>
    {
        private int m_val = 5;
        public int CompareTo(int n)
        {
            return m_val.CompareTo(n);
        }
        public int CompareTo(string s)
        {
            return m_val.CompareTo(s);
        }
    }
}
