using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var matches = Regex.Matches(input, @"(?<day>[0-9]{2})(?<separator>.)(?<month>[A-Z][a-z]{2})\k<separator>(?<year>[0-9]{4})");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }
        }
    }
}
