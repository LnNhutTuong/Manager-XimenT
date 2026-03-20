using DAO;
using DAO.QuanLySanPham;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.QuanLySanPham
{
    public class SanPham_BUS
    {
        public static DataTable DanhSachSanPham()
        {
            return SanPham_DAO.DanhSachSanPham();
        }

        public static bool KiemTraDM(string maSP)
        {
            List<string> dsMaSP = SanPham_DAO.DanhSachMaSP();
            return dsMaSP.Contains(maSP.ToUpper());
        }


        public static DataTable SanPhamTheoMa(string maSP, out string message)
        {
            message = "";

            if (!KiemTraDM(maSP))
            {
                message = "Không tồn tại mã này!";
                return null;
            }
            return SanPham_DAO.SanPhamTheoMa(maSP);
        }
    }
}
