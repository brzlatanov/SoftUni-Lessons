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
            Console.WriteLine(AddNewAddressToEmployee(new SoftUniContext()));
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

            foreach (var employee in context.Employees.Where(e => e.Salary > 50000).OrderBy(e => e.FirstName))
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var data = context.Employees.Join(context.Departments, employee => employee.DepartmentId,
                department => department.DepartmentId,
                (employee, department) => new
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DepartmentName = department.Name,
                    Salary = employee.Salary
                });

            foreach (var employee in data.OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName).Where(e => e.DepartmentName == "Research and //Development"))
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

            var addressTexts = context.Employees.Join(context.Addresses, employee => employee.AddressId,
                address => address.AddressId,
                (employee, address) => new {AddressId = employee.AddressId, AddressText = address.AddressText});

            foreach (var emp in addressTexts.OrderByDescending(employee => employee.AddressId).Take(10))
            {
                sb.AppendLine(emp.AddressText);
            }

            return sb.ToString();
        }
    }
}
