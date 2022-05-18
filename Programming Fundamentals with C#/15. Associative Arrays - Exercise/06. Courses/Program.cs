using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> studentDict = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine().Split(" : ");

            while (input[0] != "end")
            {
                if (!studentDict.ContainsKey(input[0]))
                {
                    studentDict.Add(input[0], new List<string>());
                }

                studentDict[input[0]].Add(input[1]);
                studentDict[input[0]].Sort();

                input = Console.ReadLine().Split(" : ");
            }

            studentDict = studentDict.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach (var course in studentDict)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
