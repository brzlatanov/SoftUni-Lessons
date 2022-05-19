using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int n = initialInput[0];
            int s = initialInput[1];
            int x = initialInput[2];

            int[] numbersToPush = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> numbers = new Queue<int>();

            Enqueue(n, numbersToPush, numbers);
            Dequeue(s, numbers);
            CheckContent(x, numbers);

        }

        private static void CheckContent(int x, Queue<int> numbers)
        {
            if (numbers.Count > 0)
            {

                if (numbers.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }

            }
            else
            {
                Console.WriteLine("0");
            }
        }
        private static void Dequeue(int s, Queue<int> numbers)
        {
            for (int i = 0; i < s; i++)
            {
                numbers.Dequeue();
            }
        }
        private static void Enqueue(int n, int[] numbersToPush, Queue<int> numbers)
        {
            for (int i = 0; i < n; i++)
            {
                numbers.Enqueue(numbersToPush[i]);
            }
        }
    }
}
