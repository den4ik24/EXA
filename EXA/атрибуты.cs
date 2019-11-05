using System;
namespace EXA
{
    public class атрибуты
    {
        public static void Main()
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
            foreach (AgeValidationAttribute attr in attrs)
            {
                if (user.Age >= attr.Age) return true;
                return false;
            }
            return true;
        }

        static bool ValidDog(Dog dog)
        {
            Type type = typeof(Dog);
            object[] obj = type.GetCustomAttributes(false);
            foreach (AgeValidationAttribute atr in obj)
            {
                if (dog.Age >= atr.Age) return true;
                return false;
            }
            return true;
        } 
    }
    public class AgeValidationAttribute : Attribute
    {
        public int Age { get; set; }

        public AgeValidationAttribute()
        { }

        public AgeValidationAttribute(int age)
        {
            Age = age;
        }
    }

    [AgeValidation(18)]
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public User(string n, int a)
        {
            Name = n;
            Age = a;
        }
    }

    [AgeValidation(6)]
    public class Dog
    {
        public string NickName { get; set; }
        public int Age { get; set; }
        public Dog(string nn, int a)
        {
            NickName = nn;
            Age = a;
        }
    }
}
