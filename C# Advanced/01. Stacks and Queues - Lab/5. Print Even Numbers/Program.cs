using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> numberQueue = new Queue<int>(numberArray);

            int numberQueueCount = numberQueue.Where(x => x % 2 == 0).Count();

            Queue<int> finalQueue = new Queue<int>(numberQueue.Where(x => x % 2 == 0));

            Console.WriteLine(string.Join(", ", finalQueue));
        }
    }
}
