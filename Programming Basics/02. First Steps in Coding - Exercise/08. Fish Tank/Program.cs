using System;

namespace _08._Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length= int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            double capacity = length* width * height;
            double waterCapacity = capacity * 0.001;
            double waterVolume = waterCapacity * (1 - (percent * 0.01));
            Console.WriteLine(waterVolume);
        }
    }
}
