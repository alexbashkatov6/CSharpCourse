using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_OOP
{
    public class Calculator
    {

        public bool TryDivide(double divisible, double divisor, out double result)
        {
            result = 0;
            if (divisor == 0)
            {
                return false;
            }
            else
            {
                result = divisible / divisor;
                return true;
            }

        }
        public double Average(int[] numbers)
        {
            int sum = 0;

            foreach(int n in numbers)
            {
                sum += n;
            }
            return (double)sum/ numbers.Length;
        }
        public double Average2(params int[] numbers)
        {
            int sum = 0;

            foreach (int n in numbers)
            {
                sum += n;
            }
            return (double)sum / numbers.Length;
        }
        public double CalcTriangleSquare(double ab, double bc, double ac)
        {
            double p = (ab + bc + ac) / 2;
            double square = Math.Sqrt(p * (p-ab) * (p - bc) * (p - ac));
            return square;
        }
        public double CalcTriangleSquare(double b, double h)
        {
            return 0.5 * b * h;
        }
    }
}
