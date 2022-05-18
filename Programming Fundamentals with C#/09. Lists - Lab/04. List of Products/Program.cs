using System;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> numbers1 = new List<string>();

            for (int i = 0; i < n; i++)
            {
                numbers1.Add(Console.ReadLine());
            }

            numbers1.Sort();

            for (int i = 0; i <= numbers1.Count - 1; i++)
            {
                Console.WriteLine($"{i + 1}" + "." + $"{numbers1[i]}");
            }
        }
    }
}
