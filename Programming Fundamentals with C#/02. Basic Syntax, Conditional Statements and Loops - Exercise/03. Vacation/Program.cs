using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleNumber = int.Parse(Console.ReadLine());
            var typeOfGroup = Console.ReadLine();
            var dayOfWeek = Console.ReadLine();

            double price = 0;
            switch (dayOfWeek)
            {
                case "Friday":
                    if (typeOfGroup == "Students")
                    {
                        price = 8.45;
                    }
                    else if (typeOfGroup == "Business")
                    {
                        price = 10.90;
                    }
                    else if (typeOfGroup == "Regular")
                    {
                        price = 15.00;
                    }

                    break;
                case "Saturday":
                    if (typeOfGroup == "Students")
                    {
                        price = 9.80;
                    }
                    else if (typeOfGroup == "Business")
                    {
                        price = 15.60;
                    }
                    else if (typeOfGroup == "Regular")
                    {
                        price = 20.00;
                    }

                    break;
                case "Sunday":
                    if (typeOfGroup == "Students")
                    {
                        price = 10.46;
                    }
                    else if (typeOfGroup == "Business")
                    {
                        price = 16.00;
                    }
                    else if (typeOfGroup == "Regular")
                    {
                        price = 22.50;
                    }
                    break;
            }
            if (typeOfGroup == "Students" && peopleNumber >= 30)
            {
                price = price - price * 0.15;
            }
            if (typeOfGroup == "Business" && peopleNumber >= 100)
            {
                peopleNumber -= 10;
            }
            if (typeOfGroup == "Regular" && peopleNumber >= 10 && peopleNumber <= 20)
            {
                price = price - price * 0.05;
            }
            Console.WriteLine($"Total price: {(price * peopleNumber):f2}");
        }
    }
}
