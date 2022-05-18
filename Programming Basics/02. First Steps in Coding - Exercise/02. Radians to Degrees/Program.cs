using System;

namespace _02._Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double radian = double.Parse(Console.ReadLine());
            double degree = radian * 180 / Math.PI;
            degree = Math.Round(degree);
            Console.WriteLine(degree);
        }
    }
}
