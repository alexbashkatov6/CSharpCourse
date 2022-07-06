

namespace D_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Character c = new Character();
            c.Hit(10);
            Console.WriteLine(c.Health);
            //c.Health = -20;

            Calculator calc = new Calculator();
            Console.WriteLine(calc.CalcTriangleSquare(10, 20));
            Console.WriteLine(calc.CalcTriangleSquare(3, 4, 5));
            Console.WriteLine(calc.Average(new int[] { 3, 4, 5}));
            Console.WriteLine(calc.Average2(3, 4, 5));
            Console.WriteLine(calc.CalcTriangleSquare(ab: 3, bc: 4, ac: 5));

            Console.WriteLine(calc.TryDivide(1, 2, out double result));
            Console.WriteLine(result);
            Console.WriteLine(calc.TryDivide(1, 0, out double result2));
            Console.WriteLine(result2);


        }
    }
}
