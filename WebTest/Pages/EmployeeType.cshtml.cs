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
    public class EmployeeTypeModel : PageModel
    {
        readonly IConfiguration _configuration;

        public List<Employee> employeeList = new List<Employee>();

        public string connString;

        public EmployeeTypeModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            connString = _configuration.GetConnectionString("DBConnection");

            Employee employee = new Employee();
            employeeList = employee.LookupEmployeeType(connString);
        }
    }
}
