using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Func<int[], int> intFunc = n => (int)n.Min();

            Console.WriteLine(intFunc(input));
        }
    }
}
