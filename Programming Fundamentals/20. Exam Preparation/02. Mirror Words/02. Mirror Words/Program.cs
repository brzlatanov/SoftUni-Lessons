using System;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"\#{1}[A-z]{3,}\#{2}[A-z]{3,}\#{1}|\@{1}[A-z]{3,}\@{2}[A-z]{3,}\@{1}";

            Regex regex = new Regex(pattern);

            List<string> validPairs = new List<string>();
            List<string> mirroredPairs = new List<string>();

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                validPairs.Add(match.ToString());
            }

            for (int i = 0; i < validPairs.Count; i++)
            {
                string current = validPairs[i];
                string firstHalf = "";
                string seconHalfReversed = "";

                for (int j = 0; j < current.Length / 2; j++)
                {
                    firstHalf += current[j];
                }

                for (int k = current.Length - 1; k >= current.Length / 2; k--)
                {
                    seconHalfReversed += current[k];
                }

                if (firstHalf == seconHalfReversed)
                {
                    mirroredPairs.Add(current);
                }

            }
            if (validPairs.Count > 0)
            {
                Console.WriteLine($"{validPairs.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            List<string> final = new List<string>();

            if (mirroredPairs.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                string final1 = "";

                foreach (var item in mirroredPairs)
                {
                    var curritem = item.Substring(1, (item.Length / 2) - 2);
                    var curritem1 = item.Substring(item.Length / 2 + 1, (item.Length - ((item.Length / 2) + 2)));

                    final1 = $"{curritem} <=> {curritem1}";
                    final.Add(final1);
                }

                Console.WriteLine($"{string.Join(", ", final)}");
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
