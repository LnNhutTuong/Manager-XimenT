using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DanhMuc_DAO
    {

        public static DataTable DanhSachDanhMuc()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select * From DanhMuc");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            
            return table;
        }

        public static List<string> DanhSachMaDM()
        {
            List<string> dsMaDM = new List<string>();

            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select MaDM From DanhMuc");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            foreach (DataRow row in table.Rows)
            {
                dsMaDM.Add(row["MaDM"].ToString());
            }

            return dsMaDM;
        }

        public static bool ThemDanhMuc(DanhMuc_DTO dm)
        {
            DataProvider pd = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Insert Into DanhMuc
                                               Values( @MaDM, @TenDM)");

            cmd.Parameters.Add("@MaDM", SqlDbType.VarChar, 5).Value = dm.MaDM;
            cmd.Parameters.Add("@TenDM", SqlDbType.NVarChar, 100).Value = dm.TenDM;

            int kq = pd.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static DataTable TimDanhMucTheoMa (string maDM)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand("Select * From DanhMuc Where MaDM = @MaDM");

            cmd.Parameters.Add("@MaDM", SqlDbType.VarChar, 5).Value = maDM;

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static bool SuaDanhMuc(DanhMuc_DTO dm, string maDM)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  Update DanhMuc
                                                Set 
                                                    TenDM = @TenDM
                                                Where MaDM = @OldMaDM");
          
            cmd.Parameters.Add("@TenDM", SqlDbType.NVarChar, 100).Value = dm.TenDM;
            cmd.Parameters.Add("@OldMaDM", SqlDbType.VarChar, 5).Value = maDM;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static bool XoaDanhMuc(DanhMuc_DTO dm)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Delete From DanhMuc Where MaDM = @MaDM");

            cmd.Parameters.Add("@MaDM", SqlDbType.VarChar, 5).Value = dm.MaDM;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static DataTable DanhSachSPTheoMaDM(string maDM)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select * From SanPham Where MaDM = @MaDM");
            cmd.Parameters.Add("@MaDM", SqlDbType.VarChar, 5).Value = maDM;

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

    }
}
