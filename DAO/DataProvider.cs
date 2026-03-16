using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    internal class DataProvider
    {
        SqlConnection connection;

        public string ConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Server"] = ".\\SQLEXPRESS";
            builder["Database"] = "QlCuaHangXimenT";
            builder["Integrated Security"] = true;

            return builder.ConnectionString;
        }

        public bool OpenConnection()
        {
            try
            {
                if (connection == null)
                    connection = new SqlConnection(ConnectionString());

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable TruyVanLayDuLieu(SqlCommand cmd)
        {
            OpenConnection();

            cmd.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public int TruyVanKhongLayDuLieu(SqlCommand cmd)
        {
            OpenConnection();

            cmd.Connection = connection;

            return cmd.ExecuteNonQuery();
        }
    }
}
