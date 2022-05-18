using System;

namespace _03._Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal firstNum = decimal.Parse(Console.ReadLine());
            decimal secondNum = 0;
            decimal thirdNum = 0;
            decimal secondNumCounter = 0;

            for (int i = 0; i < firstNum; i++)
            {
                secondNum = decimal.Parse(Console.ReadLine());
                secondNumCounter += secondNum;
            }

            Console.WriteLine(secondNumCounter);
        }
    }
}
