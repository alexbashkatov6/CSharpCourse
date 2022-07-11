using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Algorithms
{
    internal class Arrays
    {

        private static void ArraysDemo()
        {
            int[] a1;
            a1 = new int[10];
            int[] a2 = new int[5];
            int[] a3 = new int[5] { 1, 3, -2, 5, 10 };
            int[] a4 = { 1, 3, -2, 5, 10 };

            Array my_array = new int[5];
            Array my_array2 = Array.CreateInstance(typeof(int), 5);
            my_array2.SetValue(1, 0);
            Array my_array_1_Based = Array.CreateInstance(typeof(int), new[] { 4 }, new[] { 1 });

            int[,] r1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] r2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            for (int i = 0; i < r2.GetLength(0); i++)
            {
                for (int j = 0; j < r2.GetLength(1); j++)
                {
                    Console.Write($"{r2[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            int[][] jAr = new int[5][];
            jAr[0] = new int[1] { 1 };
            jAr[1] = new int[2] { 1, 2 };
            jAr[2] = new int[2] { 1, 2 };
            jAr[3] = new int[3] { 1, 2, 3 };
            jAr[4] = new int[2] { 1, 2 };

            for (int i = 0; i < jAr.Length; i++)
            {
                for (int j = 0; j < jAr[i].Length; j++)
                {
                    Console.Write($"{jAr[i][j]} ");
                }
                Console.WriteLine();
            }


        }
        private static unsafe void IterateOverArray(int[] array)
        {
            fixed (int* b = array)
            {
                int* p = b;
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(*p);
                    p++;
                }
            }
        }

        private static void ArrayTimeComplexity(object[] array)
        {
            int length = array.Length;
            object elementForFind = new object();

            // access by index O(1)
            Console.WriteLine(array[0]);

            // searching for an element O(n)
            for (int i = 0; i < length; i++)
            {
                if (array[i] == elementForFind)
                {
                    Console.WriteLine("Exists/Found");
                }
            }

            // add to a full array O(n)
            var bigArray = new int[length * 2];
            Array.Copy(array, bigArray, length);
            bigArray[length] = 10;

            // add to the end when there's some space O(1)
            array[length - 1] = 10;

            // O(1)
            array[6] = null;

        }

        private static void ArrayRemoveAt(object[] array, int index)
        {
            var newArray = new object[array.Length - 1];
            Array.Copy(array, 0, newArray, 0, index);
            Array.Copy(array, index + 1, newArray, index, array.Length - 1 - index);
        }
    }
}
