using System;

namespace _01._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            Random random = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                int swapPosition = random.Next(input.Length);
                string temp = input[i];
                input[i] = input[swapPosition];
                input[swapPosition] = temp;
            }

            Console.WriteLine(string.Join("\n", input));
        }
    }
}
