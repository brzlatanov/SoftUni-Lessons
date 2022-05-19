using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
   
        public class Car
        {
            private string make;
            private string model;
            private int year;
            private double quantity;
            private double consumption;

        public string Make
            {
                get { return make; }
                set { make = value; }
            }

            public string Model
            {
                get { return model; }
                set { model = value; }
            }

            public int Year
            {
                get { return year; }
                set { year = value; }
            }

            public double FuelQuantity
            {
                get { return quantity; }
                set { quantity = value; }
            }

            public double FuelConsumption
            {
                get { return consumption; }
                set { consumption = value; }
            }

            public void Drive(double distance)
            {
                var canContinue = (this.FuelQuantity - (distance * this.FuelConsumption)) >= 0;

                if (canContinue)
                {
                    this.FuelQuantity -= distance * this.FuelConsumption;
                }
                else
                {
                    Console.WriteLine("Not enough fuel to perform this trip!");
                }
            }

            public void WhoAmI()
            {
                Console.WriteLine($"{this.Make}");
                Console.WriteLine($" {this.Model}");
                Console.WriteLine($"{this.Year}");
                Console.WriteLine($"{this.FuelQuantity:F2}");

            }

            public Car()
            {
                this.Make = "VW";
                this.Model = "Golf";
                this.Year = 2025;
                this.FuelQuantity = 200;
                this.FuelConsumption = 10;
            }

            public Car(string make, string model, int year) : this()
            {
                this.Make = make;
                this.Model = model;
                this.Year = year;
            }

            public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make,
                model, year)

            {
                this.FuelQuantity = fuelQuantity;
                this.FuelConsumption = fuelConsumption;
            }
        }
    
    

}
