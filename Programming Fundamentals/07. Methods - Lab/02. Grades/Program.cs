using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());

            Grade(input);
        }

        private static void Grade(double input)
        {
            if (input >= 2 && input <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (input >= 3 && input <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if (input >= 3.50 && input <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if (input >= 4.50 && input <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else if (input >= 5.50 && input <= 6)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}
