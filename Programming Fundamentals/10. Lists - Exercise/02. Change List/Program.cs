using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split();

                if (commandArgs[0] == "Delete")
                {
                    for (int i = 0; i < inputList.Count; i++)
                    {
                        inputList.Remove(int.Parse(commandArgs[1]));
                    }

                }
                else if (commandArgs[0] == "Insert")
                {
                    inputList.Insert(int.Parse(commandArgs[2]), int.Parse(commandArgs[1]));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", inputList));
        }
    }
}
