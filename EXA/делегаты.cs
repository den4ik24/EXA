using System;
using System.IO;

namespace EXA
{
    class Delegates
    {
        internal delegate void Feedback(int value);

        public static void RunDelegates1()
        {
            StaticDelegateDemo();
            InstanceDelegateDemo();
            ChainDelegateDemo1(new Delegates());
            ChainDelegateDemo2(new Delegates());
        }

        private static void StaticDelegateDemo()
        {
            Console.WriteLine("----- Static Delegate Demo -----");
            Counter(1, 3, null);
            Counter(1, 3, new Feedback(FeedbackToConsole));
            Counter(1, 3, new Feedback(FeedbackToMsgBox));
            Console.WriteLine();
        }

        private static void InstanceDelegateDemo()
        {
            Console.WriteLine("----- Instance Delegate Demo -----");
            var p = new Delegates();
            Counter(1, 3, new Feedback(p.FeedbackToFile));
            Console.WriteLine();
        }

        private static void ChainDelegateDemo1(Delegates p)
        {
            Console.WriteLine("----- Chain Delegate Demo 1 -----");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb2 = new Feedback(FeedbackToMsgBox);
            Feedback fb3 = new Feedback(p.FeedbackToFile);

            Feedback fbChain = null;
            fbChain = (Feedback)Delegate.Combine(fbChain, fb1);
            fbChain = (Feedback)Delegate.Combine(fbChain, fb2);
            fbChain = (Feedback)Delegate.Combine(fbChain, fb3);
            Counter(1, 2, fbChain);

            Console.WriteLine();
            fbChain = (Feedback)Delegate.Remove(fbChain, new Feedback(FeedbackToMsgBox));
            Counter(1, 2, fbChain);
        }

        private static void ChainDelegateDemo2(Delegates p)
        {
            Console.WriteLine("----- Chain Delegate Demo 2 -----");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb2 = new Feedback(FeedbackToMsgBox);
            Feedback fb3 = new Feedback(p.FeedbackToFile);

            Feedback fbChain = null;
            fbChain += fb1;
            fbChain += fb2;
            fbChain += fb3;
            Counter(1, 2, fbChain);

            Console.WriteLine();
            fbChain -= FeedbackToMsgBox;
            Counter(1, 2, fbChain);
        }

        private static void Counter(int from, int to, Feedback fb)
        {
            for (int val = from; val <= to; val++)
            {
                //if (fb != null)
                //    fb(val);
                fb?.Invoke(val);
            }
        }

        private static void FeedbackToConsole(int value)
        {
            Console.WriteLine("Item FeedbackToConsole =" + value);
        }

        private static void FeedbackToMsgBox(int value)
        {
            Console.WriteLine("Item FeedbackToMsgBox =" + value);
        }

        private void FeedbackToFile(int value)
        {
            using StreamWriter sw = new StreamWriter("Status", true);
            sw.WriteLine("Item=" + value);
            Console.WriteLine("Item FeedbackToFile =" + value);
        }

        public static void RunDelegates2()
        {
            ClassCounter Counters = new ClassCounter();
            Handler_I Handler1 = new Handler_I();
            Handler_II Handler2 = new Handler_II();

            Counters.OnCount += Handler1.Message;
            Counters.OnCount += Handler2.Message;
            //На событие OnCount подписывается обработчик Handler.Message
            Counters.Count();
        }
    }

    class ClassCounter
    {
        public delegate void MethodContainer();
        //делегат, хранящий в себе ссылку на метод
        public event MethodContainer OnCount;
        //событие связываем с делегатом, потом запускаем это событие

        public void Count()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 71)
                {
                    //OnCount();
                    OnCount?.Invoke();
                }
            }
        }
    }

    class Handler_I
    {
        public void Message()
        {
            Console.WriteLine("Пора действовать, уже 71 !");
        }
    }

    class Handler_II
    {
        public void Message()
        {
            Console.WriteLine("Точно, пора.");
        }
    }
}

