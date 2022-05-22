using System;
using System.Linq;
using System.Text;
using SoftUni.Data;

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

            foreach (var employee in context.Employees.OrderBy(e => e.EmployeeId))
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            using (context)
            {
                foreach (var employee in context.Employees.Where(e => e.Salary > 50000).OrderBy(e => e.FirstName))
                {
                    sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
                }
            }
            return sb.ToString();
        }
    }
}
