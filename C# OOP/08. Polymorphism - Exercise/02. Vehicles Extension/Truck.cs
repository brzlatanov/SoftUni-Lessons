using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            
        }
        public override double FuelConsumption => base.FuelConsumption + 1.6;
        public override void Refuel(double liters)
        {
            if (liters > 0)
            {
                if (this.TankCapacity >= this.FuelQuantity + liters)
                {
                    this.FuelQuantity += liters * 0.95;
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