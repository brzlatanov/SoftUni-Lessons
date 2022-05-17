using System;

namespace _04._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());
            double price = 0.0;
            double finalPrice = 0.0;

            switch (season)
            {
                case "Spring":
                    price = 3000;
                    if (fishermen <= 6)
                    {
                        price = price - (price * 0.10);
                        if (fishermen % 2 == 0)
                        {
                            price = price - (price * 0.05);
                        }
                    }
                    else if (fishermen >= 7 && fishermen <= 11)
                    {
                        price = price - (price * 0.15);
                        if (fishermen % 2 == 0)
                        {
                            price = price - (price * 0.05);
                        }
                    }
                    else if (fishermen > 12)
                    {
                        price = price - (price * 0.25);
                        if (fishermen % 2 == 0)
                        {
                            price = price - (price * 0.05);
                        }
                    }

                    finalPrice = budget - price;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Yes! You have {finalPrice:F2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money! You need {Math.Abs(finalPrice):F2} leva.");
                    }

                    break;

                case "Summer":
                    price = 4200;
                    if (fishermen <= 6)
                    {
                        price = price - (price * 0.10);
                        if (fishermen % 2 == 0)
                        {
                            price = price - (price * 0.05);
                        }
                    }
                    else if (fishermen >= 7 && fishermen <= 11)
                    {
                        price = price - (price * 0.15);
                        if (fishermen % 2 == 0)
                        {
                            price = price - (price * 0.05);
                        }
                    }
                    else if (fishermen > 12)
                    {
                        price = price - (price * 0.25);
                        if (fishermen % 2 == 0)
                        {
                            price = price - (price * 0.05);
                        }

                    }

                    finalPrice = budget - price;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Yes! You have {finalPrice:F2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money! You need {Math.Abs(finalPrice):F2} leva.");
                    }

                    break;

                case "Autumn":
                    price = 4200;
                    if (fishermen <= 6)
                    {
                        price = price - (price * 0.10);

                    }
                    else if (fishermen >= 7 && fishermen <= 11)
                    {
                        price = price - (price * 0.15);

                    }
                    else if (fishermen > 12)
                    {
                        price = price - (price * 0.25);

                    }

                    finalPrice = budget - price;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Yes! You have {finalPrice:F2} leva left.");
                        ;
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money! You need {Math.Abs(finalPrice):F2} leva.");
                    }

                    break;

                case "Winter":
                    price = 2600;
                    if (fishermen <= 6)
                    {
                        price = price - (price * 0.10);
                        if (fishermen % 2 == 0)
                        {
                            price = price - (price * 0.05);
                        }

                    }
                    else if (fishermen >= 7 && fishermen <= 11)
                    {
                        price = price - (price * 0.15);
                        if (fishermen % 2 == 0)
                        {
                            price = price - (price * 0.05);
                        }

                    }
                    else if (fishermen > 12)
                    {
                        price = price - (price * 0.25);
                        if (fishermen % 2 == 0)
                        {
                            price = price - (price * 0.05);
                        }

                    }

                    finalPrice = budget - price;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Yes! You have {finalPrice:F2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money! You need {Math.Abs(finalPrice):F2} leva.");
                    }

                    break;
            }
        }
    }
}
