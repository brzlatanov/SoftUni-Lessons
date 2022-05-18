using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int wagonCapacity = int.Parse(Console.ReadLine());
            int tryInt = 0;
            int passengersAdded = 0;
            int passengersLeft = 0;

            string command = Console.ReadLine();

            while (command != "end")
            {

                string[] commandArgs = command.Split(' ');
                if (commandArgs[0] == "Add")
                {
                    wagons.Add(int.Parse(commandArgs[1]));
                }
                else if (Int32.TryParse(command, out tryInt) == true)
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (int.Parse(commandArgs[0]) + wagons[i] <= wagonCapacity)
                        {
                            wagons[i] += int.Parse(commandArgs[0]);
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
