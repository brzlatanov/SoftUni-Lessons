using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int intervalStart = int.Parse(Console.ReadLine());
            int intervalEnd = int.Parse(Console.ReadLine());
            int magicalNum = int.Parse(Console.ReadLine());
            int counter = 0;
            int falseCounter = 0;
            bool endCycle = false;

            for (int i = intervalStart; i <= intervalEnd; i++)
            {
                for (int j = intervalStart; j <= intervalEnd; j++)
                {
                    counter++;
                    if (i + j == magicalNum)
                    {
                        endCycle = true;
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicalNum})");
                        break;
                    }
                    else if (i + j != magicalNum)
                    {

                        if (i >= intervalEnd && j >= intervalEnd)
                        {
                            Console.WriteLine($"{counter} combinations - neither equals {magicalNum}");
                            endCycle = true;
                            break;
                        }
                    }
                }
                if (endCycle)
                {
                    break;
                }
            }
        }
    }
}
