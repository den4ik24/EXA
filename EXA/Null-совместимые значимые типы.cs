//using System;
//namespace EXA
//{
//    public class Null_совместимые_значимые_типы
//    {
//        public static void Main()
//        {
//            int? x = 5;
//            int? y = null;
//            x.GetHashCode();

//            Console.WriteLine($"x: HasValue = {x.HasValue}, Value = {x.Value}");
//            Console.WriteLine($"y: HasValue = {y.HasValue}, Value = {y.GetValueOrDefault()}");
//        }

//        public override int GetHashCode()
//        {
//            return base.GetHashCode();
//        }
//    }
//}
