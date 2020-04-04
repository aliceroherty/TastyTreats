using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DataAccess
    {
        public DataTable Execute(string cmdText, List<ParmStruct> parms = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        public int ExecuteNonQuery(string cmdText, List<ParmStruct> parms = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public object ExecuteScaler(string cmdText, List<ParmStruct> parms = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);
            object retVal;

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                retVal = cmd.ExecuteScalar();
            }

            return retVal;
        }

        private SqlCommand CreateCommand(string cmdText, CommandType cmdType, List<ParmStruct> parms)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TastyTreats"].ConnectionString);
            //SqlConnection conn = new SqlConnection(
            //    Properties.Settings.Default.cnnString);

            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = cmdType;

            if (parms != null)
            {
                foreach (ParmStruct p in parms)
                {
                    cmd.Parameters.Add(p.Name, p.DataType, p.Size).Value = p.Value;
                }
            }

            return cmd;
        }
    }


}