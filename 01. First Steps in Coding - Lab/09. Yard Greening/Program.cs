using System;

namespace _09._Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareMeters = double.Parse(Console.ReadLine());
            const double pricePersq = 7.61;
            double initialPrice = (pricePersq * squareMeters);
            double finalprice = (initialPrice - (initialPrice * 0.18));
            double discount = (initialPrice * 0.18);

            Console.WriteLine($"The final price is: {finalprice} lv.");
            Console.WriteLine($"The discount is {discount} lv.");
        }
    }
}
