using System.Buffers.Text;
using System.Runtime.CompilerServices;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity , fuelConsumption, tankCapacity)
        {
          
        }
        public override double FuelConsumption => base.FuelConsumption + 0.9;
    }
}