using System;

namespace _08._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int other = int.Parse(Console.ReadLine());
            double dogfood = 2.50;
            int otherfood = 4;

            double result1 = dogs * dogfood;
            int result2 = other * otherfood;


            double FinalResult = result1 + result2;
            Console.WriteLine($"{FinalResult} lv.");
        }
    }
}
