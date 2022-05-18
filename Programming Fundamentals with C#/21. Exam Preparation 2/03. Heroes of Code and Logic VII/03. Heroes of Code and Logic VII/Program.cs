using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int[]> heroDict = new Dictionary<string, int[]>();

            for (int i = 0; i < n; i++)
            {
                string[] heroInput = Console.ReadLine().Split(" ");
                heroDict.Add(heroInput[0], new int[] { int.Parse(heroInput[1]), int.Parse(heroInput[2]) });
            }

            string[] command = Console.ReadLine().Split(" - ");

            while (command[0] != "End") 
            {
                if (heroDict.ContainsKey(command[1]))
                {
                    if (command[0] == "CastSpell") 
                    {
                        if (int.Parse(command[2]) <= heroDict[command[1]][1])
                        {
                            heroDict[command[1]][1] -= int.Parse(command[2]);
                            Console.WriteLine($"{command[1]} has successfully cast {command[3]} and now has {heroDict[command[1]][1]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{command[1]} does not have enough MP to cast {command[3]}!");
                        }
                    }
                    else if (command[0] == "TakeDamage") // TakeDamage – {hero name} – {damage} – {attacker}
                    {
                        if (int.Parse(command[2]) < heroDict[command[1]][0])
                        {
                            heroDict[command[1]][0] -= int.Parse(command[2]);
                            Console.WriteLine($"{command[1]} was hit for {command[2]} HP by {command[3]} and now has {heroDict[command[1]][0]} HP left!");
                        }
                        else
                        {
                            heroDict.Remove(command[1]);
                            Console.WriteLine($"{command[1]} has been killed by {command[3]}!");
                        }
                    }
                    else if (command[0] == "Recharge") // Recharge – {hero name} – {amount}
                    {
                        if (heroDict[command[1]][1] + int.Parse(command[2]) > 200)
                        {
                            Console.WriteLine($"{command[1]} recharged for {200 - heroDict[command[1]][1]} MP!");
                            heroDict[command[1]][1] = 200;

                        }
                        else
                        {
                            Console.WriteLine($"{command[1]} recharged for {command[2]} MP!");
                            heroDict[command[1]][1] += int.Parse(command[2]);
                        }
                    }
                    else if (command[0] == "Heal") // Heal – {hero name} – {amount}
                    {
                        if (heroDict[command[1]][0] + int.Parse(command[2]) > 100)
                        {
                            Console.WriteLine($"{command[1]} healed for {100 - heroDict[command[1]][0]} HP!");
                            heroDict[command[1]][0] = 100;

                        }
                        else
                        {
                            Console.WriteLine($"{command[1]} healed for {command[2]} HP!");
                            heroDict[command[1]][0] += int.Parse(command[2]);
                        }
                    }
                }

                command = Console.ReadLine().Split(" - ");
            }

            heroDict = heroDict.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var key in heroDict)
            {
                Console.WriteLine(key.Key);
                Console.WriteLine($"HP: {key.Value[0]}");
                Console.WriteLine($"MP: {key.Value[1]}");
            }
        }
    }
}
