using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int repetitions = int.Parse(Console.ReadLine());

            CalculateArea(text, repetitions);
        }

        private static string CalculateArea(string text, int repetitions)
        {
            string textCounter = "";

            for (int i = 0; i < repetitions; i++)
            {
                textCounter += text;
            }

            Console.WriteLine(textCounter);

            return (text);
        }
    }
}
