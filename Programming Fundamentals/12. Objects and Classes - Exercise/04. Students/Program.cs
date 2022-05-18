using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentCount = int.Parse(Console.ReadLine());

            List<Student> studentList = new List<Student>();

            for (int i = 0; i < studentCount; i++)
            {

                string[] studentInfo = Console.ReadLine().Split(" ");
                Student studentObject = new Student(studentInfo[0], studentInfo[1], double.Parse(studentInfo[2]));
                studentList.Add(studentObject);
            }

            studentList = studentList.OrderByDescending(studentObject => studentObject.Grade).ToList();

            Console.WriteLine(string.Join("\n", studentList));
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string secondName, double grade)
        {
            FirstName = firstName;
            SecondName = secondName;
            Grade = grade;
        }
        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade:F2}";
        }
    }
}
