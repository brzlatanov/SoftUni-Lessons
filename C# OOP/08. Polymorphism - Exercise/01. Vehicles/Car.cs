using System.Buffers.Text;
using System.Runtime.CompilerServices;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public override double FuelConsumption => base.FuelConsumption + 0.9;
    }
}