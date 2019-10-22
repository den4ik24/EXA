//using System;
//namespace EXA
//{
//    class TimePeriod
//{
//   private double _seconds;

//        static TimePeriod()
//        {

//        }

//   public double Hours
//   {
//       get { return _seconds / 3600; }
//       set { 
//          if (value < 0 || value > 24)
//             throw new ArgumentOutOfRangeException(
//                   $"{nameof(value)} must be between 0 and 24.");

//          _seconds = value * 3600; 
//       }
//   }
//}

//class Program
//{
//   static void Main()
//   {
//       TimePeriod t = new TimePeriod();
//            TimePeriod TP = new TimePeriod();
//            typeof (TimePeriod).
//       // The property assignment causes the 'set' accessor to be called.
//       t.Hours = 24;

//       // Retrieving the property causes the 'get' accessor to be called.
//       Console.WriteLine($"Time in hours: {t.Hours}");
//   }
//}
//}
