using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int input1 = int.Parse(Console.ReadLine());
            int input2 = int.Parse(Console.ReadLine());

            for (int i = input1; i <= input2; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
