//using System;
//namespace EXA
//{
//    public class Массивы
//    {
//        static void Main()
//        {
//            var names = new[] { "A", "B", "C" };
//            string[] surnames = { "aa", "bb", "cc" };
//            //
//            int[] im = new int[5];
//            object[] om = new object[im.Length];
//            Array.Copy(im, om, im.Length);
//            //
//            var kids = new[] { new { Name = "AA" }, new { Name = "BB" } };
//            foreach (var kid in kids)
//                Console.WriteLine(kid.Name);

//            int[] numbers = { 1, 2, 3, 4 };
//            int n = numbers[0];
//            numbers[0] = 7;
//            Console.WriteLine(n);

//            int m = numbers[0];
//            Console.WriteLine(m);

//            Console.WriteLine();
//            numbers[0] = 1;
//            foreach (int num in numbers)
//            {
//                Console.WriteLine(num);
//            }
//            Console.WriteLine();

//            for (int numb = 0; numb < numbers.Length; numb++)
//            {
//                Console.WriteLine(numbers[numb]);
//            }
//        }
//    }
//}
