using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace DTO.Auth
{
    public class Auth_DAO
    {
        public static DataTable LayThongTin(string tenDangNhap)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select * from NhanVien where Ten_dang_nhap = @tenDangNhap");

            cmd.Parameters.Add("@tenDangNhap", SqlDbType.VarChar, 30).Value = tenDangNhap;

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }


    }
}
