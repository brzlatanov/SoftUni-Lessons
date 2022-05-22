using System;
using System.Collections.Generic;
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
            Console.WriteLine(IncreaseSalaries(new SoftUniContext()));
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

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses.OrderByDescending(a => a.Employees.Count).ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText).Select(a => new {a.AddressText, TownName = a.Town.Name, EmployeesCount = a.Employees.Count}).Take(10);

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            int employeeId = 147;

            var employee147 = context.Employees.Where(e => e.EmployeeId == employeeId)
                .Select(e => new {e.FirstName,  e.LastName, e.JobTitle}).FirstOrDefault();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var employeeProject in context.EmployeesProjects.Where(ep=> ep.EmployeeId == employeeId).Select(ep => new{ep.Project.Name}).OrderBy(ep => ep.Name))
            {
                sb.AppendLine(employeeProject.Name);
            }
           
            return sb.ToString();

        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            int employeeCount = 5;

            var departments = context.Departments.Where(d => d.Employees.Count > employeeCount).Select(d=> new {DepartmentId = d.DepartmentId, DepartmentName = d.Name, EmployeeCount = d.Employees.Count, ManagerFirstName = d.Manager.FirstName, ManagerLastName = d.Manager.LastName}).OrderBy(d=> d.EmployeeCount).ThenBy(d=> d.DepartmentName);

            var employees = context.Employees;

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in employees.Where(e => e.DepartmentId == department.DepartmentId).OrderBy(e => e.FirstName).ThenBy(e=> e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects.OrderByDescending(p => p.StartDate).Take(10);

            foreach (var project in projects.OrderBy(p=> p.Name))
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services").OrderBy(e=> e.FirstName).ThenBy(e=> e.LastName);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                employee.Salary += employee.Salary * 0.12M;
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString();
        }
    }
}
