using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandCount = int.Parse(Console.ReadLine());

            List<string> guestList = new List<string>();

            for (int i = 0; i < commandCount; i++)
            {
                string message = Console.ReadLine();
                string[] commandArgs = message.Split();

                if (commandArgs[2] == "going!" && guestList.Contains(commandArgs[0]) == false)
                {
                    guestList.Add(commandArgs[0]);
                }
                else if (commandArgs[2] == "going!" && guestList.Contains(commandArgs[0]) == true)
                {
                    Console.WriteLine($"{commandArgs[0]} is already in the list!");
                }
                else if (commandArgs[2] == "not" && commandArgs[3] == "going!" && guestList.Contains(commandArgs[0]) == true)
                {
                    guestList.Remove(commandArgs[0]);
                }
                else if (commandArgs[2] == "not" && commandArgs[3] == "going!" && guestList.Contains(commandArgs[0]) == false)
                {
                    Console.WriteLine($"{commandArgs[0]} is not in the list!");
                }
            }
            foreach (var guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
