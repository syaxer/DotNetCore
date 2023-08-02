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
    public class ApproveLeave_ListModel : PageModel
    {
        readonly IConfiguration _configuration;

        public List<Employee> employeeParameterList = new List<Employee>();

        public string connString;

        public ApproveLeave_ListModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            GetRec();
        }

        public void OnPost()
        {
            //SearchRec();
        }

        void GetRec()
        {
            int ApproverID = Convert.ToInt32(HttpContext.Session.GetInt32("EmpID"));
            var empID = string.Empty;
            var empName = string.Empty;

            Employee employee = new Employee();

            connString = _configuration.GetConnectionString("DBConnection");

            employeeParameterList = employee.GetEmployeeLeaveList(connString, ApproverID, empID, empName);
        }

        void SearchRec()
        {
            int ApproverID = Convert.ToInt32(HttpContext.Session.GetInt32("EmpID"));
            var empID = Request.Form["txtEmpID"].ToString();
            var empName = Request.Form["txtEmpName"].ToString();

            Employee employee = new Employee();

            connString = _configuration.GetConnectionString("DBConnection");

            employeeParameterList = employee.GetEmployeeLeaveList(connString, ApproverID, empID, empName);
        }
    }
}
