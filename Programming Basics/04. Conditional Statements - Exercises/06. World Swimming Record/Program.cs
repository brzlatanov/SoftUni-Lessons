using System;

namespace _06._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {   
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secondPerMeter = double.Parse(Console.ReadLine());
            double time = distance * secondPerMeter;
            double resistance = Math.Floor(distance / 15);
            double finalTime = time + (resistance * 12.5);
            double remainingSeconds = finalTime - record;

            if (finalTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {finalTime:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {remainingSeconds:F2} seconds slower.");
            }
        }
    }
}
