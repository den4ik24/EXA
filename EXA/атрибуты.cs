using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace EXA
{
    public class Attributes
    {

        public static void RunAttributes1()
        {
            User tom = new User("Tom", 35);
            User bob = new User("Bob", 16);


            bool tomIsValid = ValidateUser(tom);    // true
            bool bobIsValid = ValidateUser(bob);    // false

            Console.WriteLine($"Реультат валидации Тома: {tomIsValid}");
            Console.WriteLine($"Реультат валидации Боба: {bobIsValid}");
            Console.WriteLine();

            var Pit = new Dog("Bull", 8);
            var Bolonka = new Dog("Bolonka", 4);

            bool PitIsValid = ValidDog(Pit);
            bool BolonkaIsValid = ValidDog(Bolonka);

            Console.WriteLine($"Bolonka - {BolonkaIsValid}");
            Console.WriteLine($"Pitbull - {PitIsValid}");
        }

        static bool ValidateUser(User user)
        {
            Type t = typeof(User);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (AgeValidation2Attribute attr in attrs)
            {
                if (user.AgeUser >= attr.Age) return true;
                return false;
            }
            return true;
        }

        static bool ValidDog(Dog dog)
        {

            //Type type = typeof(Dog);
            object[] obj = dog.GetType().GetCustomAttributes(true);
            foreach (AgeValidation2Attribute atr in obj)
            {
                if (dog.AgeDog >= atr.Age) return true;
                return false;
            }
            return true;
        }
    }
    public class AgeValidation2Attribute : Attribute
    {
        public int Age { get; set; }

        public AgeValidation2Attribute()
        { }

        public AgeValidation2Attribute(int age)
        {
            Age = age;
        }
    }

    [AgeValidation2(18)]
    public class User
    {
        public string NameUser { get; set; }
        public int AgeUser { get; set; }
        public User(string n, int a)
        {
            NameUser = n;
            AgeUser = a;
        }
    }

    [AgeValidation2(6)]
    public class Dog
    {
        public string NickName { get; set; }
        public int AgeDog { get; set; }
        public Dog(string nn, int a)
        {
            NickName = nn;
            AgeDog = a;
        }
    }
}
