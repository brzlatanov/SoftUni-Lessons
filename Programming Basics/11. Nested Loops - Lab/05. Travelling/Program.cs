using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyCollected = 0;
            string destination = "";
            string moneyNeeded = "";

            destination = Console.ReadLine();
            moneyNeeded = Console.ReadLine();
            while (destination != "End")
            {
                while (destination != "End")
                {
                    string moneyInput = Console.ReadLine();
                    moneyCollected += double.Parse(moneyInput);
                    if (moneyCollected >= double.Parse(moneyNeeded))
                    {
                        Console.WriteLine($"Going to {destination}!");

                        destination = Console.ReadLine();
                        if (destination == "End")
                        {
                            return;
                        }
                        moneyNeeded = Console.ReadLine();
                        moneyCollected = 0;

                    }
                }
            }
        }
    }
}
