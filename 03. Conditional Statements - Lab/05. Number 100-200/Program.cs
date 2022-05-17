using System;

namespace _05._Number_100_200
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());
            int hundred = 100;

            if (numberInput < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if ((numberInput >= 100) && (numberInput <= 200))
            {
                Console.WriteLine("Between 100 and 200");
            }
            else if (numberInput > 200)
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}
