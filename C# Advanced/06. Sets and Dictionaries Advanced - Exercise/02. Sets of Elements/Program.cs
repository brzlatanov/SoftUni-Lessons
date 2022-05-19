using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] length = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            HashSet<int> thirdSet = new HashSet<int>();

            bool setBorder = false;

            for (int i = 0; i < (length[0] + length[1]); i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i == length[0])
                {
                    setBorder = true;
                }

                if (!setBorder)
                {
                    firstSet.Add(number);
                }
                else
                {
                    secondSet.Add(number);
                }
            }

            for (int i = 0; i < firstSet.Count; i++)
            {
                if (secondSet.Contains(firstSet.ElementAt(i)))
                {
                    thirdSet.Add(firstSet.ElementAt(i));
                }
            }

            Console.WriteLine(string.Join(" ", thirdSet));
        }
    }
}
