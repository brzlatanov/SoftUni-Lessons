using System;

namespace _10._Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;
            for (int i = 0; i < input; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    sumEven += number;

                }
                else
                {
                    sumOdd += number;
                }

            }
            if (sumEven == sumOdd)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumEven}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumEven - sumOdd)}");
            }
        }
    }
}
