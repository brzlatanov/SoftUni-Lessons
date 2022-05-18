using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            Console.WriteLine(CalculatePrice(product, quantity));
        }

        private static string CalculatePrice(string product, double quantity)
        {
            double price = 0;

            if (product == "water")
            {
                price = 1.00;
            }
            else if (product == "coffee")
            {
                price = 1.50;
            }
            else if (product == "coke")
            {
                price = 1.40;
            }
            else if (product == "snacks")
            {
                price = 2.00;
            }

            double finalPrice = price * quantity;

            finalPrice.ToString();

            return $"{finalPrice:f2}";
        }
    }
}
