using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).Reverse().ToList();
            int num = int.Parse(Console.ReadLine());
            Func<int, bool> divisible = n => n % num != 0;

            numbers = numbers.Where(divisible).ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
