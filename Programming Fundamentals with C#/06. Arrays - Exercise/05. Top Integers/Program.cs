using System;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j] >= input[i])
                    {
                        break;
                    }
                    if (j == input.Length - 1)
                    {
                        Console.Write(input[i] + " ");
                    }
                }

                if (i == input.Length - 1)
                {
                    Console.Write(input[i] + " ");
                }
            }
        }
    }
}
