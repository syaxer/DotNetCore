using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class Lookup
    {
        public string SystemParamText { get; set; }
        public short SystemParamValue { get; set; }
        public short LeaveTypeVal { get; set; }
        public string LeaveTypeName{ get; set; }

        public List<Lookup> LookupApproval(string connection)
        {
            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;
            SqlCommand cmd = new SqlCommand();

            List<Lookup> lookupList = new List<Lookup>();

            try
            {
                cmd.Connection = con;
                cmd.CommandText = "prc_LookupSystemParam_sel#Approval";
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
             
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Lookup lookupParamater = new Lookup();

                        lookupParamater.SystemParamValue = Convert.ToInt16(row["Value"]);
                        lookupParamater.SystemParamText = row["Text"].ToString();

                        lookupList.Add(lookupParamater);
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
            return lookupList;

        }

        public List<Lookup> LookupLeaveType(string connection)
        {
            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adp;
            SqlCommand cmd = new SqlCommand();

            List<Lookup> leaveList = new List<Lookup>();

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
                    foreach (DataRow row in dt.Rows)
                    {
                        Lookup LookupParameter = new Lookup();

                        LookupParameter.LeaveTypeVal = Convert.ToInt16(row["Value"]);
                        LookupParameter.LeaveTypeName = row["Text"].ToString();

                        leaveList.Add(LookupParameter);
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
    }   
}
