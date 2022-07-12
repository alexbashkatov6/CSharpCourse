namespace F_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IterativeFactorial(3));
            //Console.WriteLine(RecursiveFactorial(3));

            //ListBCL.Run();

            //Node<int> first = new Node<int>(5);
            //Node<int> second = new Node<int>(1);
            //first.Next = second;
            //Node<int> third = new Node<int>(3);
            //second.Next = third;

            //PrintOutLinkedList(first);

            var stack = new Stack<int>();  // ArrayStack  LinkedStack

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            foreach(int i in stack)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            Console.WriteLine(stack.Peek());
            stack.Pop();
            Console.WriteLine(stack.Peek());
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
