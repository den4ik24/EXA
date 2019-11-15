using System;
namespace EXA
{
    public class Nullable
    {
        public static void RunNullable1()
        {
            string s = null;
            Country country = null;
            int? age = 45;//nullable от int
            int x = age ?? 10; // если age = null, то возвращается 10, если != то 45;
            //System.Nullable<int> age2 = 45;

            double? d = null;
            d = 3.14;

            // State? stateNullable = null;//nullable от State
            State? stateNullable = null;// new State { Name = "Narnia" };
            if (stateNullable.HasValue == true)
            {
                State state = stateNullable.Value;
                Console.WriteLine(state.Name);
            }
            else
            {
                Console.WriteLine("stateNullable is equal to null");
            }
            //State state = stateNullable.Value;
            //Console.WriteLine(state.Name);
        }

        public static void RunNullable2()
        {
            int? x = 5;
            int? y = null;
            x.GetHashCode();

            Console.WriteLine($"x: HasValue = {x.HasValue}, Value = {x.Value}");
            Console.WriteLine($"y: HasValue = {y.HasValue}, Value = {y.GetValueOrDefault()}");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    struct State
    {
        public string Name { get; set; }
    }
    class Country
    {
        public string Name { get; set; }
    }
}

//private static void ConversionsAndCasting()
//{
//    //неявное преобразование из типа int в Nullable<int>
//􏰒􏰒 􏱣􏰢􏰱􏰯􏰔􏰦􏰢 􏰜􏰲􏰢􏰦􏰧􏰲􏰕􏰮􏰦􏰯􏰕􏰔􏰗􏰢 􏰗􏰮 􏰛􏰗􏰜􏰕 􏰩􏰌􏰈􏱝􏱞 􏰯 􏰝􏰁􏰃􏰃􏰋􏰂􏰃􏰍􏱇􏰩􏰌􏰈􏱝􏱞􏱊 Int32? a = 5;
//    //неявное преобразование из "null" в Nullable<int>
//􏰒􏰒 􏱣􏰢􏰱􏰯􏰔􏰦􏰢 􏰜􏰲􏰢􏰦􏰧􏰲􏰕􏰮􏰦􏰯􏰕􏰔􏰗􏰢 􏰗􏰮 􏲂􏰌􏰁􏰃􏰃􏲂 􏰯 􏰝􏰁􏰃􏰃􏰋􏰂􏰃􏰍􏱇􏰩􏰌􏰈􏱝􏱞􏱊 Int32? b = null;
//    //явное преобразование Nullable<int> в int
//􏰒􏰒 􏲃􏰯􏰔􏰦􏰢 􏰜􏰲􏰢􏰦􏰧􏰲􏰕􏰮􏰦􏰯􏰕􏰔􏰗􏰢 􏰝􏰁􏰃􏰃􏰋􏰂􏰃􏰍􏱇􏰩􏰌􏰈􏱝􏱞􏱊 􏰯 􏰩􏰌􏰈􏱝􏱞 Int32 c = (Int32) a;
//    //прямое и обратое приведение примитивного типа в null-совместимый тип
//    Double? d = 5; //int->Double? (d содержит 5.0 в виде double)
//    Double? e=b; //int->Double? (e содержит null)
//}


//private static void Operators()
//{
//    Int32? a = 5;
//    Int32? b = null;
//    //Унарные операторы (+ ++ - -- ! ~)
//􏰒􏰒 􏲅􏰔􏰕􏰲􏰔􏰙􏰢 􏰦􏰜􏰢􏰲􏰕􏰛􏰦􏰲􏰙 􏰹􏱯 􏱯􏱯 􏱳 􏱳􏱳 􏱃 􏲣􏰺 a++; // a = 6
//         b = -b; // b = null
//    //Бинарные операторы (+ - * / % & | ^ << >>)
//􏰒􏰒 􏱎􏰗􏰔􏰕􏰲􏰔􏰙􏰢 􏰦􏰜􏰢􏰲􏰕􏰛􏰦􏰲􏰙 􏰹􏱯 􏱳 􏱽 􏰒 􏲥 􏱹 􏲄 􏲟 􏱇􏱇 􏱊􏱊􏰺 a = a + 3; // a = 9
//             b = b * 3; // b = null;
//    //Операторы равенства(== !=)
//        if (a == null) { /* нет */} else { /* да */}
//􏰒􏰒 􏰡􏰜􏰢􏰲􏰕􏰛􏰦􏰲􏰙 􏰲􏰕􏰯􏰢􏰔􏰰􏰛􏰯􏰕 􏰹􏱂􏱂 􏱃􏱂􏰺    if (b == null) { /* да */} else { /* нет */}
//        if (a != b) { /* да */} else { /* нет */}
//    //Операторы сравнения(<> <= >=)
//        if (a < b) { /* нет */} else { /* да */}􏰒􏱽 􏰔􏰢􏰛 􏱽􏰒 􏰠􏰑 􏰒􏱽 􏰔􏰢􏰛 􏱽􏰒 􏰠 􏰍􏰃􏰇􏰍 􏰑 􏰒􏱽 􏰥􏰕 􏱽􏰒 􏰠
//}