using System;

namespace _07._Working_Hours
{
    class Program
    {
        static void Main(string[] args)
        {

            {
                int dayHour = int.Parse(Console.ReadLine());
                string dayWeek = Console.ReadLine();
                string workingDays;

                if (dayHour >= 10 && dayHour <= 18)
                {
                    switch (dayWeek)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                        case "Saturday":
                            Console.WriteLine("open");
                            break;
                        default:
                            Console.WriteLine("closed");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("closed");
                }
            }
        }
    }
}
