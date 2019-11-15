using System;
using System.Threading;

namespace EXA
{
    public class Threadings
    {
        public static void RunThreadings()
        {
            Thread t = new Thread(Worker);
            //t.IsBackground = true;
            t.Start();
            Console.WriteLine("Возврат из Main");
        }

        private static void Worker()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Возврат из Worker");
        }
    }
}
