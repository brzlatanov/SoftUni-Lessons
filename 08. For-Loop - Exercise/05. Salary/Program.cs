using System;

namespace _05._Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
            string site = "";
            bool salaryLost = false;

            for (int i = 1; i <= tabs; i++)
            {
                site = Console.ReadLine();
                if (site == "Facebook")
                {
                    salary -= 150;

                }
                if (site == "Instagram")
                {
                    salary -= 100;

                }
                if (site == "Reddit")
                {
                    salary -= 50;

                }
                if (salary > 0)
                {
                    salaryLost = false;
                }
                else if (salary <= 0)
                {
                    salaryLost = true;
                    break;
                }

            }
            if (!salaryLost)
            {
                Console.WriteLine(salary);
            }
            else if (salaryLost)
            {
                Console.WriteLine("You have lost your salary.");
            }
        }
    }
}
