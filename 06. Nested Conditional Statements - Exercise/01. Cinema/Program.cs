using System;

namespace _01._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            double price = 0.0;

            switch (projectionType)
            {
                case "Premiere":
                    price = 12.00;
                    break;
                case "Normal":
                    price = 7.50;
                    break;
                case "Discount":
                    price = 5.00;
                    break;
            }

            double finalPrice = rows * columns * price;
            Console.WriteLine($"{finalPrice:F2} leva");
        }
    }
}
