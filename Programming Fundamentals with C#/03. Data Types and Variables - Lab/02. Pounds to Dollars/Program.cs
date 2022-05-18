using System;

namespace _02._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal result = pounds * 1.31m;
            Console.WriteLine($"{result:F3}");
        }
    }
}
