using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string biggestModel = "";
            double volumeMax = double.MinValue;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double volume = Math.PI * (radius * radius) * height;

                if (volume > volumeMax)
                {
                    volumeMax = volume;
                    biggestModel = model;
                }
            }

            Console.WriteLine(biggestModel);
        }
    }
}
