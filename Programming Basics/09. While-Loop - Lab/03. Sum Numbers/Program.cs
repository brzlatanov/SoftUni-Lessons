using System;

namespace _03._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int input2 = 0;
            int input2Sum = 0;

            while (true)
            {
                input2 = int.Parse(Console.ReadLine());
                input2Sum += input2;
                if (input2Sum >= input)
                {
                    break;
                }
            }
            Console.WriteLine(input2Sum);
        }
    }
}
