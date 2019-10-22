using System;
namespace EXA
{
    public class Интерфейсы
    {
        static void Main()
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

        }
    }
     public class Base : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Base's dispose"); 
        }
    }
     public class Derived: Base, IDisposable
    {
        new public void Dispose()
        {
            Console.WriteLine("Derived's dispose");
            //base.Dispose();
        }
    }

}
