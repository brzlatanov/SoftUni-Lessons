using System;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
       
        }

        public void DriveFull(double distance)
        {
            if (this.FuelQuantity >= (this.FuelConsumption + 1.4) * distance)
            {
                this.FuelQuantity -= (this.FuelConsumption + 1.4) * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
    }
}