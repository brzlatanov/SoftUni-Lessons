using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(", ");

            Dictionary<string, Dictionary<string, double>> shopDict = new Dictionary<string, Dictionary<string, double>>();

            while (command[0] != "Revision")
            {
                if (shopDict.ContainsKey(command[0]))
                {
                    shopDict[command[0]].Add(command[1], double.Parse(command[2]));
                }
                else
                {
                    shopDict.Add(command[0], new Dictionary<string, double>());
                    shopDict[command[0]].Add(command[1], double.Parse(command[2]));
                }

                command = Console.ReadLine().Split(", "); ;
            }

            foreach (var shop in shopDict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var shopDetail in shop.Value)
                {
                    Console.WriteLine($"Product: {shopDetail.Key}, Price: {shopDetail.Value}");
                }
            }
        }
    }
}
