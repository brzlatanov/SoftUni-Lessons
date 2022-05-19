using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            string[] query = new string[] { };

            for (int i = 0; i < n; i++)
            {
                query = Console.ReadLine().Split();

                if (query[0] == "1")
                {
                    numbers.Push(int.Parse(query[1]));
                }

                if (numbers.Count > 0)
                {
                    if (query[0] == "2")
                    {
                        numbers.Pop();
                    }
                    else if (query[0] == "3")
                    {
                        Console.WriteLine(numbers.Max());
                    }
                    else if (query[0] == "4")
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
