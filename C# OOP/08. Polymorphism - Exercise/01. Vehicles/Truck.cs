namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public override double FuelConsumption => base.FuelConsumption + 1.6;
        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters * 0.95;
        }
    }
}