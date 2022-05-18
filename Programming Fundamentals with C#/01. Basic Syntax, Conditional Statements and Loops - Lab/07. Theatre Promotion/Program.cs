using System;

namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main()
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double price = 0.0;
            switch (day)
            {
                case "Weekday":
                    if (age <= 18 && age >= 0)
                    {
                        price = 12;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price = 18;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        price = 12;
                    }
                    break;
                case "Weekend":
                    if (age <= 18 && age >= 0)
                    {
                        price = 15;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price = 20;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        price = 15;
                    }
                    break;
                case "Holiday":
                    if (age <= 18 && age >= 0)
                    {
                        price = 5;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price = 12;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        price = 10;
                    }
                    break;

            }
            if (age < 0 || age > 122)
            {
                Console.WriteLine("Error!");
                return;
            }

            Console.WriteLine(price + "$");
        }
    }
}
