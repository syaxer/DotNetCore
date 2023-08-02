using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class Login
    {
        public int empId { get; set; }

        public string username { get; set; }

        public int role { get; set; }

        public Login GetRec(string conn, string username, string password)
        {
            SqlConnection con = new SqlConnection(conn);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;
            SqlCommand cmd;

            Login loginParam = new Login();

            try
            {
                con.Open();

                string sqlQuery = "select * from tblUser "
                                + "where Username = @username "
                                + "and Password = @password";

                cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;

                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        loginParam.empId = Convert.ToInt32(row["EmpID"]);
                        loginParam.username = row["Username"].ToString();
                        loginParam.role = Convert.ToInt32(row["Role"]);
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
            return loginParam;
        }
    }
}
