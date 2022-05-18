using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, string> carRegister = new Dictionary<string, string>();

            for (int i = 0; i < number; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "register")
                {
                    if (!carRegister.ContainsKey(command[1]))
                    {
                        carRegister.Add(command[1], command[2]);
                        Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                    }
                    else if (carRegister.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {carRegister[command[1]]}");
                    }
                }
                else if (command[0] == "unregister")
                {
                    if (!carRegister.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: user {command[1]} not found");
                    }
                    else if (carRegister.ContainsKey(command[1]))
                    {
                        carRegister.Remove(command[1]);
                        Console.WriteLine($"{command[1]} unregistered successfully");
                    }
                }
            }

            foreach (var car in carRegister)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
