//using System;
//namespace EXA
//{
//    public class Интерфейсы
//    {
//        static void Main()
//        {
//            var b = new Base();
//            b.Dispose();
//            ((IDisposable)b).Dispose();
//            Console.WriteLine("");

//            var d = new Derived();
//            d.Dispose();
//            ((IDisposable)d).Dispose();
//            Console.WriteLine();

//            b = new Derived();
//            b.Dispose();
//            ((IDisposable)b).Dispose();
//            ((Base)b).Dispose();

//        }
//    }
//    public class Base : IDisposable
//    {
//        public virtual void Dispose()
//        {
//            Console.WriteLine("Base's dispose");
//        }
//    }
//    public class Derived : Base
//    {
//        public override void Dispose()
//        {
//            Console.WriteLine("Derived's dispose");
//            //base.Dispose();
//        }
//    }
//}

////343
//using System;
//namespace EXA
//{
//    public class Интерфейсы
//    {
//        static void Main()
//        {
//            var n = new Number();

//            IComparable<int> cInt32 = n;
//            int result = cInt32.CompareTo(5);

//            IComparable<string> cString = n;
//            result = cString.CompareTo("5");
//        }
//    }

//    public sealed class Number : IComparable<int>, IComparable<string>
//    {
//        private int m_val = 5;
//        public int CompareTo(int n)
//        {
//            return m_val.CompareTo(n);
//        }
//        public int CompareTo(string s)
//        {
//            return m_val.CompareTo(s);
//        }
//    }
//}


//using System;
//namespace EXA
//{
//    public class Интерфейсы
//    {
//        static void Main()
//        {
//            Slave slave = new Slave();
//           // slave.P
//            IMaster master = slave;
//            master.Power();
            
//        }

//    }

//    public interface IMaster
//    {
//        public void Power();
        
//    }
     
//    public class Slave : IMaster
//    {
//        //public void Power()
//        // {
//        //     Console.WriteLine("I am a power");
//        //}

//        //явная релизация интерфейсного метода
//        //(Explicit Interface Method Implementation, EIMI
//        //при явной реализации интерфейсного метода в C#
//        //нельзя указывать уровень доступа (открытый или закрытый)

//        void IMaster.Power()
//        {
//            Console.WriteLine("-.-");
//        }
//    }

//}