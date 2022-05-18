using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Car> carList = new List<Car>();

            List<Truck> truckList = new List<Truck>();

            while (input != "End")
            {
                // get the information about the vehicle
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = inputArgs[0];
                string model = inputArgs[1];
                string color = inputArgs[2].ToLower();
                uint horsepower = uint.Parse(inputArgs[3]);

                // sort it under the different lists under the cars and trucks classes
                bool itemInserted = false;

                if (type == "car")
                {
                    Car car = new Car(model, color, horsepower);

                    for (int i = 0; i < carList.Count; i++)
                    {
                        if (carList[i].Model == model)
                        {
                            carList.Remove(carList[i]);
                            carList.Insert(i, car);
                            itemInserted = true;
                        }
                    }

                    if (itemInserted == false)
                    {
                        carList.Add(car);
                    }

                }
                else if (type == "truck")
                {
                    Truck truck = new Truck(model, color, horsepower);

                    for (int i = 0; i < truckList.Count; i++)
                    {
                        if (truckList[i].Model == model)
                        {
                            truckList.Remove(truckList[i]);
                            truckList.Insert(i, truck);
                            itemInserted = true;
                        }
                    }

                    if (itemInserted == false)
                    {
                        truckList.Add(truck);
                    }
                }

                input = Console.ReadLine();
            }

            //getting the model input and comparing it to the existing ones, then adding it to either the final car list or the final truck list
            input = Console.ReadLine();

            List<Car> finalListCars = new List<Car>();
            List<Truck> finalListTrucks = new List<Truck>();

            double carHorsePower = 0;
            double truckHorsePower = 0;

            while (input != "Close the Catalogue")
            {
                for (int i = 0; i < carList.Count; i++)
                {
                    if (carList[i].Model == input)
                    {
                        finalListCars.Add(carList[i]);
                        Console.WriteLine(carList[i].ToString());
                    }
                }

                for (int i = 0; i < truckList.Count; i++)
                {
                    if (truckList[i].Model == input)
                    {
                        finalListTrucks.Add(truckList[i]);
                        Console.WriteLine(truckList[i].ToString());
                    }
                }

                input = Console.ReadLine();
            }
            for (int i = 0; i < carList.Count; i++)
            {
                carHorsePower += carList[i].Horsepower;
            }
            for (int i = 0; i < truckList.Count; i++)
            {
                truckHorsePower += truckList[i].Horsepower;
            }
            if (carList.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {(carHorsePower / carList.Count):F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            if (truckList.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {(truckHorsePower / truckList.Count):F2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }

        }

        public class Car
        {
            public string Type = "Car";
            public string Model { get; set; }
            public string Color { get; set; }
            public uint Horsepower { get; set; }
            public Car(string model, string color, uint horsepower)
            {

                Model = model;
                Color = color;
                Horsepower = horsepower;
            }
            public static List<Car> cars { get; set; }
            public override string ToString()
            {
                return string.Join("\n", $"Type: {Type}", $"Model: {Model}", $"Color: {Color}", $"Horsepower: {Horsepower}");

            }
        }
        public class Truck
        {
            public string Type = "Truck";
            public string Model { get; set; }
            public string Color { get; set; }
            public uint Horsepower { get; set; }
            public Truck(string model, string color, uint horsepower)
            {

                Model = model;
                Color = color;
                Horsepower = horsepower;
            }
            public static List<Truck> trucks { get; set; }
            public override string ToString()
            {
                return string.Join("\n", $"Type: {Type}", $"Model: { Model}", $"Color: {Color}", $"Horsepower: {Horsepower}");

            }
        }
    }
}
