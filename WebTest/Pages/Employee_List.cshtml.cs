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
    public class Employee_ListModel : PageModel
    {
        readonly IConfiguration _configuration;

        public List<Employee> employeeParameterList = new List<Employee>();

        public string connString;

        public Employee_ListModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            Employee employee = new Employee();

            connString = _configuration.GetConnectionString("DBConnection");

            employeeParameterList = employee.GetEmployeeParameters(connString);
        }
    }
}
