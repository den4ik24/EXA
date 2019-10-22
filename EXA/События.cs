using System;
namespace EXA
{
    public class События
    {
        static void Main()
        {
            var counter = new Counter();
            var message = new Message();

            counter.MyEvent1 += message.Method_Message_1;
            counter.MyEvent2 += message.Method_Message_2;

            counter.Count();
        }

    }

    class Counter
    {
        public event EventHandler<EventArgs> MyEvent1;
        public event EventHandler<EventArgs> MyEvent2;
        public void Count()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 66)
                {
                    var args = new EventArgs();
                    OnMyInvoke1(args);
                }

                if (i == 88)
                {
                    var args = new EventArgs();
                    OnMyInvoke2(args);
                }
            }
        }

        protected virtual void OnMyInvoke1(EventArgs e)
        {
            MyEvent1?.Invoke(this, e);
        }

        protected virtual void OnMyInvoke2(EventArgs e)
        {
            MyEvent2?.Invoke(this, e);
        }
    }

    class Message
    {
        public void Method_Message_1(object sender, EventArgs e)
        {
            Console.WriteLine("Чего там, уже пора?");
        }
    
        public void Method_Message_2(object sender, EventArgs e)
        {
            Console.WriteLine("Капец, чо так долго ?");
        }
    }
}
