using System;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetEmployeesFullInformation(new SoftUniContext()));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            using (context)
            {
                foreach (var employee in context.Employees.OrderBy(e => e.EmployeeId))
                {
                    sb.AppendLine(
                        $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
                }

                return sb.ToString();
            }
        }
    }
}
