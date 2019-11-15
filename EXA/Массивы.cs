using System;
using System.Collections;
using System.Linq;

namespace EXA
{
    public static class Arrays
    {
        public static void RunArrays1()
        {
            Param(z: 3, x: 4, y: 5);
            var o = new object();

            int P;
            int x = 2;
            int y = 3;
            Ref(ref x, y, ref o);

            Out(out x, y);

            Person person = new Person() { Name = "AA", Surname = "BB" };

            Person[] array = {
                new Person { Name = "1" },
                new Person { Name = "2" },
                new Person { Name = "3" }
            };
            //анонимный тип
            var Pofig = new { Name = "Pofig_Name", Surname = "Pofig_Surname" };
            Console.WriteLine(Pofig.Surname);
            dynamic user = new { Name = "Tom ", Age = 34 };
            MyMethod(user);
        }

        public static void RunArrays2()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Console.WriteLine(array[2]);

            int[,] array2D = { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 0 } };
            Console.WriteLine(array2D[0, 3]);

            int[,,] array3D = { { { 1, 2, 3 }, { 4, 5, 6 } }, { { 7, 8, 9 }, { 10, 11, 12 } } };
            Console.WriteLine(array3D[0, 1, 1]);

            var week = new Week();
            foreach (var day in week)
            {
                Console.WriteLine(day);
            }

            foreach (var day in week)
            {
                Console.WriteLine(day);
            }
        }

        public static void RunArrays3()
        {
            var Driver1 = new UserCar
            { Name = "Name1", Surname = "Surname1", Age = 33, CarID = "ID2" };
            var Mers = new Car { Id = "ID", Color = "Red" };

            var drivers = new[]{ Driver1,
                new UserCar{ Name = "Name2", Surname = "Surname2", Age = 34, CarID = "ID7" },
                new UserCar{ Name = "Name3", Surname = "Surname3", Age = 35, CarID = "1qw" }};


            var cars = new[]{Mers,
                new Car { Id = "ID2", Color = "GREEN" },
                new Car { Id = "ID3", Color = "BLUE" } };


            var selectCar = cars.Where(c => c.Id.Equals(Driver1.CarID));
            var select2car = cars.Join(drivers, c => c.Id, u => u.CarID, (c, u) => new { Driver = u.Name, c.Color });
            var f = select2car.FirstOrDefault();
            Console.WriteLine(f.Color + f.Driver);

            var SC = selectCar.FirstOrDefault();
            Console.WriteLine(SC);

        }

        public static int Param(int x, int y, int z = 2)
        {
            return (x + y) * z;
        }

        static void Ref(ref int x, int y, ref object o)
        {
            var p = new object();
            x = x * y;
            o = p;
        }

        static void Out(out int x, int y)
        {
            x = 3;
            y += x;
        }
        public static void MyMethod(dynamic parameter)
        {
            Console.WriteLine(parameter.Name + "" + parameter.Age);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    class Week : IEnumerable, IEnumerator
    {
        string[] days = {"Monday", "Tuesday", "Wednesday", "Thursday",
                         "Friday", "Saturday", "Sunday"};
        int position = -1;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public object Current
        {
            get
            {

                return days[position];
            }
        }
        public bool MoveNext()
        {
            if (position == days.Length - 1)
            {
                //Reset();
                return false;
            }
            position++;
            return true;
        }
        public void Reset()
        {
            position = -1;
        }
    }

    class UserCar
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string CarID { get; set; }

    }

    class Car
    {
        public string Id { get; set; }
        public string Color { get; set; }
    }

}
