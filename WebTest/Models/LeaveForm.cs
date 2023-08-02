using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class LeaveForm
    {
        public int EmpId { get; set; }  
        
        [Display(Name = "Employee Name:")]
        public string EmpName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please insert Justification!")]
        [Display(Name = "Justification:")]
        public string Justification { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please insert Start Date!")]
        [Display(Name = "Start Date:")]
        public string StartDt { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please insert End Date!")]
        [Display(Name = "End Date:")]
        public string EndDt { get; set; }

        public string TotalDt { get; set; }

        public LeaveForm GetEmployeeRec(string conn, int empID)
        {
            SqlConnection con = new SqlConnection(conn);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;
            SqlCommand cmd;

            LeaveForm employeeParameter = new LeaveForm();

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
                        employeeParameter.EmpId = Convert.ToInt32(row["EmpID"]);
                        employeeParameter.EmpName = row["EmpName"].ToString();
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
            return employeeParameter;
        }
    }
}
