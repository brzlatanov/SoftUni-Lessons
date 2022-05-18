using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentGrades = new Dictionary<string, List<double>>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                List<double> averageValues = new List<double>();
                string input = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentGrades.ContainsKey(input))
                {
                    studentGrades.Add(input, new List<double>());
                }

                studentGrades[input].Add(grade);

                if (studentGrades[input].Count > 0)
                {
                    double averageGrade = studentGrades[input].Average();
                    studentGrades[input].Clear();
                    studentGrades[input].Add(averageGrade);
                }
            }

            studentGrades = studentGrades.OrderByDescending(x => x.Value.Average()).ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var student in studentGrades)
            {
                if (student.Value.Average() >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():F2}");
                }
            }
        }
    }
}
