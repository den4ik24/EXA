////using System;
////namespace gen
////{
////    class Program
////    {
////        static void Main()
////        {
////            Account acc1 = new Account(1) { Sum = 4500 };
////            Account acc2 = new Account(2) { Sum = 5000 };
////            Transaction<Account> transaction = new Transaction<Account>
////            {
////                FromAccount = acc1,
////                ToAccount = acc2,
////                Sum = 6900
////            };
////            transaction.Execute();

////        }
////    }

////    class Account
////    {
////        public int Id { get; private set; }
////        public int Sum { get; set; }
////        public Account(int _id)
////        {
////            Id = _id;
////        }
////    }

////    class Transaction<T> where T : Account
////    {
////        public T FromAccount { get; set; }
////        public T ToAccount { get; set; }
////        public int Sum { get; set; }

////        public void Execute()
////        {
////            if (FromAccount.Sum > Sum)
////            {
////                FromAccount.Sum -= Sum;
////                ToAccount.Sum += Sum;
////                Console.WriteLine();

////                Console.WriteLine($"{FromAccount.Id}:{FromAccount.Sum} - {ToAccount.Id}:{ToAccount.Sum}");
////            }
////            else
////            {
////                Console.WriteLine($"нет денег на {FromAccount.Id}");
////            }
////        }
////    }
////}

//using System;
//namespace EXA
//{
//    public class обобщения
//    {
//        static void Main()
//        {
//            var bed = new Bed();
//            GenMethod<IBed> genMethod = new GenMethod<IBed>
//            {
//               //Sleep = genMethod
//            };

//            genMethod.Go(bed);

//        }
//    }

//    class Bed : IBed
//    {

//        public void TimeToSleep()
//        {
//            Console.WriteLine("Спатки пора");
//        }
//    }

//    public interface IBed
//    {
//        void TimeToSleep();

//    }

//    class GenMethod<T> where T : IBed
//    {

//        //public T Sleep;
//        //public T1 Go<T1>(T1 a)
//        //{
//        //    return a;
//        //}
//        public void Go(T b)
//        {
//            Console.WriteLine("Спи давай");
//            //Sleep.TimeToSleep();
//        }
//    }
//}


//using System;
//namespace EXA
//{
//    public class обобщения
//    {
//        static void Main()
//        {
//            AccountFourth<Str> accountStr = new AccountFourth<Str> { };
//            //Type1<TP> tp1 = new Type1<TP>
//            //{

//            //};

//            ////1
//            //Account<string> accountSTRING = new Account<string>();
//            //Account<string> first1 = new AccountFirst<string>();
//            //AccountFirst<string> first2 = new AccountFirst<string>();
//            ////2
//            //AccountSecond accountSecond = new AccountSecond();
//            //Account<string> accountString = new AccountSecond();
//            ////3
//            //AccountThird<string> accountThird = new AccountThird<string>();
//            //Account<int> accountInt = new AccountThird<long>();
//        }

//        //class TP
//        //{
//        //}

//        //class Type1<T> where T : TP
//        //{
//        //}

//        //class Type2<T>: Type1<T> where T : TP
//        //{
//        //}

//        //class Type3<T>: TP
//        //{
//        //}
//        class Str
//        {
//            public Str()
//            {
                
//            }
//        }

//        class Account<T> { }

//        class AccountFirst<T> : Account<T> { }

//        class AccountSecond : Account<string> { }

//        class AccountThird<T> : Account<int> { }

//        class AccountFourth<T> where T : new()
//        {

//        }
//    }
//}
