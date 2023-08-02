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
    public class HomeModel : PageModel
    {
        readonly IConfiguration _configuration;

        public Employee employeeData = new Employee();

        public string connString;

        public HomeModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string strEmpID = Request.Form["EmpID"];
            int empID = int.Parse(strEmpID);

            Employee employee = new Employee();

            connString = _configuration.GetConnectionString("DBConnection");

            employeeData = employee.GetEmployeeRec(connString, empID);
        }
    }
}
