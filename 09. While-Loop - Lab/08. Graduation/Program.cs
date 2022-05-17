using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grade = 0.0;
            int classes = 0;
            int failedClass = 0;
            double gradeSum = 0.0;
            while (true)
            {
                grade = double.Parse(Console.ReadLine());
                gradeSum += grade;
                if (grade >= 4.00)
                {
                    classes++;
                }
                else if (grade < 4.00)
                {
                    failedClass += 1;

                    if (failedClass == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {classes + 1} grade");
                        break;
                    }
                }
                if (classes == 12)
                {
                    Console.WriteLine($"{name} graduated. Average grade: {(gradeSum / classes):F2}");
                    break;
                }
            }
        }
    }
}
