using System;
using System.Text;


namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            CharacterMultiplier();
        }
        static int CharacterMultiplier()
        {
            int totalSum = 0;
            string[] inputString = Console.ReadLine().Split(" ");

            if (inputString[0].Length > inputString[1].Length)
            {
                for (int i = 0; i < inputString[1].Length; i++)
                {
                    totalSum += (int)inputString[0][i] * (int)inputString[1][i];
                }
                for (int i = inputString[1].Length; i < inputString[0].Length; i++)
                {
                    totalSum += (int)inputString[0][i];
                }
            }
            else if (inputString[1].Length > inputString[0].Length)
            {
                for (int i = 0; i < inputString[0].Length; i++)
                {
                    totalSum += (int)inputString[0][i] * (int)inputString[1][i];
                }
                for (int i = inputString[0].Length; i < inputString[1].Length; i++)
                {
                    totalSum += (int)inputString[1][i];
                }
            }
            else
            {
                for (int i = 0; i < inputString[0].Length; i++)
                {
                    totalSum += (int)inputString[0][i] * (int)inputString[1][i];
                }
            }

            Console.WriteLine(totalSum);

            return totalSum;
        }
    }
}
