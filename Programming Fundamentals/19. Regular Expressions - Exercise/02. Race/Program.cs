using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialInput = Console.ReadLine().Split(", ");
            Dictionary<string, int> finalList = new Dictionary<string, int>();

            for (int i = 0; i < initialInput.Length; i++)
            {
                finalList.Add(initialInput[i], 0);
            }

            string nameString = @"\p{L}";
            string numberString = @"[0-9]";
            string encodedInput = Console.ReadLine();

            string actualName = "";
            int actualNumber = 0;

            while (encodedInput != "end of race")
            {
                for (int i = 0; i < encodedInput.Length; i++)
                {
                    Match nameMatch = Regex.Match(encodedInput[i].ToString(), nameString);
                    Match numberMatch = Regex.Match(encodedInput[i].ToString(), numberString);

                    if (nameMatch.Success)
                    {
                        actualName += nameMatch.Value;
                    }
                    else if (numberMatch.Success)
                    {
                        actualNumber += int.Parse(numberMatch.Value);
                    }

                }
         
                if (finalList.ContainsKey(actualName))
                {
                    finalList[actualName] += actualNumber;
                }
              
                actualName = "";
                actualNumber = 0;

                encodedInput = Console.ReadLine();
            }

            finalList = finalList.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            var counter = 1;

            foreach (var key in finalList)
            {
                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {key.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {key.Key}");
                }
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {key.Key}");
                    break;
                }

                counter++;
            }
        }
    }
}
