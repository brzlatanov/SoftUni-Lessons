using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMOney = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            var totalSum = priceOfLightsabers * Math.Ceiling(studentsCount * 1.1) + priceOfRobes * studentsCount + priceOfBelts * (studentsCount - (studentsCount / 6));

            if (amountOfMOney >= totalSum)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalSum - amountOfMOney:F2}lv more.");
            }
        }
    }
}
