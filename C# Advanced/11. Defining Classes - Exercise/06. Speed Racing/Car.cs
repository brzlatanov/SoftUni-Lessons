using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public static bool CanDrive(double amountOfKm, double fuelAmount, double fuelConsumption)
        {
            bool canDrive = true;

            if (fuelAmount < amountOfKm * fuelConsumption)
            {
                canDrive = false;
            }

            return canDrive;
        }
    }
}
