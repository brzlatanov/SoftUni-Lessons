using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(", ");
            HashSet<string> carNumbers = new HashSet<string>();

            while (command[0] != "END")
            {
                string direction = command[0];
                string carNumber = command[1];

                if (direction == "IN")
                {
                    carNumbers.Add(carNumber);
                }

                else if (direction == "OUT" && carNumbers.Contains(carNumber))
                {
                    carNumbers.Remove(carNumber);
                }

                command = Console.ReadLine().Split(", ");
            }

            if (carNumbers.Count > 0)
            {
                foreach (var car in carNumbers)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
