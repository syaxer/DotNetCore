using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class Employee
    {
        public int empId { get; set; }
        public string empName { get; set; }
        public string email { get; set; }
        public string MobileNo { get; set; }
        public string justification { get; set; }
        public string leaveType { get; set; }
        public string statusLeave { get; set; }
        public string ManagerName { get; set; }
        public string EmployeeType { get; set; }
        public string EmployeeTypeName { get; set; }
        public string LeaveTypeName { get; set; }
        public int LeaveTypeVal { get; set; }
        public string StartDt { get; set; }
        public string EndDt { get; set; }
        public string TotalDt { get; set; }
        public int NumCount { get; set; }
        public int LeaveID { get; set; }

        // get connection string without appsettings
        public List<Employee> GetRec()
        {
            //SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter adp;
            string connString = "Data Source=localhost;Initial Catalog=Employee;User ID=sa;Password=123456789asd;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection conn = new SqlConnection(connString);
        
            List<Employee> employeeList = new List<Employee>();

            try
            {
                conn.Open();

                string SQLQuery = "SELECT * FROM tblEmployee";

                adp = new SqlDataAdapter(SQLQuery, conn);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    for(int i=0; i<dt.Rows.Count; i++)
                    {
                        Employee employee = new Employee();

                        employee.empName = dt.Rows[i]["EmpName"].ToString();
                        employee.email = dt.Rows[i]["Email"].ToString();

                        employeeList.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return employeeList;
        }

        // get connection string with appsettings
        public List<Employee> GetEmployeeParameters(string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;

            List<Employee> employeetParameterList = new List<Employee>();                 

            try
            {
                con.Open();

                string sqlQuery = "select * from tblEmployee";

                adp = new SqlDataAdapter(sqlQuery, con);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        Employee employeeParameter = new Employee();

                        employeeParameter.empId = Convert.ToInt32(dt.Rows[i]["EmpID"]);
                        employeeParameter.empName = dt.Rows[i]["EmpName"].ToString();
                        employeeParameter.email = dt.Rows[i]["Email"].ToString();
                        employeeParameter.MobileNo = dt.Rows[i]["MobileNo"].ToString();

                        employeetParameterList.Add(employeeParameter);

                        i++;
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
            return employeetParameterList;

        }

        public Employee GetEmployeeRec(string conn, int empID)
        {
            SqlConnection con = new SqlConnection(conn);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;
            SqlCommand cmd;

            Employee employeeParameter = new Employee();

            try
            {
                con.Open();

                string sqlQuery = "select * from tblEmployee "
                                + "where EmpID = @empID";

                cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@empID",SqlDbType.SmallInt).Value = empID;

                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        employeeParameter.empId = Convert.ToInt32(row["EmpID"]);
                        employeeParameter.empName = row["EmpName"].ToString();
                        employeeParameter.email = row["Email"].ToString();
                        employeeParameter.MobileNo = row["MobileNo"].ToString();
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

        public List<Employee> LookupEmployeeData(string connection)
        {
            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;

            List<Employee> employeetParameterList = new List<Employee>();

            try
            {
                con.Open();

                string sqlQuery = "select * from tblEmployee";

                adp = new SqlDataAdapter(sqlQuery, con);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        Employee employeeParameter = new Employee();

                        employeeParameter.empId = Convert.ToInt32(dt.Rows[i]["EmpID"]);
                        employeeParameter.empName = dt.Rows[i]["EmpName"].ToString();

                        employeetParameterList.Add(employeeParameter);

                        i++;
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
            return employeetParameterList;

        }

        public Employee GetEmployeeLeaveRec(string conn, int empID, string LeaveID)
        {
            SqlConnection con = new SqlConnection(conn);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;
            SqlCommand cmd = new SqlCommand();

            Employee employeeParameter = new Employee();

            try
            {                       
                string sqlQuery = "SELECT A.EmpName, A.EmpID, " 
                                + "StartDtTime = CONVERT(nvarchar(10),A.StartDtTime, 105), EndDtTime = CONVERT(nvarchar(10),A.EndDtTime, 105), "
                                + "TotalDt = DATEDIFF(DAY, StartDtTime, EndDtTime), A.LeaveType, LeaveName = D.[Text], "
                                + "A.Justification, A.ApproverEmpID, ManagerName = C.EmpName, " 
                                + "[Status] = B.[Text] "
                                + "FROM tblLeave (NOLOCK) A "
                                + "INNER JOIN tblSystemParam (NOLOCK) B "
                                + "ON A.[Status] = B.[Value] "
                                + "AND B.SystemParamID = 3 "
                                + "INNER JOIN tblEmployee (NOLOCK) C "
                                + "ON A.ApproverEmpID = C.EmpID "
                                + "INNER JOIN tblSystemParam (NOLOCK) D "
                                + "ON A.LeaveType = D.[Value] "
                                + "AND D.SystemParamID = 4 "
                                + "WHERE A.EmpID = @EmpID "
                                + "AND A.[ID] = ISNULL(@LeaveID, A.ID)";

                cmd.CommandText = sqlQuery;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@EmpID", SqlDbType.SmallInt).Value = empID;          

                if (LeaveID == null)
                {
                    cmd.Parameters.Add("@LeaveID", SqlDbType.SmallInt).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@LeaveID", SqlDbType.SmallInt).Value = LeaveID;
                }

                con.Open();

                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        employeeParameter.empId = Convert.ToInt32(dt.Rows[i]["EmpID"]);
                        employeeParameter.empName = dt.Rows[i]["EmpName"].ToString();
                        employeeParameter.StartDt = dt.Rows[i]["StartDtTime"].ToString();
                        employeeParameter.EndDt = dt.Rows[i]["EndDtTime"].ToString();
                        employeeParameter.TotalDt = dt.Rows[i]["TotalDt"].ToString();
                        employeeParameter.LeaveTypeVal = Convert.ToInt16(dt.Rows[i]["LeaveType"]);
                        employeeParameter.LeaveTypeName = dt.Rows[i]["LeaveName"].ToString();
                        employeeParameter.justification = dt.Rows[i]["Justification"].ToString();
                        employeeParameter.ManagerName = dt.Rows[i]["ManagerName"].ToString();
                        employeeParameter.statusLeave = dt.Rows[i]["Status"].ToString();
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

        public List<Employee> LookupEmployeeType(string connection)
        {
            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;

            List<Employee> employeetParameterList = new List<Employee>();

            try
            {
                con.Open();

                string sqlQuery = "SELECT DISTINCT A.EmpType, B.[Text] FROM tblEmployee A "
                                + "INNER JOIN tblSystemParam B "
                                + "ON A.EmpType = B.[Value] "
                                + "AND B.SystemParamID = 2";

                adp = new SqlDataAdapter(sqlQuery, con);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        Employee employeeParameter = new Employee();

                        employeeParameter.EmployeeType =dt.Rows[i]["EmpType"].ToString();
                        employeeParameter.EmployeeTypeName = dt.Rows[i]["Text"].ToString();

                        employeetParameterList.Add(employeeParameter);

                        i++;
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
            return employeetParameterList;
        }

        public List<Employee> GetEmployeeType(string connectionString, int empType)
        {
            SqlConnection con = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;

            List<Employee> employeetParameterList = new List<Employee>();

            try
            {
                con.Open();

                string sqlQuery = "select * from tblEmployee "
                                + "where EmpType = '" + empType + "'";

                adp = new SqlDataAdapter(sqlQuery, con);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        Employee employeeParameter = new Employee();

                        employeeParameter.empId = Convert.ToInt32(dt.Rows[i]["EmpID"]);
                        employeeParameter.empName = dt.Rows[i]["EmpName"].ToString();
                        employeeParameter.email = dt.Rows[i]["Email"].ToString();

                        employeetParameterList.Add(employeeParameter);

                        i++;
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
            return employeetParameterList;
        }

        public List<Employee> LookupLeaveType(string connection)
        {
            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;
            SqlCommand cmd = new SqlCommand();

            List<Employee> leaveList = new List<Employee>();

            try
            {               
                cmd.Connection = con;
                cmd.CommandText = "prc_LookupSystemParam_sel#LeaveType";
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        Employee employeeParameter = new Employee();

                        employeeParameter.LeaveTypeVal = Convert.ToInt32(row["Value"]);
                        employeeParameter.LeaveTypeName = row["Text"].ToString();

                        leaveList.Add(employeeParameter);
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
            return leaveList;
        }

        public List<Employee> LookupManager(string connection)
        {
            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;
            SqlCommand cmd = new SqlCommand();

            List<Employee> managerList = new List<Employee>();

            try
            {
                cmd.Connection = con;
                cmd.CommandText = "prc_LookupEmployee_sel#Manager";
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Employee employeeParameter = new Employee();

                        employeeParameter.empId = Convert.ToInt32(row["EmpID"]);
                        employeeParameter.empName = row["EmpName"].ToString();

                        managerList.Add(employeeParameter);
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
            return managerList;
        }

        public List<Employee> GetEmployeeLeaveList(string connectionString, int ApproverID, string empID, string empName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;
            SqlCommand cmd = new SqlCommand();

            List<Employee> employeeParamList = new List<Employee>();

            try
            {
                cmd.Connection = con;
                cmd.CommandText = "prc_LeaveForm_Listing_sel";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ApproverEmpID", SqlDbType.SmallInt).Value = ApproverID;
                cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = empName;

                if (string.IsNullOrEmpty(empID) == true)
                {
                    cmd.Parameters.Add("@EmpID", SqlDbType.SmallInt).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EmpID", SqlDbType.SmallInt).Value = int.Parse(empID);
                }

                con.Open();

                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        Employee employeeParameter = new Employee();

                        employeeParameter.NumCount = i + 1;
                        employeeParameter.LeaveID = Convert.ToInt32(dt.Rows[i]["ID"]);
                        employeeParameter.empId = Convert.ToInt32(dt.Rows[i]["EmpID"]);
                        employeeParameter.empName = dt.Rows[i]["EmpName"].ToString();
                        employeeParameter.StartDt = dt.Rows[i]["StartDtTime"].ToString();
                        employeeParameter.EndDt = dt.Rows[i]["EndDtTime"].ToString();
                        employeeParameter.LeaveTypeName = dt.Rows[i]["LeaveName"].ToString();
                        employeeParameter.justification = dt.Rows[i]["Justification"].ToString();
                        employeeParameter.statusLeave = dt.Rows[i]["Status"].ToString();

                        employeeParamList.Add(employeeParameter);

                        i++;
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
            return employeeParamList;
        }
    }
}
;