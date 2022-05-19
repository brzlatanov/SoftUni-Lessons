using System;

namespace CarManufacturer
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");

            car.FuelQuantity = 1;
            car.FuelConsumption = 1000;
            car.Drive(300000);
        }
    }
}
