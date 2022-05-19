using System;

namespace Vehicles
{
    public class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;

            if (this.FuelQuantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
        }

        public virtual double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; set; }

        public virtual double TankCapacity { get; set; }


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
            if (liters > 0)
            {
                if (this.TankCapacity >= this.FuelQuantity + liters)
                {
                    this.FuelQuantity += liters;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }

    }
}