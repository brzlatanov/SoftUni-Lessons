using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            if (startingYield < 0 || startingYield > 2147483647)
            {
                return;
            }

            int extractedSpice = 0;
            int consumedFood = 0;
            int daysOperated = 0;

            while (startingYield >= 100)
            {
                extractedSpice += startingYield - 26;
                startingYield -= 10;
                daysOperated++;
            }

            if (daysOperated > 0)
            {
                extractedSpice -= 26;
            }

            Console.WriteLine(daysOperated);
            Console.WriteLine(extractedSpice);
        }
    }
}
