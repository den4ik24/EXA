﻿//using System;

//namespace EXA
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //Object obj = new Object();
//            //Boolean b1 = (obj is Object);
////проверяем, является ли переменная person объектом типа Employee(нет)

//            Person person = new Person();

//            //1
//            Employee employee = person as Employee;
//            if(employee == null)
//            {
//                Console.WriteLine("No :-(");
//            }
//            else
//            {
//                Console.WriteLine("Yes :-)");
//            }

//            //2
//            try
//            {
//                employee = (Employee)person;
//                Console.WriteLine("Yes :-)");
//            }
//            catch(InvalidCastException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//            //3
//            if(person is Employee)
//            {
//                employee = (Employee)person;
//                Console.WriteLine("Yes :-)");
//            }
//            else
//            {
//                Console.WriteLine("преобразование недопустимо");
//            }
//        }
//    }
//    class Person { }
//    class Employee : Person { }
//}
