using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double result = 0;

            foreach (var currentItem in input)
            {
                char startChar = currentItem[0];
                char endChar = currentItem[currentItem.Length - 1];
                double number = double.Parse(currentItem.Substring(1, currentItem.Length - 2));

                if (char.IsUpper(startChar))
                {
                    number /= startChar - 64;
                }
                else
                {
                    number *= startChar - 96;
                }

                if (char.IsUpper(endChar))
                {
                    number -= endChar - 64;
                }
                else
                {
                    number += endChar - 96;
                }

                result += number;
            }

            Console.WriteLine($"{result:F2}");
        }
    }
}
