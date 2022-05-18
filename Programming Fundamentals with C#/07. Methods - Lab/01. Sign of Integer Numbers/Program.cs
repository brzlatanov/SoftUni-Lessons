using System;

namespace _01._Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            PositiveChecker(input);
        }

        static void PositiveChecker(int input)
        {
            if (input > 0)
            {
                Console.WriteLine($"The number {input} is positive.");
            }

            if (input < 0)
                Console.WriteLine($"The number {input} is negative.");
            else
            {
                Console.WriteLine($"The number {input} is zero.");
            }
        }
    }
}
