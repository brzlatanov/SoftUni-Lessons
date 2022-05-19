using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace _09._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guestList = new List<string>();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in input)
            {
                guestList.Add(person);
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<string> tempList = new List<string>();

            while (command[0] != "Party!")
            {

                string removeOrDouble = command[0];
                string condition = command[1];
                string conditionContent = command[2];

                if (removeOrDouble == "Remove")
                {
                    guestList = RemoveGuests(condition, guestList, conditionContent);
                }
                else if (removeOrDouble == "Double")
                {
                    AddGuests(condition, guestList, conditionContent);
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            PrintOutcome(guestList);
        }

        private static void PrintOutcome(List<string> guestList)
        {
            if (guestList.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guestList)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void AddGuests(string condition, List<string> guestList, string conditionContent)
        {
            List<string> tempList;

            if (condition == "StartsWith")
            {
                tempList = guestList.FindAll(x => x.StartsWith(conditionContent)).ToList();

                foreach (var criteriaPerson in tempList)
                {
                    guestList.Add(criteriaPerson);
                }
            }
            else if (condition == "EndsWith")
            {
                tempList = guestList.FindAll(x => x.EndsWith(conditionContent)).ToList();

                foreach (var criteriaPerson in tempList)
                {
                    guestList.Add(criteriaPerson);
                }
            }
            else if (condition == "Length")
            {
                tempList = guestList.FindAll(x => x.Length == int.Parse(conditionContent));

                foreach (var criteriaPerson in tempList)
                {
                    guestList.Add(criteriaPerson);
                }
            }
        }

        private static List<string> RemoveGuests(string condition, List<string> guestList, string conditionContent)
        {
            if (condition == "StartsWith")
            {
                guestList = guestList.Where(x => !x.StartsWith(conditionContent)).ToList();
            }
            else if (condition == "EndsWith")
            {
                guestList = guestList.Where(x => !x.EndsWith(conditionContent)).ToList();
            }
            else if (condition == "Length")
            {
                guestList = guestList.Where(x => x.Length != int.Parse(conditionContent)).ToList();
            }

            return guestList;
        }
    }
}
