using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (isDivisibleBy8(i) && ContainsOddDigit(i))
                    Console.WriteLine(i);
            }
        }

        private static bool ContainsOddDigit(int number)
        {
            while (number > 0)
            {
                int currentDigit = number % 10;

                if (currentDigit % 2 == 1)
                {
                    return true;
                }

                number /= 10;
            }
            return false;
        }

        private static bool isDivisibleBy8(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            bool isDivisible = sum % 8 == 0;

            return isDivisible;
        }
    }
}
