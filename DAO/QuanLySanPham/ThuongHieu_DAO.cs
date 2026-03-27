using DTO;
using DTO.QuanLySanPham;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.QuanLySanPham
{
    public class ThuongHieu_DAO
    {
        public static DataTable DanhSachThuongHieu()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select * From ThuongHieu");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static List<string> DanhSachMaTH()
        {
            List<string> dsMaTH = new List<string>();

            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select MaTH From ThuongHieu");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            foreach (DataRow row in table.Rows)
            {
                dsMaTH.Add(row["MaTH"].ToString());
            }
            return dsMaTH;            
        }
        
        public static bool ThemThuongHieu(ThuongHieu_DTO th)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  Insert Into ThuongHieu
                                                Values (@MaTH, @TenTH)");

            cmd.Parameters.Add("@MaTH", SqlDbType.VarChar, 5).Value = th.MaTH;
            cmd.Parameters.Add("@TenTH", SqlDbType.NVarChar, 100).Value = th.TenTH;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static DataTable TimThuongHieuTheoMa(string maTH)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select * From ThuongHieu Where MaTH = @MaTH ");

            cmd.Parameters.Add("@MaTH", SqlDbType.VarChar, 5).Value = maTH;

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }


        public static bool SuaThuongHieu(ThuongHieu_DTO th, string maTH)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  Update ThuongHieu
                                                Set TenTH = @TenTH
                                                Where MaTH = @OldMaTH");

            cmd.Parameters.Add("@TenTH", SqlDbType.NVarChar, 100).Value = th.TenTH;
            cmd.Parameters.Add("@OldMaTH", SqlDbType.VarChar, 5).Value = maTH;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static bool XoaThuongHieu(ThuongHieu_DTO th)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Delete From ThuongHieu Where MaTH = @MaTH");

            cmd.Parameters.Add("@MaTH", SqlDbType.VarChar, 5).Value = th.MaTH;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }


        public static DataTable DanhSachSPTheoTH(string maTH)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select * From SanPham Where MaTH = @MaTH");
            cmd.Parameters.Add("@MaTH", SqlDbType.VarChar, 5).Value = maTH;

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static DataTable TimKiemThuongHieu(string tuKhoa)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select * From ThuongHieu Where MaTH Like  '%' + @tuKhoa + '%' or TenTH Like '%' + @tuKhoa + '%'");
            cmd.Parameters.Add("@tuKhoa", SqlDbType.NVarChar).Value = tuKhoa;

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }
    }
}
