using System;

namespace EXA
{
    public static class Parameters
    {
        static int OptionalParam(int x, int y, int z = 5, int s = 4)
        // z и s необязательные именованные параметры

        {
            return x + y + z + s;

        }
        public static void  RunParameters()
        {
            int Res;
            Res = OptionalParam(2, 3);
            Console.WriteLine(Res);
            Res = OptionalParam(y: 2, x: 3, s: 10);
            Console.WriteLine(Res);
            //ref
            int x = 10;
            int y = 15;
            RefPar(ref x, y);
            Console.WriteLine(x);
            //out,in
            int xx = 10; //int area; int perim;
            OutPar(xx, 15, out int area, out int perim);
            Console.WriteLine("Площадь - " + area);
            Console.WriteLine("Периметр - " + perim);
        }

        static void RefPar(ref int x, int y)
        {
            x += y;
        }

        static void OutPar(in int xx, int yy, out int area, out int perim)
        {
            //xx = xx + 10; не изменяется, т.к. in - только для чтения
            area = xx * yy;
            perim = (xx + yy) * 2;
        }

    }
}
