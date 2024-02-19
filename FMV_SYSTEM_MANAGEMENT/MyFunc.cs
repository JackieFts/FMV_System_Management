using DevExpress.XtraCharts.Native;
using FMV_SYSTEM_MANAGEMENT.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENT
{
    public class MyFunc
    {
        private static SqlConnection conn = new SqlConnection();
        private static string connString = "Data Source=123.24.143.156;Initial Catalog=MyStockDB;User ID=sa;Password=Tai@1234;TrustServerCertificate=True";

        public static bool OpenConnect()
        {
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
                return true;
            }
            catch { return false; }
        }
        public static void CloseConnect()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public static DataTable getDatatoDT(string qr)
        {
            OpenConnect();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = new SqlCommand(qr, conn);
            sqlDataAdapter.Fill(dt);
            CloseConnect();
            return dt;
        }

        public static void truncateTable(string tableName)
        {
            conn.ConnectionString = connString;
            try
            {
                conn.Open();

                string truncateTableQuery = "TRUNCATE TABLE " + tableName;
                using (SqlCommand command = new SqlCommand(truncateTableQuery, conn))
                {
                        command.ExecuteNonQuery();
                        Program.log.LogMsg(Logger.LogLevel.INFO, "Table truncated successfully.");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Program.log.LogMsg(Logger.LogLevel.FATAL, "truncateTable error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "truncateTable detail : {0}", ex.StackTrace);
            }
        }
    }
}
