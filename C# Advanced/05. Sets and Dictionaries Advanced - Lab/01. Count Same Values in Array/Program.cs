using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] doubleArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Dictionary<double, int> numbersDict = new Dictionary<double, int>();

            for (int i = 0; i < doubleArray.Length; i++)
            {
                if (numbersDict.ContainsKey(doubleArray[i]))
                {
                    numbersDict[doubleArray[i]] += 1;
                }
                else
                {
                    numbersDict.Add(doubleArray[i], 1);
                }
            }

            foreach (var number in numbersDict)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
