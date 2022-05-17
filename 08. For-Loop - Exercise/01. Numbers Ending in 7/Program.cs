using System;

namespace _01._Numbers_Ending_in_7
{
	class Program
    {
        static void Main(string[] args)
        {
            for (int i = 7; i <= 997; i++)
            {
                int a = 7;
                int b = i % 10;

                if (i % 10 == 7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
