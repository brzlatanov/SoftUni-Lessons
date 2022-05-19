using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentDict = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string studentName = input[0];
                decimal studentGrade = decimal.Parse(input[1]);

                if (studentGrade < 2)
                {
                    continue;
                }

                if (studentDict.ContainsKey(studentName))
                {
                    studentDict[studentName].Add(studentGrade);
                }
                else
                {
                    studentDict.Add(studentName, new List<decimal> { studentGrade });
                }
            }

            foreach (var student in studentDict)
            {
                Console.Write($"{student.Key} -> ");

                foreach (double grade in student.Value)
                {
                    Console.Write($"{grade:F2}" + " ");
                }

                Console.Write($"(avg: {student.Value.Average():F2})");
                Console.WriteLine();
            }
        }
    }
}
