using System;

namespace _01._Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            int h;
            int m;

            for (h = 0; h <= 23; h++)
            {
                for (m = 0; m <= 59; m++)
                {
                    Console.WriteLine($"{h}:{m}");
                }
            }
        }
    }
}
