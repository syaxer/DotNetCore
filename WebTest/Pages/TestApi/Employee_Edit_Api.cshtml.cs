using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebTest.Models;

namespace WebTest.Pages.TestApi
{
    public class Employee_Edit_ApiModel : PageModel
    {
        readonly IConfiguration _configuration;
        public string connString;

        public EmployeeDetail EmployeeData { get; set; }
        //public EmployeeDetail EmployeeData = new EmployeeDetail();

        public Employee_Edit_ApiModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            //GetRec();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/TestApi/Employee_Listing_Api");
        }

        void GetRec()
        {
            int empID = Convert.ToInt32(Request.Query["EmpID"]);
            connString = _configuration.GetConnectionString("DBConnection");

            SqlConnection con = new SqlConnection(connString);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;
            SqlCommand cmd;

            EmployeeData = new EmployeeDetail();

            try
            {
                con.Open();

                string sqlQuery = "select * from tblEmployee "
                                + "where EmpID = @empID";

                cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@empID", SqlDbType.SmallInt).Value = empID;

                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        EmployeeData.EmpId = Convert.ToInt32(row["EmpID"]);
                        EmployeeData.EmpName = row["EmpName"].ToString();
                        EmployeeData.Email = row["Email"].ToString();
                        EmployeeData.MobileNo = row["MobileNo"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
