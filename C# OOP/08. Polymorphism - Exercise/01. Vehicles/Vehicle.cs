using System;

namespace Vehicles
{
    public class Vehicle
    {
        public virtual double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; set; }

        public virtual void Drive(double distance)
        {
            if (this.FuelQuantity >= this.FuelConsumption * distance)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

    }
}