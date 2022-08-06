using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL
{
    public class DataBaseContext
    {
        public string? Error { get; set; }
        public string? ErrorCode { get; set; }

        public SqlConnection cn = new();

        public SqlCommand? CustomCommand;
        public SqlDataReader? CustomReader;



        public bool DbConnection()
        {
            if (cn.State == ConnectionState.Open)
            {
                return true;
            }

            cn.ConnectionString = "Server=LYCAN\\SQLEXPRESS;Database=GpQuizDB;uid=sa;password=1234;Trusted_Connection=True;MultipleActiveResultSets=true";
            try
            {
                cn.Open();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
            return false;
        }

        public SqlCommand CustomCommandBuilder(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            return cmd;
        }

        public bool ExecuteNonQuery(SqlCommand cmd)
        {
            if (!DbConnection())
            {
                return false;  
            }
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        
        }

    }
}
