using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue;
            int input2;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }
                input2 = int.Parse(input);
                if (input2 < min)
                {
                    min = input2;
                }
            }
            Console.WriteLine(min);
        }
    }
}
