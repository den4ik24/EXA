using System;
namespace EXA
{
    public static class HashCodeEquals
    {
        public static void RunHashCodeEquals()
        {
            AA aa1 = new AA { Name = "AA1", Age = 11 };
            AA aa3 = new AA { Name = "AA1", Age = 11 };

            AA aa2 = new AA { Name = "AA2", Age = 22 };
            AA aa4 = new AA { Name = "AA2", Age = 22 };

            Console.WriteLine($"aa1Name {aa1.Name.GetHashCode()}, aa1Age {aa1.Age.GetHashCode()}");
            Console.WriteLine($"aa3Name {aa3.Name.GetHashCode()}, aa3Age {aa3.Age.GetHashCode()}");
            Console.WriteLine($"aa2Name {aa2.Name.GetHashCode()}, aa2Age {aa2.Age.GetHashCode()}");
            Console.WriteLine($"aa4Name {aa4.Name.GetHashCode()}, aa4Age {aa4.Age.GetHashCode()}");

            bool aa13 = Equals(aa1, aa3);
            Console.WriteLine($"AA 1 & 3 = {aa13}");
            Console.WriteLine($"aa1 {aa1.GetHashCode()}, aa2 {aa3.GetHashCode()}");
            Console.WriteLine();

            bool aa24 = Equals(aa2, aa4);
            Console.WriteLine($"AA 2 & 4 = {aa24}");
            Console.WriteLine($"aa2 {aa2.GetHashCode()}, aa4 {aa4.GetHashCode()}");
            Console.WriteLine();

            string a = "Hello";
            string b = "Hello";
            bool ab = Equals(a, b);
            Console.WriteLine($"a & b = {ab}");

            string c = "Hi";
            string d = "By";
            bool cd = Equals(c, d);
            Console.WriteLine($"c & d = {cd}");

        }
    }
    public class AA
    {
        public string Name;
        public int Age;
        public int Sur;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            AA aa = obj as AA;
            if (aa == null)
                return false;
            return aa.Name == Name && aa.Age == Age;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();

        }
    }
}
