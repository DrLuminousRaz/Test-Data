using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT1_8
{
    class Program
    {
        public static object LinearSearch(int[] inputArray, int key, int min, int max)
        {
            for (int x = min; x < max; x++)
            {
                if (key == inputArray[x])
                {
                    return x;
                }
            }
            return "Nil";
        }

        public static object BinarySearchIterative(int[] inputArray, int key, int min, int max)
        {
            while (min <= max)
            {
                int mid = (min + max) /2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return "Nil";
        }
        public static object BinarySearchRecursive(int[] inputArray, int key, int min, int max)
        {
            if (min > max)
            {
                return "Nil";
            }
            else
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    return BinarySearchRecursive(inputArray, key, min, mid - 1);
                }
                else
                {
                    return BinarySearchRecursive(inputArray, key, mid + 1, max);
                }
            }
        }
        static void Main(string[] args)
        {
            for (int Counter = 0; Counter < 100; Counter++)
            {

                Random randSearchValue = new Random();
                int max_size = 10000;
                int[] bigArray = new int[max_size];
                for (int x = 0; x < max_size; x++)
                {
                    bigArray[x] = 10000 - x;
                }
                var s1 = Stopwatch.StartNew();
                for (int testCounter = 0; testCounter < max_size; testCounter++)
                {
                    int target = randSearchValue.Next(0, max_size);
                    int key = Array.BinarySearch<int>(bigArray, target);
                }
                s1.Stop();
                var s2 = Stopwatch.StartNew();
                for (int testCounter = 0; testCounter < max_size; testCounter++)
                {
                    int target = randSearchValue.Next(0, max_size);
                    BinarySearchIterative(bigArray, target, 0, max_size);
                }
                s2.Stop();
                var s3 = Stopwatch.StartNew();
                for (int testCounter = 0; testCounter < max_size; testCounter++)
                {
                    int target = randSearchValue.Next(0, max_size);
                    BinarySearchRecursive(bigArray, target, 0, max_size);
                }
                s3.Stop();
                var s4 = Stopwatch.StartNew();
                for (int testCounter = 0; testCounter < max_size; testCounter++)
                {
                    int target = randSearchValue.Next(0, max_size);
                    LinearSearch(bigArray, target, 0, max_size);
                }
                s4.Stop();
   /*             Console.Write("Using built in Array.BinarySearch : ");
                Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) / max_size).ToString("0.00 ns"));
                Console.Write("Using Iterative Search : ");
                Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) / max_size).ToString("0.00 ns"));
                Console.Write("Using Recursive Search : ");
                Console.WriteLine(((double)(s3.Elapsed.TotalMilliseconds * 1000000) / max_size).ToString("0.00 ns"));
                Console.Write("Using Linear Search : ");
                Console.WriteLine(((double)(s4.Elapsed.TotalMilliseconds * 1000000) / max_size).ToString("0.00 ns"));
                Console.ReadLine(); */
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Temp\outsideVS.txt", true))
                {
                    file.Write(((double)(s1.Elapsed.TotalMilliseconds * 1000000) / max_size).ToString() + ",");
                    file.Write(((double)(s2.Elapsed.TotalMilliseconds * 1000000) / max_size).ToString() + ",");
                    file.Write(((double)(s3.Elapsed.TotalMilliseconds * 1000000) / max_size).ToString() + ",");
                    file.Write(((double)(s4.Elapsed.TotalMilliseconds * 1000000) / max_size).ToString());
                    file.WriteLine();
                }
            }
        }
    }
}
