using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WebTest.Models;

namespace WebTest.Pages
{
    public class Employee_EditModel : PageModel
    {
        readonly IConfiguration _configuration;
        public string connString;
        public Employee employeeDetails = new Employee();

        public Employee_EditModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            GetRec();
        }

        public void OnPost()
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Submit")
            {
                UpdateRec();
            }
            else
            {
                OnGet();
            }
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/Employee_Details");
        }

        private void GetRec()
        {
            connString = _configuration.GetConnectionString("DBConnection");

            int EmpID = int.Parse(Request.Query["EmpID"]);

            Employee employee = new Employee();
            employeeDetails = employee.GetEmployeeRec(connString, EmpID);
        }

        private void UpdateRec()
        {
            connString = _configuration.GetConnectionString("DBConnection");

            int empID = Convert.ToInt32(Request.Form["txtEmpID"]);
            string strEmpName = Request.Form["txtEmpName"];
            string strMobileNo = Request.Form["txtMobileNo"];
            string strEmail = Request.Form["txtEmail"];

            if (strEmpName != string.Empty && strMobileNo != string.Empty && strEmail != string.Empty)
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand();

                try
                {
                    cmd.Connection = con;
                    cmd.CommandText = "prc_Employee_Edit_upd";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@EmpID", SqlDbType.SmallInt).Value = empID;
                    cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = strEmpName;
                    cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = strMobileNo;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = strEmail;

                    con.Open();

                    cmd.ExecuteNonQuery();

                    ViewData["JavaScriptFunction"] = "showSuccess();";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                    OnGet();
                }
            }
        }
    }
}
