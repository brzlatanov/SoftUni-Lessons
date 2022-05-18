using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int integer = int.Parse(Console.ReadLine());
            int sum = 0;
            int number = 0;

            while (integer > 0)
            {
                number = integer % 10;

                sum += number;
                integer = integer / 10;
            }

            Console.WriteLine(sum);
        }
    }
}
