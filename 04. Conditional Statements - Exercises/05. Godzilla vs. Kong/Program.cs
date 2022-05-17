using System;

namespace _05._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extras = int.Parse(Console.ReadLine());
            double costumePrice = double.Parse(Console.ReadLine());
            double background = budget * 0.10;
            double extrasPrice = extras * costumePrice;

            if (extras > 150)
            {
                double costumePriceDiscount = costumePrice * 0.10;
                extrasPrice = extras * (costumePrice - costumePriceDiscount);
                if (budget < (background + extrasPrice))
                {

                    double budgetLacks = (background + extrasPrice) - budget;
                    Console.WriteLine("Not enough money!");
                    Console.WriteLine($"Wingard needs {budgetLacks:F2} leva more.");
                }
                else if (budget >= (background + extrasPrice))
                {

                    double budgetExtra = budget - (background + extrasPrice);
                    Console.WriteLine("Action!");
                    Console.WriteLine($"Wingard starts filming with {budgetExtra:F2} leva left.");
                }
            }
            else
            {
                if (budget < (background + extrasPrice))
                {
                    double budgetLacks = (background + extrasPrice) - budget;
                    Console.WriteLine("Not enough money!");
                    Console.WriteLine($"Wingard needs {budgetLacks:F2} leva more.");
                }
                else if (budget >= (background + extrasPrice))
                {
                    double budgetExtra = budget - (background + extrasPrice);
                    Console.WriteLine("Action!");
                    Console.WriteLine($"Wingard starts filming with {budgetExtra:F2} leva left.");
                }
            }
        }
    }
}
