using System;

namespace EXA
{
    public static class Lambda
    {
        public static void RunLambda()
        {
            //1
            Plus plus = (x, y) => x + y;
            Console.WriteLine(plus(20, 55));
            //2
            Square square = z => z * z;
            Console.WriteLine(square(25));
            //3
            Hi hi = () => Console.WriteLine("Hello");
            hi();
            //4
            int a = 15;
            ChangeHandler ch = (ref int n) => n *= 8;
            ch(ref a);
            Console.WriteLine(a);
            //5
            Hello message = () => Show_Message();
            message();
            //6
            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int result1 = Sum(integers, (x) => x > 5);
            Console.WriteLine(result1);
            int result2 = Sum(integers, (x) => x % 2 == 0);
            Console.WriteLine(result2);
        }
        //1
        delegate int Plus(int x, int y);
        //2
        delegate int Square(int z);
        //3
        delegate void Hi();
        //4
        delegate void ChangeHandler(ref int a);
        //5 выполняют другие методы
        delegate void Hello();
        private static void Show_Message()
        {
            Console.WriteLine("Message");
        }
        //6 лямбда-выражения можно передавать в качестве аргументов 
        //методу для тех параметров, которые представляют делегат
        delegate bool IsEqual(int x);
        private static int Sum(int[] numbers, IsEqual func)
        {
            int result = 0;
            foreach (int i in numbers)
            {
                if (func(i))
                    result += i;
            }
            return result;
        }
    }
}
