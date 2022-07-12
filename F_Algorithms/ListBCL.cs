using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Algorithms
{
    internal class ListBCL
    {
        public static void Run()
        {
            List<int> list = new List<int>();
            LogCountAndCapacity(list);
            Console.WriteLine();

            for (int i = 0; i < 16; i++)
            {
                list.Add(i);
                LogCountAndCapacity(list);
            }
            Console.WriteLine();

            for (int i = 10; i > 0; i--)
            {
                list.RemoveAt(i - 1);
                LogCountAndCapacity(list);
            }
            Console.WriteLine();
            list.TrimExcess();
            LogCountAndCapacity(list);
            list.Add(100);
            LogCountAndCapacity(list);
        }

        private static void LogCountAndCapacity(List<int> list)
        {
            Console.WriteLine($"List count = {list.Count}, list capacity = {list.Capacity}");
        }

        public static void ApiMemebers()
        {
            var list = new List<int>() { 1, 0, 5, 3, 4 };
            list.Sort();

            int indexBinSearch = list.BinarySearch(3);
            list.Reverse();

            IReadOnlyCollection<int> readOnlyList = list.AsReadOnly();

            int[] array = list.ToArray();

            var listCustomers = new List<Customer>
            {
                new Customer {BirthDate = new DateTime(1988, 08, 12), Name = "Elias" },
                new Customer {BirthDate = new DateTime(1990, 06, 09), Name = "Marina" },
                new Customer {BirthDate = new DateTime(2015, 06, 09), Name = "Ann" },
            };

            listCustomers.Sort((left, right) =>
            {
                if (left.BirthDate > right.BirthDate)
                    return 1;
                if (right.BirthDate > left.BirthDate)
                    return -1;
                return 0;
            });
        }
    }
}
