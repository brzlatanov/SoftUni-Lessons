using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, @"\b[A-Z][a-z]+ [A-Z][a-z]+\b");

            foreach (Match item in matches)
            {
                Console.Write(item + " ");
            }
        }
    }
}
