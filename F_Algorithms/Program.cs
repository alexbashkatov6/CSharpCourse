namespace F_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IterativeFactorial(3));
            //Console.WriteLine(RecursiveFactorial(3));

            //ListBCL.Run();

            Node<int> first = new Node<int>(5);
            Node<int> second = new Node<int>(1);
            first.Next = second;
            Node<int> third = new Node<int>(3);
            second.Next = third;

            PrintOutLinkedList(first);
        }

        private static void PrintOutLinkedList(Node<int> node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
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
