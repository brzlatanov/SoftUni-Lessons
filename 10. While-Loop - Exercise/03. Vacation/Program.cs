using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double moneyAvailable = double.Parse(Console.ReadLine());
            double daysPassed = 0;
            double spendingCounter = 0;

            while (true)
            {
                string action = Console.ReadLine();
                double actionSum = double.Parse(Console.ReadLine());

                if (action == "spend")
                {
                    moneyAvailable -= actionSum;
                    daysPassed++;
                    spendingCounter++;

                }
                if (action == "save")
                {
                    moneyAvailable += actionSum;
                    daysPassed++;
                    spendingCounter = 0;
                }
                if (moneyAvailable < 0)
                {
                    moneyAvailable = 0;
                }
                if (spendingCounter == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(daysPassed);
                    break;
                }
                if (moneyAvailable >= moneyNeeded)
                {
                    Console.WriteLine($"You saved the money for {daysPassed} days.");
                    break;
                }
            }
        }
    }
}
