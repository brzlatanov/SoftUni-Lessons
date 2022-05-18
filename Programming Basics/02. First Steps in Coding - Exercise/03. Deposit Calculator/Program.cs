using System;

namespace _03._Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int termOfDeposit = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());
            double accruedInterest = depositSum * (interest / 100);
            double interestPerMonth = accruedInterest / 12;
            double sum = depositSum + (termOfDeposit * interestPerMonth);
            Console.WriteLine(sum);
        }
    }
}
