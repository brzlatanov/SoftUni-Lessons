using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Print(input);
        }
        static void Print(int input)
        {
            for (int i = 1; i <= input; i++)
            {
                Printer(i);
            }
            for (int i = input - 1; i >= 1; i--)
            {
                Printer(i);
            }
        }

        private static void Printer(int i)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j + " ");
            }

            Console.WriteLine();
        }
    }
}
