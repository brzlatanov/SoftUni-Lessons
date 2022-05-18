using System;

namespace _07._Projects_creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projNumber = int.Parse(Console.ReadLine());
            int time = projNumber * 3;

            Console.WriteLine($"The architect {name} will need {time} hours to complete {projNumber} project/s.");
        }
    }
}
