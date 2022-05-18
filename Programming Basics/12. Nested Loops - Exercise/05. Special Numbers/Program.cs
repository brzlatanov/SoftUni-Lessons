using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int a = 1; a <= 9; a++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int i = 1; i <= 9; i++)
                        {
                            if (n % i == 0 && n % k == 0 && n % j == 0 && n % a == 0)
                            {
                                Console.Write($"{a}{j}{k}{i} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
