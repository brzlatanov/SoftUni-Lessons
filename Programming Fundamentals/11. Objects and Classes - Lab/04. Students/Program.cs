using System;
using System.Collections.Generic;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentInfo = Console.ReadLine();
            List<Student> allStudents = new List<Student>();

            while (studentInfo != "end")
            {
                string[] data = studentInfo.Split();
                Student newStudent = new Student();

                newStudent.FirstName = data[0];
                newStudent.LastName = data[1];
                newStudent.Age = int.Parse(data[2]);
                newStudent.Hometown = data[3];

                allStudents.Add(newStudent);
                studentInfo = Console.ReadLine();
            }

            string city = Console.ReadLine();

            foreach (Student student in allStudents)
            {
                if (student.Hometown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
    }
}
