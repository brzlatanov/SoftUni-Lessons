using System;

namespace _04._Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = 1;

            Console.WriteLine(1);

            for (int pow = 2; pow <= n; pow++)
            {
                if (pow % 2 == 0)

                {
                    number *= 2 * 2;
                    Console.WriteLine(number);
                }
            }
        }
    }
}
