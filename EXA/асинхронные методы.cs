using System;
using System.Threading.Tasks;

namespace EXA
{
    public static class Asynchronous
    {
        public static void RunAsynchronous()
        {
            FactorialAsync(9);
            FactorialAsync(7);
        }

        static async void FactorialAsync(int n)
        {
            int x = await Task.Run(() => Factorial(n));
            Console.WriteLine($"Факториал = {x}");
        }

        static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i < n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}