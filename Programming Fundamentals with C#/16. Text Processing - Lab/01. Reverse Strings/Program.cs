using System;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                string inputReverse = "";

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    inputReverse += input[i];
                }

                Console.WriteLine($"{input} = {inputReverse}");

                input = Console.ReadLine();
            }
        }
    }
}
