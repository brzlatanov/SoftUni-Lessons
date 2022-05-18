using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            double exponent = double.Parse(Console.ReadLine());

            calculatePow(number, exponent);
        }

        private static void calculatePow(double number, double exponent)
        {
            double a = number;

            double power = 1;

            for (int i = 0; i < exponent; i++)
            {
                power = power * a;
            }

            Console.WriteLine(power);
        }
    }
}
