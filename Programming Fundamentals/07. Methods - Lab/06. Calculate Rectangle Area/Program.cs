using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double input1 = int.Parse(Console.ReadLine());
            double input2 = int.Parse(Console.ReadLine());

            double area = CalculateArea(input1, input2);
            Console.WriteLine(area);
        }

        static double CalculateArea(double input1, double input2)
        {
            return input1 * input2;
        }
    }
}
