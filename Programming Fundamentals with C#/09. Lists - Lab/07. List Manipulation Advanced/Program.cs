using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = Console.ReadLine();

            bool changeMade = false;

            while (command != "end")
            {
                string[] commandArgs = command.Split();
                string action = commandArgs[0];

                if (action == "Add")
                {
                    numbers.Add(int.Parse(commandArgs[1]));
                    changeMade = true;
                }
                else if (action == "Remove")
                {
                    numbers.Remove(int.Parse(commandArgs[1]));
                    changeMade = true;
                }
                else if (action == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(commandArgs[1]));
                    changeMade = true;
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(commandArgs[2]);
                    numbers.Insert(index, int.Parse(commandArgs[1]));
                    changeMade = true;
                }
                else if (action == "Contains")
                {
                    if (numbers.Contains(int.Parse(commandArgs[1])) == true)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (action == "PrintEven")
                {
                    foreach (var evenNumber in numbers)
                    {
                        if (evenNumber % 2 == 0)
                        {
                            Console.Write(evenNumber + " ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (action == "PrintOdd")
                {
                    foreach (var evenNumber in numbers)
                    {
                        if (evenNumber % 2 != 0)
                        {
                            Console.Write(evenNumber + " ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (action == "GetSum")
                {
                    int sum = 0;
                    foreach (var evenNumber in numbers)
                    {
                        sum += evenNumber;
                    }
                    Console.WriteLine(sum);
                }
                else if (commandArgs[0] == "Filter")
                {
                    if (commandArgs[1] == "<")
                    {
                        foreach (var evenNumber in numbers)
                        {
                            if (evenNumber < int.Parse(commandArgs[2]))
                            {
                                Console.Write(evenNumber + " ");
                            }
                        }
                    }
                    else if (commandArgs[1] == ">")
                    {
                        foreach (var evenNumber in numbers)
                        {
                            if (evenNumber > int.Parse(commandArgs[2]))
                            {
                                Console.Write(evenNumber + " ");
                            }
                        }
                    }
                    else if (commandArgs[1] == ">=")
                    {
                        foreach (var evenNumber in numbers)
                        {
                            if (evenNumber >= int.Parse(commandArgs[2]))
                            {
                                Console.Write(evenNumber + " ");
                            }
                        }
                    }
                    else if (commandArgs[1] == "<=")
                    {
                        foreach (var evenNumber in numbers)
                        {
                            if (evenNumber <= int.Parse(commandArgs[2]))
                            {
                                Console.Write(evenNumber + " ");
                            }
                        }
                    }
                    Console.WriteLine();


                }

                command = Console.ReadLine();
            }

            if (changeMade == true)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }

        }
    }
}
