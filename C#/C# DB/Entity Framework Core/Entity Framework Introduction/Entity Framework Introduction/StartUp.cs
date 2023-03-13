﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SoftUni.Models;
using SoftUni.Data;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
            }
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var Employees = context.Employees.ToList().OrderBy(e => e.EmployeeId);
            StringBuilder output = new StringBuilder();
            foreach (var employee in Employees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
            return output.ToString();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var Employees = context.Employees.Where(x => x.Salary>50000).ToList().OrderBy(e => e.FirstName);
            StringBuilder output = new StringBuilder();
            foreach (var employee in Employees)
            {
                output.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }
            return output.ToString();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var Employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e=>e.FirstName)
                .ToList();
            StringBuilder output = new StringBuilder();
            foreach (var employee in Employees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - {employee.Salary:f2}");
            }
            return output.ToString().Trim();
        }
    }
}