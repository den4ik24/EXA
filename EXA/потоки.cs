using System;
using System.Threading;

namespace EXA
{
    public class потоки
    {
        public static void Main()
        {
            Thread t = new Thread(Worker);
            //t.IsBackground = true;
            t.Start();
            Console.WriteLine("Возврат из Main");
        }

        private static void Worker()
        {
            Thread.Sleep(10000);
            Console.WriteLine("Возврат из Worker");
        }
    }
}
