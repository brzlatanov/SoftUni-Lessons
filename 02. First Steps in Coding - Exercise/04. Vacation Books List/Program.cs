using System;

namespace _04._Vacation_Books_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double pagesPerDay = pages / pagesPerHour;
            double neededHours = pagesPerDay / days;
            Console.WriteLine(neededHours);
        }
    }
}
