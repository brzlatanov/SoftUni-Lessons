using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            Dictionary<string, int> arrayDict = new Dictionary<string, int>();

            foreach (var word in array)
            {
                string wordInLowerCase = word.ToLower();

                if (arrayDict.ContainsKey(wordInLowerCase))
                {
                    arrayDict[wordInLowerCase]++;
                }
                else
                {
                    arrayDict.Add(wordInLowerCase, 1);
                }
            }
            foreach (var word in arrayDict)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write(word.Key + " ");
                }
            }
        }
    }
}
