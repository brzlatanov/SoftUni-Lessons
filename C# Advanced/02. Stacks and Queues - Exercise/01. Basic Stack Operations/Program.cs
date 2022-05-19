using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
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

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < numbersToPush.Length; i++)
            {
                numbers.Push(numbersToPush[i]);
            }

            for (int i = 0; i < s; i++)
            {
                numbers.Pop();
            }

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
    }
}
