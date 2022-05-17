using System;

namespace _07._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0.0;

            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                area = side * side;

            }

            else if (figure == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                area = sideA * sideB;
            }

            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                area = Math.PI * radius * radius;
            }
            else if (figure == "triangle")
            {
                double sideLength = double.Parse(Console.ReadLine());

                double height = double.Parse(Console.ReadLine());
                area = sideLength * height / 2;
            }

            Console.WriteLine($"{area:F3}");
        }
    }
}
