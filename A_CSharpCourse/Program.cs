// See https://aka.ms/new-console-template for more information
using D_OOP;
using System;
using System.Text;

namespace A_CSharpCourse
{

    class Program
    {
        static void Main(string[] args)
        {

            Character c = new Character();
            c.Hit(10);
            //CustomStartIndexing();
        }

        static void DateNTime()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString());
            Console.WriteLine($"It's {now.Date}");  // , {now.Hour}:{now.Minute}

            DateTime my_birth = new DateTime(1992, 12, 10);
            Console.WriteLine(my_birth.ToString());
            DateTime newDt = my_birth.AddDays(1);
            Console.WriteLine(newDt.ToString());

            TimeSpan ts = now - my_birth;
            Console.WriteLine(ts.ToString());
            ts = now.Subtract(my_birth);
            Console.WriteLine(ts.ToString());
            Console.WriteLine(ts.TotalDays);
            Console.WriteLine(ts.Days);
        }

        static void MathExper()
        {
            Console.WriteLine(Math.Abs(-10));
            Console.WriteLine(Math.Sqrt(9));
            Console.WriteLine(Math.Pow(2, 3));
            Console.WriteLine(Math.Pow(9, 0.5));
            Console.WriteLine(Math.Round(1.7));
            Console.WriteLine();
            Console.WriteLine(Math.Round(2.5));
            Console.WriteLine(Math.Round(2.5, MidpointRounding.AwayFromZero));
            Console.WriteLine(Math.Round(2.5, MidpointRounding.ToEven));

            int[] a2 = new int[5];
            int[] a3 = new int[5] { 1, 3, -2, 5, 10 };
            int[] a4 = { 1, 3, -2, 5, 10 };

            int number = a4[4];
            Console.WriteLine(number);
            a4[4] = 1;
            Console.WriteLine(a4[4]);
            Console.WriteLine(a4.Length);

            string s1 = "abcdef";
            char first = s1[0];
            char last = s1[s1.Length-1];
            Console.WriteLine(first);
            Console.WriteLine(last);

        }

        static void Cast() 
        {
            byte b = 3;  // 0000 0011
            int i = b;  // 0000 0000 0000 0000 0000 0000 0000 0011
            long l = b;  // 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0011

            Console.WriteLine(l);
            //b = i;
            b = (byte)i;
            Console.WriteLine(b);

            Console.WriteLine((int)3.1);
            Console.WriteLine((double)3/2);
        }

        static void LocaleTest()
        {
            Console.WriteLine("abcde" == "abcde");
            bool areEqual = string.Equals("abcde", "abcde", StringComparison.Ordinal);
            Console.WriteLine(areEqual);
            
            Console.WriteLine(string.Equals("ßbcde", "ssbcde", StringComparison.Ordinal));
            Console.WriteLine(string.Equals("ßbcde", "ssbcde", StringComparison.InvariantCulture));
            Console.WriteLine(string.Equals("ßbcde", "ssbcde", StringComparison.CurrentCulture));

            Console.WriteLine(int.Parse("23"));

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Blue;

            string my_str = Console.ReadLine();
            Console.WriteLine(my_str);
        }
        
        static void StringFormat()
        {
            string name = "John";
            int age = 30;
            string str1 = string.Format("My name is {0} and I'm {1}", name, age);
            Console.WriteLine(str1);
            string str2 = $"My name is {str1}";
            Console.WriteLine(str2);
            string str3 = $"My name is \n John";
            Console.WriteLine(str3);
            str3 = $"before {Environment.NewLine}after";
            Console.WriteLine(str3);
            str3 = @"lalala\\\/'l;kljk";
            Console.WriteLine(str3);

            //int number = 42;
            //string result = string.Format("{0:d}", number);
            Console.WriteLine(string.Format("{0:d}", 42));
            Console.WriteLine(string.Format("{0:d4}", 42));
            Console.WriteLine(string.Format("{0:f}", 42));
            Console.WriteLine(string.Format("{0:f4}", 42));
            Console.WriteLine(string.Format("{0:f}", 42.3));
            Console.WriteLine(string.Format("{0:f4}", 42.3));
            Console.WriteLine(string.Format("{0:C}", 42.3));
            Console.WriteLine(string.Format("{0:C4}", 42.3));

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine(42.3.ToString("C2"));
        }

        static void StringBuilderDemo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("My ");
            sb.Append("name ");
            sb.AppendLine("!");
            sb.Append("lala ");
            sb.AppendLine(" helo!");
            string str = sb.ToString();
            Console.WriteLine(str);
        }

        static void EmptyStrings()
        {
            string empty = "";
            string whiteSpaced = " ";
            string notEmpty = " b";
            string nullString = null;
            //Console.WriteLine(empty);
            //Console.WriteLine(whiteSpaced);
            //Console.WriteLine(nullString.Contains('a'));

            Console.WriteLine("IsNullOrEmpty");
            bool isNullOrEmpty = string.IsNullOrEmpty(empty);
            Console.WriteLine(isNullOrEmpty);
            isNullOrEmpty = string.IsNullOrEmpty(whiteSpaced);
            Console.WriteLine(isNullOrEmpty);
            isNullOrEmpty = string.IsNullOrEmpty(notEmpty);
            Console.WriteLine(isNullOrEmpty);
            isNullOrEmpty = string.IsNullOrEmpty(nullString);
            Console.WriteLine(isNullOrEmpty);

            Console.WriteLine("IsNullOrWhiteSpace");
            bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(empty);
            Console.WriteLine(isNullOrWhiteSpace);
            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(whiteSpaced);
            Console.WriteLine(isNullOrWhiteSpace);
            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(notEmpty);
            Console.WriteLine(isNullOrWhiteSpace);
            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(nullString);
            Console.WriteLine(isNullOrWhiteSpace);

        }

        static void StringModification()
        {
            string str = string.Empty;
            Console.WriteLine(str);
            string str2 = string.Concat("a", "b", "c");
            Console.WriteLine(str2);
            string nameConcat = string.Join(" ", "My", "name", "is", "Alex", "!");
            Console.WriteLine(nameConcat);
            string nameConcat2 = nameConcat.Insert(0, "by the way, ");
            Console.WriteLine(nameConcat2);
            nameConcat2 = nameConcat2.Remove(5); // after 5-th symbol
            Console.WriteLine(nameConcat2);
            nameConcat2 = nameConcat2.Remove(0, 2);
            Console.WriteLine(nameConcat2);
            string replaced = str2.Replace("b", "z");
            Console.WriteLine(replaced);
            string[] splData = "12;23;34;45".Split(';');
            Console.WriteLine(splData);
            Console.WriteLine(splData[0]);

            char[] chars = nameConcat.ToCharArray();
            Console.WriteLine(chars[0]);

            string lower = nameConcat.ToLower();
            Console.WriteLine(lower);

            string upper = nameConcat.ToUpper();
            Console.WriteLine(upper);

            string john = " my name is john ";
            Console.WriteLine(john.Trim());
        }

        static void StringsQuerying()
        {
            string name = "abracadabra";
            bool containsA = name.Contains('a');
            Console.WriteLine(containsA);

            bool endsWithAbra = name.EndsWith("abra");
            Console.WriteLine(endsWithAbra);

            bool startssWithAbra = name.StartsWith("abra");
            Console.WriteLine(startssWithAbra);

            int indexOfA = name.IndexOf('a');
            Console.WriteLine(indexOfA);

            indexOfA = name.IndexOf('a', 1);
            Console.WriteLine(indexOfA);
            
            int liOfR = name.LastIndexOf("r");
            Console.WriteLine(liOfR);

            Console.WriteLine(name.Length);

            string substr = name.Substring(5);
            Console.WriteLine(substr);

            substr = name.Substring(0, 3);
            Console.WriteLine(substr);
        }

        static void Overflow()
        {
            uint x = uint.MaxValue;
            Console.WriteLine(x);
            x = x + 1;
            Console.WriteLine(x);
            x = x - 1;
            Console.WriteLine(x);
        }

        static void Literals()
        {
            int x = 0b11;
            int y = 0b1001;
            int m = 0b1000_1001;

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(m);

            x = 0x1F;

            Console.WriteLine(x);

            Console.WriteLine();

            Console.WriteLine(4.5e2);
            Console.WriteLine(3.1E-1);

            Console.WriteLine('\x78');
            Console.WriteLine('\u0420');
        }

        static void Variables()
        {
            int x = -1;
            int y;
            y = 2;
            Int32 x1;
            uint z = 0;
            float f = 1.1f;
            double d = 2.3;

            int x2 = 0;
            int x3 = new int();

            var a = 1;
            var b = 1.2;

            var dict = new Dictionary<int, string>();

            //var v; - ERROR

            decimal money = 3.0m;

            char character = 'A';
            string name = "Lala";

            bool canDrive = true;
            //object obj = 1; - NOT GOOD

            Console.WriteLine(a);
            Console.WriteLine(name);

            int @my_int = 10;
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

            for (int i = 0; i < jaggedArray.Length; i++)
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
            int[,] r1 = new int[2, 5] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 0 } };
            //  int[,] r2 = { { 1, 2, 3, }, { 6, 7, 8, 9, 0 } };
            for (int i = 0; i < r1.GetLength(0); i++)
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
            foreach (var pair in people)
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

            if (people.TryGetValue(2, out string val))
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

            int[] a3 = new int[5] { 1, 3, -2, 5, 10 };

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
            foreach (var c in copy)
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
    }
}
