using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace RpCater.DAL
{
    public class SqlHelper
    {
        public static readonly string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        public static int ExecuteNonQuery(SqlConnection conn, SqlTransaction sqlTran, string sql, params SqlParameter[] ps)
        {
      
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (conn.State==ConnectionState.Closed)
                {
                      conn.Open();
                }
              
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                cmd.Transaction = sqlTran;//事物
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static object ExecuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable ExecuteTable(string sql, params SqlParameter[] ps)
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
            }
            return table;
        }

        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] ps)
        {
            SqlConnection conn = new SqlConnection(conStr);
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                try
                {
                    conn.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    conn.Close();
                    conn.Dispose();
                    throw ex;
                }
            }
        }
    }
}
