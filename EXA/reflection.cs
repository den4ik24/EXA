using System;
using System.Reflection;

namespace EXA
{
    public class reflection
    {
        //вариант создания объекта с вызовом конструктора
        //без аргументов (конструктора по умолчанию)

        //int n = 5;
        //public static void Main()
        //{
        //    string className = "App1.Class1";
        //    Type type = Type.GetType(className);
        //    object data = Activator.CreateInstance(type);
        //    Console.WriteLine(Trace1.ObjectFields("data", data));

        //}


        //public static void Main()
        //{
        //    System.Reflection.Assembly info = typeof(int).Assembly;
        //    Console.WriteLine(info);
        //}


        //public static void Main()
        //{
            //Type type = typeof(Welcome);
            //ConstructorInfo constructorInfo = type.GetConstructor(Type.EmptyTypes);
            //if (constructorInfo != null)
            //{
            //    object instance = constructorInfo.Invoke(null);
            //    MethodInfo methodInfo = type.GetMethod("Hello");
            //    Console.WriteLine(methodInfo.Invoke(instance, null));
            //}
        //}
        public static void Main()
        {

            Type type = typeof(Welcome);
           
            object instance = Activator.CreateInstance(type);
                MethodInfo methodInfo = type.GetMethod("Hello");
                Console.WriteLine(methodInfo.Invoke(instance, null));
            
        }

        public class Welcome
        {
            private int number = 777;
            public void Hello()
            {
                //return number + ToAdd;
                Console.WriteLine("Hi" + number);
            }
        }
    }
}
