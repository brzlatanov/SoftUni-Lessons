using System;

namespace _03._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputHour = int.Parse(Console.ReadLine());
            int inputMinute = int.Parse(Console.ReadLine());


            inputMinute = inputMinute + 15;
            if (inputMinute >= 60)
            {
                inputMinute = inputMinute - 60;
                inputHour = inputHour + 1;
            }
            if (inputHour >= 24)
                inputHour = inputHour - 24;
            if (inputMinute < 10)
                Console.WriteLine($"{inputHour}:0{inputMinute}");
            else
                Console.WriteLine($"{inputHour}:{inputMinute}");
        }
    }
}
