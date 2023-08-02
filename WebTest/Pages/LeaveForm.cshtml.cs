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
    public class LeaveFormModel : PageModel
    {
        readonly IConfiguration _configuration;

        public List<Lookup> leaveList = new List<Lookup>();
        public List<Employee> managerList = new List<Employee>();
        public Employee employeeData = new Employee();
        public Lookup LookupData = new Lookup();
        public LeaveForm leaveFormData = new LeaveForm();

        [BindProperty]
        public LeaveForm FormData { get; set; }


        public string connString;

        public LeaveFormModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            GetRec();
            GetList();
        }

        public void OnPost()
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Submit")
            {
                InsertRec();
            }
            else
            {
                OnGet();
            }
        }

        void GetRec()
        {
            int empID = (int)HttpContext.Session.GetInt32("EmpID");

            connString = _configuration.GetConnectionString("DBConnection");

            //Employee employee = new Employee();
            //employeeData = employee.GetEmployeeRec(connString, empID);
            LeaveForm leaveForm = new LeaveForm();
            leaveFormData = leaveForm.GetEmployeeRec(connString, empID);
            FormData = leaveForm.GetEmployeeRec(connString, empID);
        }

        void GetList()
        {
            connString = _configuration.GetConnectionString("DBConnection");

            Employee employee = new Employee();
            Lookup lookup = new Lookup();

            leaveList = lookup.LookupLeaveType(connString);
            managerList = employee.LookupManager(connString);
        }

        void InsertRec()
        {
            connString = _configuration.GetConnectionString("DBConnection");

            int empID = Convert.ToInt32(HttpContext.Session.GetInt32("EmpID"));
            string strEmpName = Request.Form["FormData.EmpName"];
            string strStartDt = Request.Form["FormData.StartDt"];
            string strEndDt = Request.Form["FormData.EndDt"];
            int selectLeave = Convert.ToInt32(Request.Form["SelectedType"]);
            string strJustification = Request.Form["FormData.Justification"];
            int selectName = Convert.ToInt32(Request.Form["SelectedName"]);
       
            if (strStartDt != string.Empty && strEndDt != string.Empty && strJustification != string.Empty)
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand();

                try
                {
                    DateTime StartDt = Convert.ToDateTime(strStartDt);
                    DateTime EndDt = Convert.ToDateTime(strEndDt);
                    strStartDt = StartDt.ToString("yyyyMMdd");
                    strEndDt = EndDt.ToString("yyyyMMdd");

                    cmd.Connection = con;
                    cmd.CommandText = "prc_LeaveForm_ins";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@EmpID", SqlDbType.SmallInt).Value = empID;
                    cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = strEmpName;
                    cmd.Parameters.Add("@StartDt", SqlDbType.NVarChar).Value = strStartDt;
                    cmd.Parameters.Add("@EndDt", SqlDbType.NVarChar).Value = strEndDt;
                    cmd.Parameters.Add("@LeaveType", SqlDbType.SmallInt).Value = selectLeave;
                    cmd.Parameters.Add("@Justification", SqlDbType.NVarChar).Value = strJustification;
                    cmd.Parameters.Add("@ApproverEmpID", SqlDbType.SmallInt).Value = selectName;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.SmallInt).Value = empID;
                    cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = 0;

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
