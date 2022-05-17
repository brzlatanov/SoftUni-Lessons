using System;

namespace _01._USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double exchange = 1.79549;
            double usd = double.Parse(Console.ReadLine());
            double bgn = usd * exchange;

            Console.WriteLine(bgn);
        }
    }
}
