using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputRange = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            Func<int, int> add = number => number + 1;
            Func<int, int> multiply = number => number * 2;
            Func<int, int> subtract = number => number - 1;

            inputRange = MathOperations(inputRange, add, multiply, subtract);
        }

        private static List<int> MathOperations(List<int> inputRange, Func<int, int> add, Func<int, int> multiply, Func<int, int> subtract)
        {
            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        inputRange = inputRange.Select(n => add(n)).ToList();
                        break;
                    case "multiply":
                        inputRange = inputRange.Select(n => multiply(n)).ToList();
                        break;
                    case "subtract":
                        inputRange = inputRange.Select(n => subtract(n)).ToList();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", inputRange));
                        break;
                }

                command = Console.ReadLine();
            }

            return inputRange;
        }
    }
}
