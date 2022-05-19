using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).Select(p => p * 1.2M)
                .ToList()
                .ForEach(w => Console.WriteLine($"{w:F2}"));
        }
    }
}
