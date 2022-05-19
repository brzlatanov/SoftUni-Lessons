using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                numbers.Push(int.Parse(input[i]));
            }

            string[] command = Console.ReadLine().Split();

            while (command[0].ToLower() != "end")
            {
                if (command[0].ToLower() == "add")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }
                else if (command[0].ToLower() == "remove")
                {
                    if (numbers.Count >= int.Parse(command[1]))
                    {
                        for (int i = 0; i < int.Parse(command[1]); i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }

            int finalNumber = 0;
            int numbersCount = numbers.Count;

            for (int i = 0; i < numbersCount; i++)
            {
                finalNumber += numbers.Pop();
            }

            Console.WriteLine($"Sum: {finalNumber}");
        }
    }
}
