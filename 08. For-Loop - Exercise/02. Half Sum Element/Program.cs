using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int n2 = int.Parse(Console.ReadLine());
                sum += n2;
                if (n2 > max)
                {
                    max = n2;
                }

            }
            int sumWithoutMax = sum - max;
            if (max == sumWithoutMax)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + max);
            }
            else
            {
                int diff = Math.Abs(max - sumWithoutMax);
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }
        }
    }
}
