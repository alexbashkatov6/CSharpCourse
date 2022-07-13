using System.Diagnostics.CodeAnalysis;

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

            //var stack = new Stack<int>();  // ArrayStack  LinkedStack

            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //stack.Push(4);

            //foreach(int i in stack)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine();
            //Console.WriteLine(stack.Peek());
            //stack.Pop();
            //Console.WriteLine(stack.Peek());

            var customerList = new List<Customer>()
            {
                new Customer {Age=3, Name="Ann"},
                new Customer {Age=16, Name="Bill"},
                new Customer {Age=20, Name="Rose"},
                new Customer {Age=14, Name="Rob"},
                new Customer {Age=28, Name="Bill"},
                new Customer {Age=14, Name="John"},
            };

            var intList = new List<int>() { 1, 4, 2, 7, 5, 9, 12, 3, 2, 1 };

            bool contains = intList.Contains(3);
            bool contains2 = customerList.Contains(new Customer{Age=14, Name = "Rob"}, new CustomersComparer());

        }

        internal class CustomersComparer : IEqualityComparer<Customer>
        {
            public bool Equals(Customer? x, Customer? y)
            {
                return (x.Name == y.Name) && (x.Age == y.Age);
            }

            public int GetHashCode([DisallowNull] Customer obj)
            {
                return obj.GetHashCode();
            }
        }

        private static bool Exists(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    return true;
            }
            return false;
        }

        private static int IndexOf(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    return i;
            }
            return -1;
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
