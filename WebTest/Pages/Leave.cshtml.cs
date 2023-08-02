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
    public class LeaveModel : PageModel
    {
        readonly IConfiguration _configuration;

        public List<Employee> employeeList = new List<Employee>();
        public Employee employeeData = new Employee();

        public string connString;

        public LeaveModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            EmployeeList();
        }

        public void OnPost()
        {
            EmployeeList();
            GetEmployee();
        }

        private void EmployeeList()
        {
            connString = _configuration.GetConnectionString("DBConnection");

            Employee employee = new Employee();           
            employeeList = employee.LookupEmployeeData(connString);
        }

        private void GetEmployee()
        {
            int empID = int.Parse(Request.Form["SelectedEmployee"]);

            connString = _configuration.GetConnectionString("DBConnection");

            Employee employee = new Employee();
            employeeData = employee.GetEmployeeLeaveRec(connString, empID, null);
        }
    }
}
