using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string letterRegex = @"[STARstar]";
            string decryptedRegex = @"^[^@\-!:>\n]*@(?<name>[A-Z][a-z]+)[^@\-!:>\n]*:(?<population>[0-9]+)[^@\-!:>\n]*!(?<attackordefense>D|A)![^@\-!:>\n]*->(?<soldiers>[0-9]+)[^@\-!:>\n]*$";
            
            StringBuilder decryptedMessage = new StringBuilder();

            int letterNumber = 0;

            Dictionary<string, List<string>> planetStatus = new Dictionary<string, List<string>>();

            int decryptSuccess = 0;

            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();
                MatchCollection letterMatch = Regex.Matches(encryptedMessage, letterRegex);
          
                letterNumber = letterMatch.Count;
             
                for (int j = 0; j < encryptedMessage.Length; j++)
                {
                    int asciiValue = (int)encryptedMessage[j] - letterNumber;
                    decryptedMessage.Append((char)asciiValue);
                }

                Match decryptedMatch = Regex.Match(decryptedMessage.ToString(), decryptedRegex);

                if (decryptedMatch.Success)
                {
                    if (decryptedMatch.Groups["attackordefense"].Value == "A")
                    {
                        if (!planetStatus.ContainsKey("Attacked planets"))
                        {
                            planetStatus.Add("Attacked planets", new List<string>()); // ? duplicate planets? Adding a list to keep all the planets under
                        }

                        if (!planetStatus["Attacked planets"].Contains(decryptedMatch.Groups["name"].Value))
                        {
                            planetStatus["Attacked planets"].Add(decryptedMatch.Groups["name"].Value);
                        }
                    }
                    else if ((decryptedMatch.Groups["attackordefense"].Value == "D"))
                    {
                        if (!planetStatus.ContainsKey("Destroyed planets"))
                        {
                            planetStatus.Add("Destroyed planets", new List<string>());
                        }

                        if (!planetStatus["Destroyed planets"].Contains(decryptedMatch.Groups["name"].Value))
                        {
                            planetStatus["Destroyed planets"].Add(decryptedMatch.Groups["name"].Value);
                        }
                    }

                    decryptSuccess++;
                }

                decryptedMessage.Clear();
            }

            if (decryptSuccess == 0)
            {
                Console.WriteLine("Attacked planets: 0");
                Console.WriteLine("Destroyed planets: 0");
                return;
            }

            if (!planetStatus.ContainsKey("Destroyed planets"))
            {
                planetStatus.Add("Destroyed planets", new List<string>());
            }
            else if (!planetStatus.ContainsKey("Attacked planets"))
            {
                planetStatus.Add("Attacked planets", new List<string>());
            }

            planetStatus = planetStatus.OrderBy(x => x.Key).ThenBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var status in planetStatus)
            {
                Console.WriteLine($"{status.Key}: {status.Value.Count}");

                foreach (var item in status.Value.OrderBy(item => item))
                {
                    Console.WriteLine($"-> {item}");
                }
            }
        }
    }
}
