using System;
using System.Collections.Generic;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int engineInput = int.Parse(Console.ReadLine());
            List<Engine> engineList = new List<Engine>();

            for (int i = 0; i < engineInput; i++)
            {
                string[] engineString = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineString[0];
                int power = int.Parse(engineString[1]);
                int displacement;
                string efficiency;

                Engine currentEngine = null;

                if (engineString.Length == 3)
                {
                    if (char.IsNumber(engineString[2][0]))
                    {
                        displacement = int.Parse(engineString[2]);
                        currentEngine = new Engine(model, power, displacement);
                    }
                    else if (char.IsLetter(engineString[2][0]))
                    {
                        efficiency = engineString[2];
                        currentEngine = new Engine(model, power, efficiency);
                    }
                }
                else if (engineString.Length == 2)
                {
                    currentEngine = new Engine(model, power);
                }
                else
                {
                    displacement = int.Parse(engineString[2]);
                    efficiency = engineString[3];
                    currentEngine = new Engine(model, power, displacement, efficiency);
                }
                engineList.Add(currentEngine);
            }

            int carInput = int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();

            for (int i = 0; i < carInput; i++)
            {
                string[] carString = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carString[0];
                string engineName = carString[1];
                Engine currentEngine = null;

                for (int j = 0; j < engineList.Count; j++)
                {
                    if (engineList[j].Model == engineName)
                    {
                        currentEngine = engineList[j];
                    }
                }

                int weight;
                string color;

                Car currentCar = null;

                if (carString.Length == 3)
                {
                    if (char.IsNumber(carString[2][0]))
                    {
                        weight = int.Parse(carString[2]);
                        currentCar = new Car(model, currentEngine, weight);
                    }
                    else if (char.IsLetter(carString[2][0]))
                    {
                        color = carString[2];
                        currentCar = new Car(model, currentEngine, color);
                    }
                }
                else if(carString.Length == 2)
                {
                    currentCar = new Car(model, currentEngine);
                }
                else
                {
                    weight = int.Parse(carString[2]);
                    color = carString[3];
                    currentCar = new Car(model, currentEngine, weight, color);
                }
                carList.Add(currentCar);
            }

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($" {car.Engine.Model}:");
                Console.WriteLine($"  Power: {car.Engine.Power}");
                if (string.IsNullOrEmpty(car.Engine.Displacement.ToString()) || car.Engine.Displacement == 0)
                {
                    Console.WriteLine($"  Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"  Displacement: {car.Engine.Displacement}");
                }
                if (string.IsNullOrEmpty(car.Engine.Efficiency))
                {
                    Console.WriteLine($"  Efficiency: n/a");
                }
                else
                {
                    Console.WriteLine($"  Efficiency: {car.Engine.Efficiency}");
                }
                if (string.IsNullOrEmpty(car.Weight.ToString()) || car.Weight == 0)
                {
                    Console.WriteLine($" Weight: n/a");
                }
                else
                {
                    Console.WriteLine($" Weight: {car.Weight}");
                }
                if (string.IsNullOrEmpty(car.Color))
                {
                    Console.WriteLine($" Color: n/a");
                }
                else
                {
                    Console.WriteLine($" Color: {car.Color}");
                }
            }
        }
    }
}
