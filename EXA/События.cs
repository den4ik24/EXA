////using System;
////namespace EXA
////{
////    public class События
////    {
////        static void Main()
////        {
////            var counter = new Counter();
////            var message = new Message();

////            counter.MyEvent1 += message.Method_Message_1;
////            counter.MyEvent2 += message.Method_Message_2;

////            counter.Count();
////        }

////    }

////    class Counter
////    {
////        public event EventHandler<EventArgs> MyEvent1;
////        public event EventHandler<EventArgs> MyEvent2;
////        public void Count()
////        {
////            for (int i = 0; i < 100; i++)
////            {
////                if (i == 66)
////                {
////                    var args = new EventArgs();
////                    OnMyInvoke1(args);
////                }

////                if (i == 88)
////                {
////                    var args = new EventArgs();
////                    OnMyInvoke2(args);
////                }
////            }
////        }

////        protected virtual void OnMyInvoke1(EventArgs e)
////        {
////            MyEvent1?.Invoke(this, e);
////        }

////        protected virtual void OnMyInvoke2(EventArgs e)
////        {
////            MyEvent2?.Invoke(this, e);
////        }
////    }

////    class Message
////    {
////        public void Method_Message_1(object sender, EventArgs e)
////        {
////            Console.WriteLine("Чего там, уже пора?");
////        }

////        public void Method_Message_2(object sender, EventArgs e)
////        {
////            Console.WriteLine("Капец, чо так долго ?");
////        }
////    }
////}


//using System;

//namespace EventExample
//{
//    class Program
//    {
//        static void Main()
//        {
//            ClassCounter Counter = new ClassCounter();
//            Handler_I Handler1 = new Handler_I();
//            Handler_II Handler2 = new Handler_II();

//            Counter.OnCount += Handler1.Message;
//            Counter.OnCount += Handler2.Message;
//            //На событие OnCount подписывается обработчик Handler.Message
//            Counter.Count();
//        }
//    }

//    class ClassCounter
//    {
//        public delegate void MethodContainer();
//        //делегат, хранящий в себе ссылку на метод
//        public event MethodContainer OnCount;
//        //событие связываем с делегатом, потом запускаем это событие

//        public void Count()
//        {
//            for (int i = 0; i < 100; i++)
//            {
//                if (i == 71)
//                {
//                    //OnCount();
//                    OnCount?.Invoke();
//                }
//            }
//        }
//    }

//    class Handler_I
//    {
//        public void Message()
//        {
//            Console.WriteLine("Пора действовать, уже 71 !");
//        }
//    }

//    class Handler_II
//    {
//        public void Message()
//        {
//            Console.WriteLine("Точно, пора.");
//        }
//    }
//}
