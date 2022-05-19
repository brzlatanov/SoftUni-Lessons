using System;
using System.Collections.Generic;
using System.Linq;


namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string tireCommand = Console.ReadLine();

            List<Tire[]> tiresList = new List<Tire[]>();

            while (tireCommand != "No more tires")
            {
                string[] tireArgs = tireCommand.Split();

                var tires = new Tire[4]
                {
                        new Tire(int.Parse(tireArgs[0]), double.Parse(tireArgs[1])),
                        new Tire(int.Parse(tireArgs[2]), double.Parse(tireArgs[3])),
                        new Tire(int.Parse(tireArgs[4]), double.Parse(tireArgs[5])),
                        new Tire(int.Parse(tireArgs[6]), double.Parse(tireArgs[7]))
                };

                tiresList.Add(tires);

                tireCommand = Console.ReadLine();

            }

            string engineCommand = Console.ReadLine();
            List<Engine> engines = new List<Engine>();
            while (engineCommand != "Engines done")
            {
                string[] engineArgs = engineCommand.Split();

                engines.Add(new Engine(int.Parse(engineArgs[0]), double.Parse(engineArgs[1])));

                engineCommand = Console.ReadLine();
            }

            string carCommand = Console.ReadLine();

            

            while (carCommand != "Show special")
            {
                string[] carArgs = carCommand.Split();

                Car currentCar = new Car(carArgs[0], carArgs[1], int.Parse(carArgs[2]), double.Parse(carArgs[3]), double.Parse(carArgs[4]), engines[int.Parse(carArgs[5])], tiresList[int.Parse(carArgs[6])]);

                double totalTirePressure = currentCar.Tires[0].Pressure + currentCar.Tires[1].Pressure + currentCar.Tires[2].Pressure +
                                           currentCar.Tires[3].Pressure;

                if (currentCar.Year >= 2017 && currentCar.Engine.HorsePower > 330 && totalTirePressure > 9 && totalTirePressure < 10)
                {
                    currentCar.FuelQuantity -= currentCar.FuelConsumption / 100 * 20;

                    Console.WriteLine($"Make: {currentCar.Make}");
                    Console.WriteLine($"Model: {currentCar.Model}");
                    Console.WriteLine($"Year: {currentCar.Year}");
                    Console.WriteLine($"HorsePowers: {currentCar.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {currentCar.FuelQuantity}");
                }


                carCommand = Console.ReadLine();
            }

          // foreach (var car in cars)
          // {
          //     double totalTirePressure = car.Tires[0].Pressure + car.Tires[1].Pressure + car.Tires[2].Pressure +
          //                         car.Tires[3].Pressure;
          //
          //     if (car.Year >= 2017 && car.Engine.HorsePower > 330 && totalTirePressure > 9 && totalTirePressure < 10)
          //     {
          //         car.FuelQuantity -= car.FuelConsumption / 100 * 20;
          //
          //         Console.WriteLine($"Make: {car.Make}");
          //         Console.WriteLine($"Model: {car.Model}");
          //         Console.WriteLine($"Year: {car.Year}");
          //         Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
          //         Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
          //     }
          //
          // }
        }
    }
}
