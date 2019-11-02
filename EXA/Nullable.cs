//using System;
//namespace EXA
//{
//    public class Nullable
//    {
//        public static void Main()
//        {
//            string s = null;
//            Country country = null;
//            int? age = 45;//nullable от int
//            int x = age ?? 10; // если age = null, то возвращается 10, если != то 45;
//            //System.Nullable<int> age2 = 45;
            
//            double? d = null;
//            d = 3.14;

//            // State? stateNullable = null;//nullable от State
//            State? stateNullable = null;// new State { Name = "Narnia" };
//            if (stateNullable.HasValue == true)
//            {
//                State state = stateNullable.Value;
//                Console.WriteLine(state.Name);
//            }
//            else
//            {
//                Console.WriteLine("stateNullable is equal to null");
//            }
//            //State state = stateNullable.Value;
//            //Console.WriteLine(state.Name);

//        }
//    }

//    struct State
//    {
//        public string Name { get; set; }
//    }
//    class Country
//    {
//        public string Name { get; set; }
//    }
//}
