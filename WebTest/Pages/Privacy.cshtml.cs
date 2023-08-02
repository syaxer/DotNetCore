using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest.Models;

namespace WebTest.Pages
{
    public class PrivacyModel : PageModel
    {
        readonly IConfiguration _configuration;

        public Employee employeeData = new Employee();

        public string connString;

        //private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            GetRec();
        }

        public void OnPost()
        {
            Logout();
        }

        void GetRec()
        {
            Employee employee = new Employee();

            int empID = Convert.ToInt32(HttpContext.Session.GetInt32("EmpID"));

            connString = _configuration.GetConnectionString("DBConnection");

            employeeData = employee.GetEmployeeRec(connString, empID);

            ViewData["username"] = HttpContext.Session.GetString("username");
        }

        void Logout()
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                HttpContext.Session.Clear();
                Response.Redirect("/Login");
            }
            else
            {
                GetRec();
            }
        }
    }
}
