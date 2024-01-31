using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test_coding.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test_coding.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {

        [HttpGet("sallary")]
        public IActionResult Get()
        {
            List<Employee> employees = SetEmployee();
            double totalSalary = employees.Sum(e => e.Sallary);
            double joniorSallary = employees
            .Where(e => e.Position == "Staff Junior") 
            .Sum(e => e.Sallary);

            var currentDate = DateTime.Now;
            var staffLegend = employees
                .Where(e => currentDate.Year - e.JoinDate.Year > 4 && e.Position.ToLower() != "staff junior")
                .Select(e => e.Name)
                .ToList();

            var employeeAAA = employees.FirstOrDefault(e => e.Name == "AAA");
            DateTime joinDate = employeeAAA.JoinDate;
            DateTime endDate = new DateTime(2024, 1, 31); // Akhir Januari 2024
            int totalMonths = ((endDate.Year - joinDate.Year) * 12) + endDate.Month - joinDate.Month;

            double AAASallary = employeeAAA.Sallary * totalMonths;
            var response = new
            {
                status = "sukses",
                data = new {
                    summaryofallsallary = "Rp " + totalSalary.ToString("N0"),
                    alljuniorsallary = "Rp " + joniorSallary.ToString("N0"),
                    fouryearsofservice = staffLegend,
                    sallaryofAAA = "Rp " + AAASallary.ToString("N0")
                }

            };
            return Ok(response);
        }

        private List<Employee> SetEmployee()
        {
            List<Employee> employeeData = new List<Employee>
            {
                new Employee{
                    JoinDate = new DateTime(2019, 1, 1),
                    Name = "AAA",
                    Position = "Staff Junior",
                    Sallary = 1000000
                },
                new Employee
                {
                    JoinDate = new DateTime(2021, 3, 21),
                    Name = "BBB",
                    Position = "Supervisor",
                    Sallary = 2000000
                },
                new Employee
                {
                    JoinDate = new DateTime(2017, 9, 12),
                    Name = "CCC",
                    Position = "Staff Junior",
                    Sallary = 1000000
                },
                new Employee
                {
                    JoinDate = new DateTime(2018, 12, 20),
                    Name = "DDD",
                    Position = "Staff Junior",
                    Sallary = 1000000
                },
                new Employee
                {
                    JoinDate = new DateTime(2016, 3, 16),
                    Name = "EEE",
                    Position = "Supervisor",
                    Sallary = 2000000
                },
                new Employee
                {
                    JoinDate = new DateTime(2012, 3, 12),
                    Name = "FFF",
                    Position = "Manager",
                    Sallary = 3000000
                }
            } ;

            return employeeData;

        }

    }
}

