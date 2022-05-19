using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] carDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carDetails[0];
                int engineSpeed = int.Parse(carDetails[1]);
                int enginePower = int.Parse(carDetails[2]);
                int cargoWeight = int.Parse(carDetails[3]);
                string cargoType = carDetails[4];
                double tire1Pressure = double.Parse(carDetails[5]);
                int tire1Age = int.Parse(carDetails[6]);
                double tire2Pressure = double.Parse(carDetails[7]);
                int tire2Age = int.Parse(carDetails[8]);
                double tire3Pressure = double.Parse(carDetails[9]);
                int tire3Age = int.Parse(carDetails[10]);
                double tire4Pressure = double.Parse(carDetails[11]);
                int tire4Age = int.Parse(carDetails[12]);

                Car car = new Car(model, new Car.Engine(), new Car.Cargo(), new Car.Tire[4]);
                car.CarEngine = new Car.Engine();
                car.CarEngine.Speed = engineSpeed;
                car.CarEngine.Power = enginePower;
                car.CarCargo = new Car.Cargo();
                car.CarCargo.Weight = cargoWeight;
                car.CarCargo.Type = cargoType;
                car.CarTires = new Car.Tire[4];
                car.CarTires[0] = new Car.Tire();
                car.CarTires[0].Age = tire1Age;
                car.CarTires[0].Pressure = tire1Pressure;
                car.CarTires[1] = new Car.Tire();
                car.CarTires[1].Age = tire2Age;
                car.CarTires[1].Pressure = tire2Pressure;
                car.CarTires[2] = new Car.Tire();
                car.CarTires[2].Age = tire3Age;
                car.CarTires[2].Pressure = tire3Pressure;
                car.CarTires[3] = new Car.Tire();
                car.CarTires[3].Age = tire4Age;
                car.CarTires[3].Pressure = tire4Pressure;

                carList.Add(car);

            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in carList)
                {
                    if (car.CarCargo.Type == "fragile")
                    {
                        foreach (var tire in car.CarTires)
                        {
                            if (tire.Pressure < 1)
                            {
                                Console.WriteLine(car.Model);
                                break;
                            }
                        }
                    }
                }
            }
            else if (command == "flammable")
            {
                foreach (var car in carList)
                {
                    if (car.CarCargo.Type == "flammable" && car.CarEngine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
