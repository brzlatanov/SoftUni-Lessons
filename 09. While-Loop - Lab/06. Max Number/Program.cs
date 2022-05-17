using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;
            int input2;

            while (true)
            {

                string input = Console.ReadLine();

                if (input == "Stop")
                {

                    break;
                }
                input2 = int.Parse(input);
                if (input2 > max)
                {
                    max = input2;

                }

            }

            Console.WriteLine(max);
        }
    }
}
