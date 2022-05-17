using System;

namespace _05._Birthday_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());
            double cakePrice = rent * 0.20;
            double drinksPrice = cakePrice - (cakePrice * 0.45);
            double animatorPrice = rent / 3;
            double budget = rent + cakePrice + drinksPrice + animatorPrice;

            Console.WriteLine(budget);
        }
    }
}
