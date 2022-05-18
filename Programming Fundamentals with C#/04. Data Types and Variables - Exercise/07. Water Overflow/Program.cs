using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;
            byte n = byte.Parse(Console.ReadLine());
            int nGatherer = 0;

            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                nGatherer += liters;
                if (nGatherer > capacity)
                {
                    nGatherer -= liters;
                    Console.WriteLine("Insufficient capacity!");
                }

            }

            if (nGatherer > capacity)
            {
                Console.WriteLine("255");
            }
            else if (nGatherer <= capacity)
            {
                Console.WriteLine(nGatherer);
            }
        }
    }
}
