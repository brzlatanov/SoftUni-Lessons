using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int[]> carStorage = new Dictionary<string, int[]>();

            for (int i = 0; i < n; i++)
            {
                string[] carInput = Console.ReadLine().Split("|");
                string carName = carInput[0];
                int carMileage = int.Parse(carInput[1]);
                int carFuel = int.Parse(carInput[2]);

                if (carMileage >= 100000)
                {
                    Console.WriteLine($"Time to sell the {carName}!"); 
                }
                else
                {
                    carStorage.Add(carName, new int[] { carMileage, carFuel });
                }
            }
            if (carStorage.Count == 0) 
            {
                return;
            }

            string[] command = Console.ReadLine().Split(" : ");

            while (command[0] != "Stop")
            {
               
                if (command[0] == "Drive" && carStorage.ContainsKey(command[1])) 
                {
                    if (carStorage[command[1]][1] < int.Parse(command[3]))
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        carStorage[command[1]][0] += int.Parse(command[2]); // mileage
                        carStorage[command[1]][1] -= int.Parse(command[3]); //fuel

                        if (carStorage[command[1]][1] < 0) // if fuel goes under 0, it's 0
                        {
                            carStorage[command[1]][1] = 0;
                        }

                        Console.WriteLine($"{command[1]} driven for {command[2]} kilometers. {command[3]} liters of fuel consumed.");
                    }
                    if (carStorage[command[1]][0] >= 100000)
                    {
                        carStorage.Remove(command[1]);
                        Console.WriteLine($"Time to sell the {command[1]}!");
                    }
                }
                else if (command[0] == "Refuel") 
                {
                    if (carStorage[command[1]][1] + int.Parse(command[2]) > 75)
                    {
                        Console.WriteLine($"{command[1]} refueled with {75 - carStorage[command[1]][1]} liters"); 
                        carStorage[command[1]][1] = 75;
                    }
                    else
                    {
                        carStorage[command[1]][1] += int.Parse(command[2]);
                        Console.WriteLine($"{command[1]} refueled with {(command[2])} liters");
                    }


                }
                else if (command[0] == "Revert") 
                {
                    carStorage[command[1]][0] -= int.Parse(command[2]);

                    if (carStorage[command[1]][0] < 10000)
                    {
                        carStorage[command[1]][0] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{command[1]} mileage decreased by {command[2]} kilometers");
                    }
                }
                command = Console.ReadLine().Split(" : ");
            }
            carStorage = carStorage.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value); // not sure if works

            foreach (var car in carStorage)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }
    }
}
