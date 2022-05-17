using System;

namespace _05._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "";
            double moneySpent = 0.0;
            string accomodation = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    accomodation = "Camp";
                    budget = (budget * 0.30);
                }
                else if (season == "winter")
                {
                    accomodation = "Hotel";
                    budget = (budget * 0.70);
                }
                Console.WriteLine("Somewhere in Bulgaria");
                Console.WriteLine($"{accomodation} - {budget:F2}");
            }
            if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    accomodation = "Camp";
                    budget = (budget * 0.40);
                }
                else if (season == "winter")
                {
                    accomodation = "Hotel";
                    budget = (budget * 0.80);
                }
                Console.WriteLine("Somewhere in Balkans");
                Console.WriteLine($"{accomodation} - {budget:F2}");
            }
            if (budget > 1000)
            {
                destination = "Europe";
                accomodation = "Hotel";
                budget = (budget * 0.90);
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"{accomodation} - {budget:F2}");
            }
        }
    }
}
