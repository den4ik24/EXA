using System;
namespace EXA
{
    class Generics
    {
        public static void RunGenerics1()
        {
            Account acc1 = new Account(1) { Sum = 4500 };
            Account acc2 = new Account(2) { Sum = 5000 };
            Transaction<Account> transaction = new Transaction<Account>
            {
                FromAccount = acc1,
                ToAccount = acc2,
                Sum = 6900
            };
            transaction.Execute();
        }

        public static void RunGenerics2()
        {
            int x = 7;
            int y = 25;
            Swap(ref x, ref y); // или так Swap<int>(ref x, ref y);
            Console.WriteLine($"x={x}    y={y}");   // x=25   y=7

            string s1 = "hello";
            string s2 = "bye";
            Swap(ref s1, ref s2); // или так Swap<string>(ref s1, ref s2);
            Console.WriteLine($"s1={s1}    s2={s2}"); // s1=bye   s2=hello

            Console.Read();
        }
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
    }

    class Account
    {
        public int Id { get; private set; }
        public int Sum { get; set; }
        public Account(int _id)
        {
            Id = _id;
        }
    }

    class Transaction<T> where T : Account
    {
        public T FromAccount { get; set; }
        public T ToAccount { get; set; }
        public int Sum { get; set; }

        public void Execute()
        {
            if (FromAccount.Sum > Sum)
            {
                FromAccount.Sum -= Sum;
                ToAccount.Sum += Sum;
                Console.WriteLine();

                Console.WriteLine($"{FromAccount.Id}:{FromAccount.Sum} - {ToAccount.Id}:{ToAccount.Sum}");
            }
            else
            {
                Console.WriteLine($"нет денег на {FromAccount.Id}");
            }
        }
    }
}



