using System;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string finalResult = String.Empty;

            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    finalResult += input[i];
                }
            }

            Console.WriteLine(finalResult);
        }
    }
}
