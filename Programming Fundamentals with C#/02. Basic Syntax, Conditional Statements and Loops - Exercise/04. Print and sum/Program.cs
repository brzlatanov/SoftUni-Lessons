using System;

namespace _04._Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var number1 = int.Parse(Console.ReadLine());
            var number2 = int.Parse(Console.ReadLine());
            var iCounter = 0;

            for (int i = number1; i <= number2; i++)
            {
                Console.Write($"{i} ");
                iCounter += i;

            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {iCounter}");
        }
    }
}
