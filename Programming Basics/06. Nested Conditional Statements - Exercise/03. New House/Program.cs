using System;

namespace _03._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerNumber = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double roses = 5;
            double dahlias = 3.80;
            double tulips = 2.80;
            double narcissus = 3;
            double gladiolus = 2.50;

            if (flowerType == "Roses" && flowerNumber > 80)
            {
                roses = (roses - roses * 0.1);
                double price = roses * flowerNumber;
                double finalPrice = budget - price;
                if (finalPrice >= 0)
                {
                    Console.WriteLine($"Hey, you have a great garden with {flowerNumber} Roses and {finalPrice:F2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {Math.Abs(finalPrice):F2} leva more.");
                }
            }
            else if (flowerType == "Roses" && flowerNumber <= 80)
            {
                double price = roses * flowerNumber;
                double finalPrice = budget - price;
                if (finalPrice >= 0)
                {
                    Console.WriteLine($"Hey, you have a great garden with {flowerNumber} Roses and {finalPrice:F2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {Math.Abs(finalPrice):F2} leva more.");
                }
            }

            if (flowerType == "Dahlias" && flowerNumber > 90)
            {
                dahlias = (dahlias - dahlias * 0.15);
                double price = dahlias * flowerNumber;
                double finalPrice = budget - price;
                if (finalPrice >= 0)
                {
                    Console.WriteLine($"Hey, you have a great garden with {flowerNumber} Dahlias and {finalPrice:F2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {Math.Abs(finalPrice):F2} leva more.");
                }

            }
            else if (flowerType == "Dahlias" && flowerNumber <= 90)
            {
                double price = dahlias * flowerNumber;
                double finalPrice = budget - price;
                if (finalPrice >= 0)
                {
                    Console.WriteLine($"Hey, you have a great garden with {flowerNumber} Dahlias and {finalPrice:F2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {Math.Abs(finalPrice):F2} leva more.");
                }
            }

            if (flowerType == "Tulips" && flowerNumber > 80)
            {
                tulips = (tulips - tulips * 0.15);
                double price = tulips * flowerNumber;
                double finalPrice = budget - price;
                if (finalPrice >= 0)
                {
                    Console.WriteLine($"Hey, you have a great garden with {flowerNumber} Tulips and {finalPrice:F2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {Math.Abs(finalPrice):F2} leva more.");
                }

            }
            else if (flowerType == "Tulips" && flowerNumber <= 80)
            {
                double price = tulips * flowerNumber;
                double finalPrice = budget - price;
                if (finalPrice >= 0)
                {
                    Console.WriteLine($"Hey, you have a great garden with {flowerNumber} Tulips and {finalPrice:F2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {Math.Abs(finalPrice):F2} leva more.");
                }
            }

            if (flowerType == "Narcissus" && flowerNumber < 120)
            {
                narcissus = (narcissus + narcissus * 0.15);
                double price = narcissus * flowerNumber;
                double finalPrice = budget - price;
                if (finalPrice >= 0)
                {
                    Console.WriteLine($"Hey, you have a great garden with {flowerNumber} Narcissus and {finalPrice:F2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {Math.Abs(finalPrice):F2} leva more.");
                }

            }
            else if (flowerType == "Narcissus" && flowerNumber >= 120)
            {
                double price = narcissus * flowerNumber;
                double finalPrice = budget - price;
                if (finalPrice >= 0)
                {
                    Console.WriteLine($"Hey, you have a great garden with {flowerNumber} Narcissus and {finalPrice:F2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {Math.Abs(finalPrice):F2} leva more.");
                }
            }

            if (flowerType == "Gladiolus" && flowerNumber < 80)
            {
                gladiolus = (gladiolus + gladiolus * 0.20);
                double price = gladiolus * flowerNumber;
                double finalPrice = budget - price;
                if (finalPrice >= 0)
                {
                    Console.WriteLine($"Hey, you have a great garden with {flowerNumber} Gladiolus and {finalPrice:F2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {Math.Abs(finalPrice):F2} leva more.");
                }
            }
            else if (flowerType == "Gladiolus" && flowerNumber >= 80)
            {
                double price = gladiolus * flowerNumber;
                double finalPrice = budget - price;
                if (finalPrice >= 0)
                {
                    Console.WriteLine($"Hey, you have a great garden with {flowerNumber} Gladiolus and {finalPrice:F2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {Math.Abs(finalPrice):F2} leva more.");
                }
            }
        }
    }
}
