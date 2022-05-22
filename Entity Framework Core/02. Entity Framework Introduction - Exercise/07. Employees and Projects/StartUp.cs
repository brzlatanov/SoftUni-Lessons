using System;
using System.Globalization;
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
            Console.WriteLine(GetEmployeesInPeriod(new SoftUniContext()));
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

            foreach (var employee in context.Employees.Where(e => e.Salary > 50000).OrderBy(e => e.Department.Name))
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName).Select(e =>
                    new {e.FirstName, e.LastName, DepartmentName = e.Department.Name, e.Salary}).ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employee = context.Employees.Where(e => e.LastName == "Nakov").FirstOrDefault();
            employee.Address = new Address {AddressText = "Vitoshka 15", TownId = 4};
            context.SaveChanges();

            var addressTexts = context.Employees.OrderByDescending(e => e.AddressId).Select(e=> new{e.Address.AddressText}).Take(10).ToArray();

            foreach (var emp in addressTexts)
            {
                sb.AppendLine(emp.AddressText);
            }

            return sb.ToString();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();


            var employees = context.Employees.Join(context.Projects,
                employee => employee.EmployeeId,
                project => project.ProjectId,
                (employee, project) => new
                {
                    EmployeeFirstName = employee.FirstName,
                    EmployeeLastName = employee.LastName,
                    ManagerFirstName = employee.Manager.FirstName,
                    ManagerLastName = employee.Manager.LastName,
                    ProjectStartDate = project.StartDate,
                    ProjectEndDate = project.EndDate,
                    ProjectList = employee.EmployeesProjects.Select(p=> new{p.Project.Name, p.Project.StartDate, p.Project.EndDate})
                }).Where(e => e.ProjectStartDate.Year >= 2001 && e.ProjectStartDate.Year <= 2003).Take(10).ToArray();

            foreach (var emp in employees)
            {
                sb.AppendLine(
                    $"{emp.EmployeeFirstName} {emp.EmployeeLastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                foreach (var project in emp.ProjectList)
                {
                    if (project.EndDate == null)
                    {
                        sb.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - not finished");
                    }
                    else if(project.EndDate != null)
                    {
                        sb.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {((DateTime)project.EndDate).ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
                    }
                }
            }

            return sb.ToString();
        }
    }
}
