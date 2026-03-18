using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChucVu_DAO
    {
        public static DataTable DanhSachChucVu()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand("SELECT * FROM ChucVu");

            DataTable table = dp.TruyVanLayDuLieu(cmd);
            
           
            return table;
        }
    }
}
