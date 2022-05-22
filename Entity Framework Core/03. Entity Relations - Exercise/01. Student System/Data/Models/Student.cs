using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; } = new List<Homework>();
        public ICollection<StudentCourse> CourseEnrollments { get; set; } = new List<StudentCourse>();
    }
}