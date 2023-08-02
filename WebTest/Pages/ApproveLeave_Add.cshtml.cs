using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WebTest.Models;

namespace WebTest.Pages
{
    public class ApproveLeave_AddModel : PageModel
    {
        readonly IConfiguration _configuration;

        public List<Lookup> LookupList = new List<Lookup>();

        public Employee employeeData = new Employee();

        public string connString;

        public ApproveLeave_AddModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            GetRec();
            GetLookupApproval();
        }

        public void OnPost()
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Submit")
            {
                InsertApproveLeave();
            }
            else
            {
                OnGet();
            }
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/ApproveLeave_List");
        }

        void GetRec()
        {
            int empID = int.Parse(Request.Query["EmpID"]);
            var LeaveID = Request.Query["LeaveID"].ToString();

            Employee employee = new Employee();

            connString = _configuration.GetConnectionString("DBConnection");

            employeeData = employee.GetEmployeeLeaveRec(connString, empID, LeaveID);
        }

        void GetLookupApproval()
        {
            Lookup LookupParam = new Lookup();

            connString = _configuration.GetConnectionString("DBConnection");

            LookupList = LookupParam.LookupApproval(connString);
        }

        void InsertApproveLeave()
        {
            connString = _configuration.GetConnectionString("DBConnection");

            int LeaveID = int.Parse(Request.Query["LeaveID"]);
            int empID = int.Parse(Request.Query["EmpID"]);
            string strEmpName = Request.Form["txtEmpName"];
            int LeaveType = Convert.ToInt16(Request.Form["txtLeaveTypeValue"]);
            int selectApproveType = Convert.ToInt32(Request.Form["SelectedApproval"]);
            int ApproverID = Convert.ToInt32(HttpContext.Session.GetInt32("EmpID"));

            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = con;
                cmd.CommandText = "prc_LeaveForm_Approval_ins";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@LeaveID", SqlDbType.SmallInt).Value = LeaveID;
                cmd.Parameters.Add("@AppType", SqlDbType.SmallInt).Value = selectApproveType;
                cmd.Parameters.Add("@EmpID", SqlDbType.SmallInt).Value = empID;
                cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = strEmpName;
                cmd.Parameters.Add("@LeaveType", SqlDbType.SmallInt).Value = LeaveType;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.SmallInt).Value = ApproverID;

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
