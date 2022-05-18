using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string totalPattern = @"^%(?<name>[A-Z][a-z]+)%([^\|$%\.[0-9]*)<(?<product>\w+)>([^\|$%\.[0-9]*)\|(?<quantity>[0-9]+)\|([^\|$%\.[0-9]*)(?<price>[0-9]+\.?[0-9]*)\$";

            string input = Console.ReadLine();

            double personsAmount = 0;

            double totalAmount = 0;

            while (input != "end of shift")
            {
                Match match = Regex.Match(input, totalPattern);

                if (match.Success)
                {
                    totalAmount += double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value);

                    Console.WriteLine($"{match.Groups["name"].Value}: {match.Groups["product"].Value} - {double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value):F2}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalAmount:F2}");
        }
    }
}
