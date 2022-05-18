using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> numbers2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            for (int i = 0; numbers1.Count > 0 && numbers2.Count > 0; i++)
            {
                i = 0;

                if (numbers1[i] > numbers2[i])
                {

                    numbers1.Add(numbers1[i]);
                    numbers1.Add(numbers2[i]);
                    numbers1.RemoveAt(i);
                    numbers2.RemoveAt(i);

                }
                else if (numbers1[i] < numbers2[i])
                {
                    numbers2.Add(numbers2[i]);
                    numbers2.Add(numbers1[i]);
                    numbers2.RemoveAt(i);
                    numbers1.RemoveAt(i);
                }
                else if (numbers1[i] == numbers2[i])
                {
                    numbers1.RemoveAt(i);
                    numbers2.RemoveAt(i);
                }

            }

            if (numbers1.Sum() > numbers2.Sum())
            {
                Console.WriteLine($"First player wins! Sum: {numbers1.Sum()}");
            }
            else if (numbers2.Sum() > numbers1.Sum())
            {
                Console.WriteLine($"Second player wins! Sum: {numbers2.Sum()}");
            }
        }
    }
}
