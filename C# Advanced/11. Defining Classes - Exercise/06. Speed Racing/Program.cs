using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();

            for (int i = 0; i < n; i++) // getting the car details from the console
            {
                string[] carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = carInput[0];
                double carFuelAmount = double.Parse(carInput[1]);
                double carFuelConsumptionFor1Km = double.Parse(carInput[2]);

                carList.Add(new Car(carModel, carFuelAmount, carFuelConsumptionFor1Km));
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                string carModel = command[1];
                double amountOfKm = double.Parse(command[2]);
                Car currentCar = null;

                foreach (var car in carList)
                {
                    if (car.Model == carModel)
                    {
                        currentCar = car;
                    }
                }

                if (Car.CanDrive(amountOfKm, currentCar.FuelAmount, currentCar.FuelConsumptionPerKilometer))
                {
                    currentCar.FuelAmount -= amountOfKm * currentCar.FuelConsumptionPerKilometer;
                    currentCar.TravelledDistance += amountOfKm;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
