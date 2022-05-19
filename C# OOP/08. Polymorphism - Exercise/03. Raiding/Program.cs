using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int commandLinesNumber = int.Parse(Console.ReadLine());

            int powerSum = 0;
            List<BaseHero> heroList = new List<BaseHero>();
            while (heroList.Count < commandLinesNumber)
            {
                string heroName = Console.ReadLine();
                string heroClass = Console.ReadLine();

                if (heroClass != "Druid" && heroClass != "Paladin" && heroClass != "Rogue" && heroClass != "Warrior")
                {
                    Console.WriteLine("Invalid hero!");
                }
                else
                {
                    if (heroClass == "Druid")
                    {
                        Druid druid = new Druid(heroName);
                        heroList.Add(druid);
                    }
                    else if (heroClass == "Paladin")
                    {
                        Paladin paladin = new Paladin(heroName);
                        heroList.Add(paladin);
                    }
                    else if (heroClass == "Rogue")
                    {
                        Rogue rogue = new Rogue(heroName);
                        heroList.Add(rogue);
                    }
                    else if (heroClass == "Warrior")
                    {
                        Warrior warrior = new Warrior(heroName);
                        heroList.Add(warrior);
                    }
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in heroList)
            {
                Console.WriteLine(hero.CastAbility());
            }
            if (heroList.Sum(x=> x.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
