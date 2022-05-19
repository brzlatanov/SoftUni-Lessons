using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public override double FuelConsumption { get; set; } = 10;

        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
        public override void Drive(double kilometers)
        {
            Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
