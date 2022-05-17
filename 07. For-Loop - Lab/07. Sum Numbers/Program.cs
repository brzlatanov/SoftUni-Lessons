using System;

namespace _07._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int n3 = 0;
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                n3 = int.Parse(Console.ReadLine());
                sum = sum + n3;
            }
            Console.WriteLine(sum);
        }
    }
}
