using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            double inputSum = 0.0;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "NoMoreMoney")
                {
                    Console.WriteLine($"Total: {inputSum:F2}");
                    break;
                }
                if (double.Parse(input) > 0)
                {
                    inputSum += double.Parse(input);
                    double input2 = double.Parse(input);
                    Console.WriteLine($"Increase: {input2:F2}");
                }
                if (double.Parse(input) < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine($"Total: {inputSum:F2}");
                    break;
                }
            }
        }
    }
}
