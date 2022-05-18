using System;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int inputEven = 0;
            int inputOdd = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    inputEven += input[i];
                }
                else if (input[i] % 2 != 0)
                {
                    inputOdd += input[i];
                }


            }

            Console.WriteLine(inputEven - inputOdd);
        }
    }
}
