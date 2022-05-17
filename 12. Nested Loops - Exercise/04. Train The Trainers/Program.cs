using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double score;
            double assessment;
            double finalAssessment = 0;
            int count = 0;
            while (input != "Finish")
            {

                assessment = 0;
                for (int i = 1; i <= n; i++)
                {
                    score = double.Parse(Console.ReadLine());
                    assessment += score;
                    finalAssessment += score;
                    count++;
                }
                assessment = assessment / n;
                Console.WriteLine($"{input} - {assessment:F2}.");

                input = Console.ReadLine();

            }
            finalAssessment = finalAssessment / count;
            Console.WriteLine($"Student's final assessment is {finalAssessment:F2}.");
        }
    }
}
