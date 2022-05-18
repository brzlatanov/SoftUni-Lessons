using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();

            Dictionary<string, double> products = new Dictionary<string, double>();
            Dictionary<string, int> quantityDict = new Dictionary<string, int>();
            Dictionary<string, double> finalList = new Dictionary<string, double>();

            string finalProduct = "";
            double finalPrice = 0;

            while (command[0] != "buy")
            {
                string product = command[0];
                double price = double.Parse(command[1]);
                int quantity = int.Parse(command[2]);

                if (!products.ContainsKey(product) && !quantityDict.ContainsKey(product))
                {
                    products.Add(product, price);
                    quantityDict.Add(product, quantity);
                    products[product] = price * quantityDict[product];
                }
                else if (products.ContainsKey(product) && quantityDict.ContainsKey(product))
                {
                    quantityDict[product] += quantity;
                    products[product] = price * quantityDict[product];
                }

                command = Console.ReadLine().Split();
            }

            foreach (var productz in products)
            {
                Console.WriteLine($"{productz.Key} -> {productz.Value:F2}");
            }
        }
    }
}
