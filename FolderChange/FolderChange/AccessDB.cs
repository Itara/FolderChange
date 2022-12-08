using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FolderChange
{
    public class AccessDB
    {
        OleDbConnection conn = null;
        public AccessDB(string connectionString)
        {
            conn = new OleDbConnection();
            if (string.IsNullOrEmpty(connectionString) == false)
            {
                Connect(connectionString);
            }
        }

        public void Connect(string connectionString = "" )
        {
            if(conn == null)
            {
                conn = new OleDbConnection();
            }
            if (string.IsNullOrEmpty(connectionString) ==false)
            {
                conn.ConnectionString = connectionString;
            }
            conn.Open();
        }

        public void Close()
        {
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public void SetConnectionString(string connectionString)
        {
            conn.ConnectionString = connectionString;
        }
        public bool TableExists(string table)
        {
            var exists = conn.GetSchema("Tables", new string[4] { null, null, table, "TABLE" }).Rows.Count > 0;
            return exists;
        }

        public DataTable SelectSql(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                OleDbDataAdapter adp = new OleDbDataAdapter(query, conn);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 조회중 오류 발생");
                MessageBox.Show($"{ex.Message}");
            }
            return dt;
        }

        public int ExcuteQuery(string query)
        {
            OleDbCommand cmd = new OleDbCommand(query,conn);
            int iResult = 0;
            try
            {
                iResult = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return iResult;
        }

    }
}
