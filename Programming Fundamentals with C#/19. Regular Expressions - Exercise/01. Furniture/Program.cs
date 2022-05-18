using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"^>>([A-Za-z]+)<<([0-9]+\.{0,1}[0-9]{0,})!([0-9]+)";

            string input = Console.ReadLine();

            Console.WriteLine("Bought furniture: ");

            decimal totalPrice = 0;

            while (input != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (!match.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }

                string productName = match.Groups[1].Value;
                decimal productPrice = decimal.Parse(match.Groups[2].Value);
                int productCount = int.Parse(match.Groups[3].Value);

                totalPrice += productPrice * productCount;

                Console.WriteLine(productName);

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
