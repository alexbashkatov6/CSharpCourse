namespace F_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IterativeFactorial(3));
            Console.WriteLine(RecursiveFactorial(3));
        }

        private static int IterativeFactorial(int number)
        {
            if (number == 0)
                return 1;
            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        private static int RecursiveFactorial(int number)
        {
            if (number == 0 || number == 1)
            {
                return 1;
            }
            else
            {
                return number * RecursiveFactorial(number - 1);
            }
        }
    }
}
