using System;

namespace _12._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double volume = double.Parse(Console.ReadLine());
            double commission = 0.0;

            bool isError = false;

            if (city == "Sofia")
            {
                if (volume >= 0 && volume <= 500)
                {
                    commission = 0.05;
                }
                else if (volume > 500 && volume <= 1000)
                {
                    commission = 0.07;
                }
                else if (volume > 1000 && volume <= 10000)
                {
                    commission = 0.08;
                }
                else if (volume > 10000)
                {
                    commission = 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                    isError = true;
                }

            }
            else if (city == "Varna")
            {
                if (volume >= 0 && volume <= 500)
                {
                    commission = 0.045;
                }
                else if (volume > 500 && volume <= 1000)
                {
                    commission = 0.075;
                }
                else if (volume > 1000 && volume <= 10000)
                {
                    commission = 0.10;
                }
                else if (volume > 10000)
                {
                    commission = 0.13;
                }
                else
                {
                    Console.WriteLine("error");
                    isError = true;
                }
            }

            else if (city == "Plovdiv")
            {
                if (volume >= 0 && volume <= 500)
                {
                    commission = 0.055;
                }
                else if (volume > 500 && volume <= 1000)
                {
                    commission = 0.08;
                }
                else if (volume > 1000 && volume <= 10000)
                {
                    commission = 0.12;
                }
                else if (volume > 10000)
                {
                    commission = 0.145;
                }
                else
                {
                    Console.WriteLine("error");
                    isError = true;
                }

            }
            else
            {
                Console.WriteLine("error");
                isError = true;
            }
            if (!isError)
            {
                double commissionSize = volume * commission;
                Console.WriteLine("{0:F2}", commissionSize);
            }
        }
    }
}
