using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int rowCounter = 0;
            Stack<Animal> animals = new Stack<Animal>();

            while (input[0].ToUpper() != "END")
            {
                if (rowCounter % 2 == 0)
                {
                    string animalType = input[0];
                    switch (animalType.ToUpper())
                    {
                        case "HEN":
                            Hen hen = new Hen(input[1], double.Parse(input[2]), double.Parse(input[3]));
                            animals.Push(hen);
                            hen.MakeSound();
                            break;
                        case "OWL":
                            Owl owl = new Owl(input[1], double.Parse(input[2]), double.Parse(input[3]));
                            animals.Push(owl);
                            owl.MakeSound();
                            break;
                        case "MOUSE":
                            Mouse mouse = new Mouse(input[1], double.Parse(input[2]), input[3]);
                            animals.Push(mouse);
                            mouse.MakeSound();
                            break;
                        case "DOG":
                            Dog dog = new Dog(input[1], double.Parse(input[2]), input[3]);
                            animals.Push(dog);
                            dog.MakeSound();
                            break;
                        case "CAT":
                            Cat cat = new Cat(input[1], double.Parse(input[2]), input[3], input[4]);
                            animals.Push(cat);
                            cat.MakeSound();
                            break;
                        case "TIGER":
                            Tiger tiger = new Tiger(input[1], double.Parse(input[2]), input[3], input[4]);
                            animals.Push(tiger);
                            tiger.MakeSound();
                            break;
                    }
                }
                else if (rowCounter % 2 != 0)
                {
                    string foodType = input[0];
                    int foodQuantity = int.Parse(input[1]);
                    switch (foodType.ToUpper())
                    {
                        case "VEGETABLE":
                            Vegetable vegetable = new Vegetable();
                            vegetable.Quantity = foodQuantity;
                            animals.Peek().Feed(vegetable);
                            break;
                        case "FRUIT":
                            Fruit fruit = new Fruit();
                            fruit.Quantity = foodQuantity;
                            animals.Peek().Feed(fruit);
                            break;
                        case "MEAT":
                            Meat meat = new Meat();
                            meat.Quantity = foodQuantity;
                            animals.Peek().Feed(meat);
                            break;
                        case "SEEDS":
                            Seeds seeds = new Seeds();
                            seeds.Quantity = foodQuantity;
                            animals.Peek().Feed(seeds);
                            break;
                    }

                }

                rowCounter++;

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var animal in animals.ToArray().Reverse())
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
