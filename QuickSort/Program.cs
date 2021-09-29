using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = {2, 5, 6, 3, 1, 9, 8};

            foreach (var item in list)
            {
                Console.Write($" {item}");
            }

            QuickSort quicksort = new QuickSort();

            list = quicksort.Sort(list);

            foreach (var item in list)
            {
                Console.Write($" {item}");
            }

            Console.ReadLine();
        }
    }
}
