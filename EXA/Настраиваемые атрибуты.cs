//using System;
//using System.Linq;
//using System.Diagnostics;
//using System.Reflection;

//[assembly: CLSCompliant(true)]
//namespace EXA
//{
//    //[DefaultMemberAttribute("Main")]
//    [DebuggerDisplay("ФАМИЛИЯ", Name = "ИМЯ",  Target = typeof(Program))]
//    [Serializable]
//    public class Program
//    {
//        [Conditional("Debug")]
//        [Conditional("Release")]
//        public void DoSomething() { }

//        [CLSCompliant(true)]
//        [STAThread]

//        public static void Main()
//        {

//            //AAA aA = new AAA();
//            //if (aA.GetType().IsDefined(typeof(FlagsAttribute), false))
//            //{

//            //}

//            ShowAttributes(typeof(Program));
//            //Type Tp = typeof(Program);

//            var members = from m in typeof(Program).GetTypeInfo().DeclaredMembers.OfType<MethodBase>()
//                          where m.IsPublic
//                          select m;

//            foreach (MemberInfo member in members)
//            {
//                ShowAttributes(member);
//            }

//        }

//        //public class AAA
//        //{

//        //}

//        private static void ShowAttributes(MemberInfo attributeTarget)
//        {
//            var attributes = attributeTarget.GetCustomAttributes<Attribute>();
//            Console.WriteLine($"Атрибуты применяемые к {attributeTarget.Name} :" +
//                $" {(attributes.Count() == 0 ? "ПУСТО" : string.Empty)}");

//            foreach (Attribute attribute in attributes)
//            {
//                Console.WriteLine(attribute.GetType());
//                if (attribute is DefaultMemberAttribute)
//                    Console.WriteLine($"MemberName = {((DefaultMemberAttribute)attribute).MemberName}");
//                if (attribute is ConditionalAttribute)
//                    Console.WriteLine($"ConditionString = {((ConditionalAttribute)attribute).ConditionString}");

//                if (attribute is CLSCompliantAttribute)
//                    Console.WriteLine($"IsCompliant = { ((CLSCompliantAttribute)attribute).IsCompliant}");

//                DebuggerDisplayAttribute dda = attribute as DebuggerDisplayAttribute;
//                if (dda != null)
//                {
//                    Console.WriteLine($"Фамилия = {dda.Value}, Имя = {dda.Name}, Цель = {dda.Target}");
//                }

//            }

//            Console.WriteLine();
         
//        }
//    }

//}
                    