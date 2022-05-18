using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int input1 = int.Parse(Console.ReadLine());
            int input2 = int.Parse(Console.ReadLine());

            if (input1 < 0)
            {
                input1 = 0;
            }

            if (input2 < 0)
            {
                input2 = 0;
            }

            long factorielofA = CalculateFactoriel1(input1);
            long factorielofB = CalculateFactoriel2(input2);

            double result = (double)factorielofA / factorielofB;

            Console.WriteLine($"{result:F2}");

        }

        private static long CalculateFactoriel2(int input2)
        {
            long factorielMultiply = 1;

            for (int i = 1; i <= input2; i++)
            {
                factorielMultiply *= i;
            }

            return factorielMultiply;
        }

        private static long CalculateFactoriel1(int input1)
        {
            long factorielMultiply = 1;

            for (int i = 1; i <= input1; i++)
            {
                factorielMultiply *= i;
            }

            return factorielMultiply;
        }
    }
}
