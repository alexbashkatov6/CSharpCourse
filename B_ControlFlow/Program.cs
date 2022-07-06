// See https://aka.ms/new-console-template for more information
using System;
using System.Text;

namespace B_ControlFlow
{

    class Program
    {
        static void Main(string[] args)
        {
            CustomStartIndexing();
        }

        static void CustomStartIndexing()
        {
            Array myArray = Array.CreateInstance(typeof(int), new[] { 4 }, new[] { 1 });
            myArray.SetValue(2019, 1);
            myArray.SetValue(2019, 2);
            myArray.SetValue(2019, 3);
            myArray.SetValue(2019, 4);
            // myArray.SetValue(2019, 0);
            // myArray.SetValue(2019, 5);

            Console.WriteLine($"Starting index: {myArray.GetLowerBound(0)}");
            Console.WriteLine($"Ending index: {myArray.GetUpperBound(0)}");
        }

        static void JaggedArrayTest()
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];
            jaggedArray[3] = new int[4];

            for(int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] = i + j;
                    Console.Write($"{jaggedArray[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        static void Array2d()
        {
            int[,] r1 = new int[2, 5] { { 1,2,3,4,5 }, { 6,7,8,9,0 } };
            //  int[,] r2 = { { 1, 2, 3, }, { 6, 7, 8, 9, 0 } };
            for (int i=0; i < r1.GetLength(0); i++)
            {
                for (int j = 0; j < r1.GetLength(1); j++)
                {
                    Console.Write($"{r1[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static void QueueTest()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.WriteLine($"Should print out 1: {queue.Peek()}");
            Console.WriteLine($"Should print out 1: {queue.Dequeue()}");
            Console.WriteLine($"Should print out 2: {queue.Dequeue()}");

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }

        static void StackTest()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine($"Should print out 4: {stack.Peek()}");
            Console.WriteLine($"Should print out 4: {stack.Pop()}");
            Console.WriteLine($"Should print out 3: {stack.Pop()}");
            
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }

        static void DictionaryTest()
        {
            var people = new Dictionary<int, string>();
            people.Add(1, "John");
            people.Add(2, "Bob");
            people.Add(3, "Alice");
            Console.WriteLine(people);

            people = new Dictionary<int, string>()
            {
                { 1, "John" },
                { 2, "Bob" },
                { 3, "Alice" }
            };

            Dictionary<int, string>.KeyCollection keys = people.Keys;
            Dictionary<int, string>.ValueCollection values = people.Values;
            foreach(var pair in people)
            {
                Console.WriteLine(pair);
                Console.WriteLine($"Key: {pair.Key}. Value: {pair.Value}");
            }
            Console.WriteLine();
            Console.WriteLine($"Count={people.Count}");

            bool containsKey = people.ContainsKey(2);
            bool containsValue = people.ContainsValue("John");

            Console.WriteLine($"ContainsKey: {containsKey}. ContainsValue: {containsValue}");

            if (people.TryAdd(2, "Elias"))
            {
                Console.WriteLine("Added successfully");
            }
            else
            {
                Console.WriteLine("Failed to add");
            }

            if(people.TryGetValue(2, out string val))
            {
                Console.WriteLine($"Key 2, Val={val}");
            }
            people.Clear();
        }

        static void ListCollection()
        {
            var intList = new List<int>() { 1, 4, 7, 5, 12, 9 };
            intList.Add(8);
            Console.WriteLine(intList);

            if (intList.Remove(1)) 
            {
                Console.WriteLine("Was found");
            }
            else
            {
                Console.WriteLine("Not found");
            }
            intList.RemoveAt(0);

            intList.Reverse();

            bool contains = intList.Contains(3);

            int min = intList.Min();
            int max = intList.Max();

            Console.WriteLine($"Min={min}. Max={max}.");

            int indexOf = intList.IndexOf(2);
            int lastIndexOf = intList.LastIndexOf(2);

            Console.WriteLine($"indexOf={indexOf}. lastIndexOf={lastIndexOf}.");

            for (int i = 0; i < intList.Count; i++)
            {
                Console.Write($"{intList[i]} ");
            }
        }

        static void ArrayCollection()
        {
            int[] a1;
            a1 = new int[10];

            int[] a2 = new int[5];

            int[] a3 = new int[5] {1, 3, -2, 5, 10};

            int[] a4 = { 1, 3, -2, 5, 10 };

            Array myArray = new int[5];

            Array myArray2 = Array.CreateInstance(typeof(int), 5);
            myArray2.SetValue(12, 0);

            Console.WriteLine(myArray2.GetValue(1));

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int index = Array.BinarySearch(numbers, 7);
            Console.WriteLine(index);

            int[] copy = new int[10];
            Array.Copy(numbers, copy, numbers.Length);
            Console.WriteLine(copy);

            int[] copy2 = new int[10];
            copy.CopyTo(copy2, 0);

            Array.Reverse(copy);
            foreach(var c in copy)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();
            Array.Sort(copy);
            foreach (var c in copy)
            {
                Console.WriteLine(c);
            }
        }

        static void Conditions()
        {
            Console.WriteLine("What's your age?");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("What's your weight in kg?");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("What's your height in meters?");
            double height = double.Parse(Console.ReadLine());

            double bodyMassIndex = weight / (height * height);

            bool isTooLow = bodyMassIndex <= 18.5;
            bool isNormal = bodyMassIndex > 18.5 && bodyMassIndex < 25;
            bool isAboveNormal = bodyMassIndex >= 25 && bodyMassIndex <= 30;
            bool isTooFat = bodyMassIndex > 30;

            bool isFat = isAboveNormal || isTooFat;

            if (isFat)
            {
                Console.WriteLine("You'd better lose some weight");
            }
            else
            {
                Console.WriteLine("You're in a good shape");
            }

            if (isTooLow)
            {
                Console.WriteLine("Not enough weight.");
            }
            else if (isNormal)
            {
                Console.WriteLine("You're OK");
            }
            else if (isAboveNormal)
            {
                Console.WriteLine("Be careful");
            }
            else
            {
                Console.WriteLine("You'd better lose some weight");
            }

            string description = age > 18 ? "You can drink alcohol" : "You're too small";
        }

        static void Cycles()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
            Console.WriteLine();
            foreach (int i in numbers)
            {
                Console.Write(i + " ");
            }
        }

        static void NestedCycles()
        {
            int[] numbers = { 1, -2, 4, -7, 5, 3, 2, -1, -3, 2, 7, -1, -3, 1, 7 };
            for (int i = 0; i < numbers.Length-1; i++)
            {
                for (int j = i+1; j < numbers.Length; j++)
                {
                    int atI = numbers[i];
                    int atJ = numbers[j];
                    if (atI + atJ == 0)
                    {
                        Console.WriteLine($"Pair ({atI});({atJ}). Indexes ({i};{j})");
                    }
                }
            }
            for (int i = 0; i < numbers.Length-2; i++)
            {
                for (int j = i + 1; j < numbers.Length-1; j++)
                {
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        int atI = numbers[i];
                        int atJ = numbers[j];
                        int atK = numbers[k];
                        if (atI + atJ + atK == 0)
                        {
                            Console.WriteLine($"Triplet ({atI});({atJ});({atK}). Indexes ({i};{j};{k})");
                        }
                    }
                }
            }
        }

        static void WhileDoWhile()
        {
            int age = 0;
            while (age < 18)
            {
                Console.WriteLine("What is your age?");
                age = int.Parse(Console.ReadLine());
            }

            do
            {
                Console.WriteLine("What is your age 2 ?");
                age = int.Parse(Console.ReadLine());
            }
            while (age < 18);
        }

        static void Counter()
        {
            int[] numbers = { 1, -2, 4, -7, 5, 3, 2, -1, -3, 2, 7, -1, -3, 1, 7 };
            int counter = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int atI = numbers[i];
                    int atJ = numbers[j];
                    if (atI + atJ == 0)
                    {
                        Console.WriteLine($"Pair ({atI});({atJ}). Indexes ({i};{j})");
                    }
                }
            }
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        int atI = numbers[i];
                        int atJ = numbers[j];
                        int atK = numbers[k];
                        if (atI + atJ + atK == 0)
                        {
                            Console.WriteLine($"Triplet ({atI});({atJ});({atK}). Indexes ({i};{j};{k})");
                            counter++;
                        }
                        if (counter == 3)
                        {
                            break;
                        }
                    }
                    if (counter == 3)
                    {
                        break;
                    }
                }
                if (counter == 3)
                {
                    break;
                }
            }
        }

        static void SwitchCase()
        {
            int weddingYears = int.Parse(Console.ReadLine());

            string name = string.Empty;

            switch (weddingYears)
            {
                case 5:
                    name = "Деревянная свадьба";
                    break;
                case 10:
                    name = "Оловянная свадьба";
                    break;
                case 15:
                    name = "Хрустальная свадьба";
                    break;
                default:
                    name = "Не знаем такого";
                    break;
            }
            Console.WriteLine(name);

        }
    }
}
