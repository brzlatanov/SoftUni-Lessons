using System;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int arrCounter = 0;
            int trueCounter = 0;
            bool areEqual = false;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    break;
                }
                if (arr1[i] == arr2[i])
                {
                    arrCounter += arr1[i];

                    trueCounter++;
                    if (trueCounter == arr1.Length && trueCounter == arr2.Length)
                    {
                        areEqual = true;
                    }

                }
            }
            if (areEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {arrCounter}");
            }
        }
    }
}
