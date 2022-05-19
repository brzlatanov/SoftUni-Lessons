using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int commandNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandNumber; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Drive")
                {
                    if (input[1] == "Car")
                    {
                        car.Drive(double.Parse(input[2]));
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.Drive(double.Parse(input[2]));
                    }
                    else if (input[1] == "Bus")
                    {
                        bus.DriveFull(double.Parse(input[2]));
                    }
                }
                else if (input[0] == "DriveEmpty")
                {
                    bus.Drive(double.Parse(input[2]));
                }
                else if (input[0] == "Refuel")
                {
                    if (input[1] == "Car")
                    {
                        car.Refuel(double.Parse(input[2]));
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(input[2]));
                    }
                    else if (input[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(input[2]));
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");

        }
    }
}
