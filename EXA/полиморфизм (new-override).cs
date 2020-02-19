using System;
namespace EXA
{
    public class NewOverride
    {
        public static void RunNewOverride ()
        {
            Parent par = new Successor();
            par.First();
            par.Second();
        }
    }

    class Parent
    {
        public virtual void First()
        {
            Console.WriteLine("Parent.First");
        }

        public virtual void Second()
        {
            Console.WriteLine("Parent.Second");
        }
    }

    class Successor : Parent
    {
        public override void First()
        {
            Console.WriteLine("Successor.First");
        }

        public new void Second()
        {
            Console.WriteLine("Successor.Second");
        }
    }
}
