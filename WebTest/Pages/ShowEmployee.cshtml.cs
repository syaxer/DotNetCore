using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WebTest.Models;

namespace WebTest.Pages
{
    public class ShowEmployeeModel : PageModel
    {
        readonly IConfiguration _configuration;
        public string connString;
        public List<Employee> employeeList = new List<Employee>();

        public ShowEmployeeModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            connString = _configuration.GetConnectionString("DBConnection");

            int empType = int.Parse(Request.Query["EmployeeType"]);

            Employee employee = new Employee();
            employeeList = employee.GetEmployeeType(connString, empType);
        }
    }
}
