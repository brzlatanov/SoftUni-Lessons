using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialList = Console.ReadLine().Split(", ", ' ');

            List<string> inventory = new List<string>();

            foreach (var item in initialList)
            {
                inventory.Add(item);
            }

            string command = Console.ReadLine();

            while (command != "Craft!")
            {
                string[] commandArgs = command.Split(" - ", ' ');

                if (commandArgs[0] == "Collect" && !inventory.Contains(commandArgs[1]))
                {
                    inventory.Add(commandArgs[1]);
                }
                else if (commandArgs[0] == "Drop" && inventory.Contains(commandArgs[1]))
                {
                    inventory.Remove(commandArgs[1]);
                }
                else if (commandArgs[0] == "Combine Items")
                {
                    string[] items = commandArgs[1].Split(":");
                    if (inventory.Contains(items[0]))
                    {
                        inventory.Insert(inventory.IndexOf(items[0]) + 1, items[1]);
                    }
                }
                else if (commandArgs[0] == "Renew" && inventory.Contains(commandArgs[1]))
                {
                    inventory.Remove(commandArgs[1]);
                    inventory.Add(commandArgs[1]);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}
