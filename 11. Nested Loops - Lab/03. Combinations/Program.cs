using System;

namespace _03._Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 0;
            int number2 = 0;
            int number3 = 0;
            int magicNumber = int.Parse(Console.ReadLine());
            int combinations = 0;

            for (number1 = 0; number1 <= magicNumber; number1++)
            {
                for (number2 = 0; number2 <= magicNumber; number2++)
                {
                    for (number3 = 0; number3 <= magicNumber; number3++)
                    {
                        if (number1 + number2 + number3 == magicNumber)
                        {
                            combinations++;
                        }
                    }
                }

            }
            Console.WriteLine(combinations);
        }
    }
}
