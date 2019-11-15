using System;
namespace EXA
{
    public class Properties
    {
        public static void RunProperties()
        {
            BAP bap = new BAP();
            Console.WriteLine("Введите курс");
            Student student = new Student();
            student.Year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(student.Year);
            student.M(pAB: bap);
        }
    }
    class Student
    {
        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value < 1)
                    year = 1;
                else if (value > 5)
                    year = 5;
                else year = value;
                Console.WriteLine("Выполнена проверка");
            }
        }
        //public Student()
        //{
        //    Year = year;
        //}
        public void M(PAB pAB)
        {

        }
    }

    public abstract class PAB
    {

    }

    public class BAP : PAB
    {

    }
}
