////using System;
////using System.Reflection;
////using Microsoft.CSharp.RuntimeBinder;
////using System.Linq;

////namespace EXA
////{
////    //класс для демонстрации отражения.
////    //У него есть поле, конструктор, метод, свойство и событие
////    internal sealed class SomeType
////    {
////        private int m_someField;
////        public SomeType(ref int x)
////        {
////            x *= 2;
////        }
////        public override string ToString()
////        {
////            return m_someField.ToString();
////        }
////        public int SomeProp
////        {
////            get { return m_someField; }
////            set
////            {
////                if (value < 1)
////                    throw new ArgumentOutOfRangeException(nameof(value));
////                m_someField = value;
////            }
////        }
////        public event EventHandler SomeEvent;
////        private void NoCompilerWarnings()
////        {
////            SomeEvent.ToString();
////        }
////    }
////    public static class Program
////    {
////        public static void Main()
////        {
////            Type t = typeof(SomeType);
////            BindToMemberThenInvokeTheMember(t);
////            Console.WriteLine();

////            BindToMemberCreateDelegateToMemberThenInvokeTheMember(t);
////            Console.WriteLine();

////            UseDynamicToBindAndInvokeTheMember(t);
////            Console.WriteLine();
////        }

////        private static void BindToMemberThenInvokeTheMember(Type t)
////        {
////            Console.WriteLine("Привязка К Элементу Затем Вызов Элемента");

////            //Создание экземпляра
////            Type ctorArgument = Type.GetType("System.Int32&");
////            //или
////            // typeof(int).MakeByRefType();
////            ConstructorInfo ctor = t.GetTypeInfo().DeclaredConstructors.First(
////                c => c.GetParameters()[0].ParameterType == ctorArgument);
////            object[] args = { 12 };
////            Console.WriteLine("x перед вызовом конструктора: " + args[0]);
////            object obj = ctor.Invoke(args);
////            Console.WriteLine("Type: " + obj.GetType());
////            Console.WriteLine("x после возврата конструктора: " + args[0]);

////            //Чтение и запись в поле
////            FieldInfo fi = obj.GetType().GetTypeInfo().GetDeclaredField("m_someField");
////            fi.SetValue(obj, 33);
////            Console.WriteLine("someField: " + fi.GetValue(obj));

////            //Вызов метода
////            MethodInfo mi = obj.GetType().GetTypeInfo().GetDeclaredMethod("ToString");
////            string s = (string)mi.Invoke(obj, null);
////            Console.WriteLine("ToString: " + s);

////            //Чтение и запись свойства
////            PropertyInfo pi = obj.GetType().GetTypeInfo().GetDeclaredProperty("SomeProp");
////            try
////            {
////                pi.SetValue(obj, 0, null);
////            }
////            catch (TargetInvocationException e)
////            {
////                if (e.InnerException.GetType() != typeof(ArgumentOutOfRangeException)) throw;
////                Console.WriteLine("Property set catch. Отлов установки свойств");
////            }
////            pi.SetValue(obj, 2, null);
////            Console.WriteLine("SomeProp: " + pi.GetValue(obj, null));

////            //добавление и удаление делегата для события
////            EventInfo ei = obj.GetType().GetTypeInfo().GetDeclaredEvent("SomeEvent");
////            EventHandler eh = new EventHandler(EventCallback);
////            ei.AddEventHandler(obj, eh);
////            ei.RemoveEventHandler(obj, eh);
////        }

////        //Добавление метода обратного вызова для события
////        private static void EventCallback(object sender, EventArgs e) { }

////        private static void BindToMemberCreateDelegateToMemberThenInvokeTheMember(Type t)
////        {
////            Console.WriteLine("Привязка К Члену Создание Делегата К Члену Затем Вызовите Член");

////            //Создание экземпляра(нельзя создать делегата для конструктора)
////            object[] args = { 12 }; //Аргументы конструктора
////            Console.WriteLine("x перед вызовом конструктора: " + args[0]);
////            object obj = Activator.CreateInstance(t, args);
////            Console.WriteLine("Type: " + obj.GetType());
////            Console.WriteLine("x после возврата конструктора: " + args[0]);
////            //нельзя создать делегата для поля

////            //вызов поля
////            MethodInfo mi = obj.GetType().GetTypeInfo().GetDeclaredMethod("ToString");
////            var toString = mi.CreateDelegate<Func<string>>(obj);
////            string s = toString();
////            Console.WriteLine("ToString: " + s);

////            //чтение и запись свойства
////            PropertyInfo pi = obj.GetType().GetTypeInfo().GetDeclaredProperty("SomeProp");
////            var setSomeProp = pi.SetMethod.CreateDelegate<Action<int>>(obj);
////            try
////            {
////                setSomeProp(0);
////            }
////            catch (ArgumentOutOfRangeException)
////            {
////                Console.WriteLine("Отлов установки свойств");
////            }

////            setSomeProp(2);
////            var getSomeProp = pi.GetMethod.CreateDelegate<Func<int>>(obj);
////            Console.WriteLine("SomeProp: " + getSomeProp());

////            //Добавление и удаление делегата для события
////            EventInfo ei = obj.GetType().GetTypeInfo().GetDeclaredEvent("SomeEvent");
////            var addSomeEvent = ei.AddMethod.CreateDelegate<Action<EventHandler>>(obj);
////            addSomeEvent(EventCallback);
////            var removeSomeEvent = ei.RemoveMethod.CreateDelegate<Action<EventHandler>>(obj);
////            removeSomeEvent(EventCallback);
////        }

////        private static void UseDynamicToBindAndInvokeTheMember(Type t)
////        {
////            Console.WriteLine("Использование Динамической Привязки И Вызова Членов");

////            //создание экземпляра (dynamic нельзя использовать для вызова конструктора)
////            object[] args = { 12 };//аргументы конструктора
////            Console.WriteLine("x перед вызовом конструктора: " + args[0]);
////            dynamic obj = Activator.CreateInstance(t, args);
////            Console.WriteLine("Type: " + obj.GetType().ToString());
////            Console.WriteLine("x после возврата конструктора: " + args[0]);

////            //чтение и запись поля
////            try
////            {
////                obj.m_someField = 5;
////                int v = (int)obj.m_someField;
////                Console.WriteLine("someField: " + v);
////            }
////            catch(RuntimeBinderException e)
////            {
////                //получает управление, потому что поле является приватным
////                Console.WriteLine("Не удалось получить доступ к полю: " + e.Message);
////            }

////            //вызов метода
////            string s = (string)obj.ToString();
////            Console.WriteLine("ToString: " + s);

////            //чтение и запись свойства
////            try
////            {
////                obj.SomeProp = 0;
////            }
////            catch(ArgumentOutOfRangeException)
////            {
////                Console.WriteLine("Отлов установки свойств");
////            }
////            obj.SomeProp = 2;
////            int val = (int)obj.SomeProp;
////            Console.WriteLine("SomeProp: " + val);

////            //Добавление и удаление делегата для события
////            obj.SomeEvent += new EventHandler(EventCallback);
////            obj.SomeEvent = new EventHandler(EventCallback);
////        }
////    }

////    internal static class ReflectionExtensions
////    {
////        //метод расширения, упрощающий синтаксис создания делегата
////        public static TDelegate CreateDelegate<TDelegate>(this MethodInfo mi, Object target = null)
////        {
////            return (TDelegate)(object)mi.CreateDelegate(typeof(TDelegate), target);
////        }
////    }
////}

//using System;
//using System.Reflection;
//using System.Collections.Generic;

//public sealed class Program
//{
//    private const BindingFlags c_bf = BindingFlags.FlattenHierarchy |
//        BindingFlags.Instance |
//        BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

//    public static void Main()
//    {
//        //выводим размер кучи до отражения
//        Console.WriteLine("Before doing anything");

//        //Создаем кэш методов MethodInfo для всех методов из MSCorlib.dll
//        List<MethodBase> methodInfos = new List<MethodBase>();
//        foreach(Type t in typeof(object).Assembly.GetExportedTypes())
//        {
//            //игнорируем обобщенные типы
//            if (t.IsGenericTypeDefinition) continue;

//            MethodBase[] mb = t.GetMethods(c_bf);
//            methodInfos.AddRange(mb);
//        }
//        //Выводим количество методов и размер кучи после привязки всех методов
//        Console.WriteLine("# of methods = {0:N0}", methodInfos.Count);
//        Console.WriteLine("After building cache of MethodInfo objects");

//        //Создаем кэш дескрипторов RuntimeMethodHandles
//        //для всех объектов MethodInfo
//        List<RuntimeMethodHandle> methodHandles = methodInfos.ConvertAll(mb => mb.MethodHandle);

//        Console.WriteLine("Holding MethodInfo and RuntimeMethodHandle cache");
//        GC.KeepAlive(methodInfos); //запрещаем уборку мусора в кэше

//        methodInfos = null;//разрешаем уборку мусора в кэше
//        Console.WriteLine("After freeing MethodInfo objects");

//        methodInfos = methodHandles.ConvertAll(MethodBase.GetMethodFromHandle);
//        Console.WriteLine("Size of heap after re - creating MethodInfo objects");
//        GC.KeepAlive(methodHandles);//запрещаем уборку мусора в кэше
//        GC.KeepAlive(methodInfos);//запрещаем уборку мусора в кэше

//        methodHandles = null;//разрешаем уборку мусора в кэше
//        methodInfos = null;//разрешаем уборку мусора в кэше
//        Console.WriteLine("After freeing MethodInfos and RuntimeMethodHandles");
//    }
//}