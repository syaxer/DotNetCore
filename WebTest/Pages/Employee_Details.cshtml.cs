using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WebTest.Models;

namespace WebTest.Pages
{
    public class Employee_DetailsModel : PageModel
    {
        readonly IConfiguration _configuration;

        public Employee employeeData = new Employee();

        string connString;

        public Employee_DetailsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            GetRec();
        }

        public void OnPost()
        {
            var EmpID = Request.Form["txtEmpID"];
            Response.Redirect("Employee_Edit?EmpID=" + EmpID);
        }

        void GetRec()
        {
            int empID = Convert.ToInt32(HttpContext.Session.GetInt32("EmpID"));

            connString = _configuration.GetConnectionString("DBConnection");

            Employee employee = new Employee();
            employeeData = employee.GetEmployeeRec(connString, empID);
        }
    }
}
