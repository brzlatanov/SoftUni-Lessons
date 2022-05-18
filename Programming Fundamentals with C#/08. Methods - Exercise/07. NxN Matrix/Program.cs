using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 1; cols <= n; cols++)
                {
                    Console.Write(n + " ");

                }

                Console.WriteLine();
            }
        }
    }
}
