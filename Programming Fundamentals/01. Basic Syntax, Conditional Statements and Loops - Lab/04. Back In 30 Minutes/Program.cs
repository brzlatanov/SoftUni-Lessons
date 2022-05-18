using System;

namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main()
        {
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            var minutesTotal = minutes + 30;

            if (minutesTotal >= 60)
            {
                hours += 1;
                minutesTotal -= 60;
                if (hours > 23)
                {
                    hours -= 24;
                }

            }

            Console.WriteLine($"{hours}:{Math.Abs(minutesTotal):D2}");
        }
    }
}
