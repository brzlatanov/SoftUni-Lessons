using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> letterOccurrance = new Dictionary<char, int>();
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    char key = input[i][j];

                    if (!letterOccurrance.ContainsKey(key))
                    {
                        letterOccurrance.Add(key, 1);
                    }
                    else
                    {
                        letterOccurrance[key]++;
                    }
                }
            }

            foreach (var letter in letterOccurrance)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
