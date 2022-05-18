using System;

namespace _07._Fruit_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine());
            double bananaAmount = double.Parse(Console.ReadLine());
            double orangeAmount = double.Parse(Console.ReadLine());
            double raspberryAmount = double.Parse(Console.ReadLine());
            double strawberryAmount = double.Parse(Console.ReadLine());
            double raspberryPrice = strawberryPrice / 2;
            double orangePrice = raspberryPrice - (raspberryPrice * 0.40);
            double bananaPrice = raspberryPrice - (raspberryPrice * 0.80);
            double totalSum = (strawberryAmount * strawberryPrice) + (bananaAmount * bananaPrice) + (orangeAmount * orangePrice) + (raspberryAmount * raspberryPrice);
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
