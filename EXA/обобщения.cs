using System;
namespace EXA
{
    public class обобщения
    {
        static void Main()
        {
            var bed = new IBed();
            GenMethod<IBed> genMethod = new GenMethod<IBed>
            {
                Sleep = bed
            };

            genMethod.Go<string>(bed); 
            
        }
    }

    class IBed
    {
        public void TimeToSleep()
        {
            Console.WriteLine("Спатки пора");
        }
    }

    class GenMethod<T> where T : IBed
    {
        public T Sleep;
        public T1 Go<T1>(T1 a)
        {
            return a;
        }
        public void Go<T1>(IBed b)
        {

            Console.WriteLine("Спи давай");
        }
    }
}
