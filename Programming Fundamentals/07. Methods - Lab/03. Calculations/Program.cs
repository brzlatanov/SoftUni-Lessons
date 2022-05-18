using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double number1 = int.Parse(Console.ReadLine());
            double number2 = int.Parse(Console.ReadLine());

            if (input == "add")
            {
                add(input, number1, number2);
            }
            else if (input == "multiply")
            {
                multiply(input, number1, number2);
            }
            else if (input == "divide")
            {
                divide(input, number1, number2);
            }
            else if (input == "subtract")
            {
                subtract(input, number1, number2);
            }
        }

        private static void subtract(string input, double number1, double number2)
        {
            double result = number1 - number2;
            Console.WriteLine(result);
        }

        private static void divide(string input, double number1, double number2)
        {
            double result = number1 / number2;
            Console.WriteLine(result);
        }

        private static void multiply(string input, double number1, double number2)
        {
            double result = number1 * number2;
            Console.WriteLine(result);
        }

        private static void add(string input, double number1, double number2)
        {
            double result = number1 + number2;
            Console.WriteLine(result);
        }
    }
}
