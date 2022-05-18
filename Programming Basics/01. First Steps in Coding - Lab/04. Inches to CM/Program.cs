using System;

namespace Inches_To_CM
{
    class Program
    {
        static void Main(string[] args)
        {

            double centimeters = double.Parse(Console.ReadLine());
            double inches = centimeters * 2.54;

            Console.WriteLine(inches);

        }
    }
}