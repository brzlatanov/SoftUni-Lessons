using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = Console.ReadLine();
            int firstElement = inputList[0];
            int lastElement = inputList[inputList.Count - 1];

            while (command != "End")
            {
                string[] commandArgs = command.Split();
               
                if (commandArgs[0] == "Add")
                {
                    inputList.Add(int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "Insert")
                {
                    if (int.Parse(commandArgs[2]) > inputList.Count - 1 || int.Parse(commandArgs[2]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        inputList.Insert(int.Parse(commandArgs[2]), int.Parse(commandArgs[1]));
                    }

                }
                else if (commandArgs[0] == "Remove")
                {

                    if (int.Parse(commandArgs[1]) > inputList.Count - 1 || int.Parse(commandArgs[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        inputList.RemoveAt(int.Parse(commandArgs[1]));
                    }
                }
                else if (commandArgs[0] == "Shift" && commandArgs[1] == "left")
                {
                    for (int i = 0; i < int.Parse(commandArgs[2]); i++)
                    {

                        inputList.Add(inputList[0]);
                        inputList.RemoveAt(0);
                    }

                }
                else if (commandArgs[0] == "Shift" && commandArgs[1] == "right")
                {
                    for (int i = 0; i < int.Parse(commandArgs[2]); i++)
                    {

                        inputList.Insert(0, inputList[inputList.Count - 1]);
                        inputList.RemoveAt(inputList.Count - 1);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", inputList));
        }
    }
}
