

namespace D_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Character c = new Character();
            //c.Hit(10);
            //Console.WriteLine(c.Health);

            //Calculator calc = new Calculator();
            //Console.WriteLine(calc.CalcTriangleSquare(10, 20));
            //Console.WriteLine(calc.CalcTriangleSquare(3, 4, 5));
            //Console.WriteLine(calc.Average(new int[] { 3, 4, 5}));
            //Console.WriteLine(calc.Average2(3, 4, 5));
            //Console.WriteLine(calc.CalcTriangleSquare(ab: 3, bc: 4, ac: 5));

            //Console.WriteLine(calc.TryDivide(1, 2, out double result));
            //Console.WriteLine(result);
            //Console.WriteLine(calc.TryDivide(1, 0, out double result2));
            //Console.WriteLine(result2);

            PointVal a; // same as PointVal a =  new PointVal();
            a.X = 3;
            a.Y = 5;

            PointVal b = a;
            b.X = 7;
            b.Y = 10;

            a.LogValues();
            b.LogValues();

            Console.WriteLine();
            Console.WriteLine();

            PointRef a2 = new PointRef();
            a2.X = 3;
            a2.Y = 5;

            PointRef b2 = a2;
            b2.X = 7;
            b2.Y = 10;

            a2.LogValues();
            b2.LogValues();



        }
    }
}
