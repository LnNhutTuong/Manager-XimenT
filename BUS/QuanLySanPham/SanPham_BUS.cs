using DAO;
using DAO.QuanLySanPham;
using DTO;
using DTO.QuanLySanPham;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS.QuanLySanPham
{
    public class SanPham_BUS
    {
        public static DataTable DanhSachSanPham()
        {
            return SanPham_DAO.DanhSachSanPham();
        }

        public static bool KiemTraSP(string maSP)
        {
            List<string> dsMaSP = SanPham_DAO.DanhSachMaSP();
            return dsMaSP.Contains(maSP.ToUpper());
        }


        public static DataTable SanPhamTheoMa(string maSP, out string message)
        {
            message = "";

            if (!KiemTraSP(maSP))
            {
                message = "Không tồn tại mã này!";
                return null;
            }
            return SanPham_DAO.SanPhamTheoMa(maSP);
        }

        public static bool ThemSanPham(SanPham_DTO sp, out string message)
        {
            message = "";

            if (sp.MaSP.Length != 5)
            {
                message = "Mã thương hiệu phải bằng 5";
                return false;
            }

            if (string.IsNullOrEmpty(sp.MaSP))
            {
                message = "Mã thương hiệu không được bỏ trống";
                return false;
            }

            if (KiemTraSP(sp.MaSP))
            {
                message = "Mã này đã tồn tại";
                return false;
            }

            if (string.IsNullOrEmpty(sp.TenSP))
            {
                message = "Tên không được để trống";
                return false;
            }

            if (string.IsNullOrEmpty(sp.Size))
            {
                message = "Size không được để trống";
                return false;
            }

            if (string.IsNullOrEmpty(sp.SoLuongTon.ToString()))
            {
                message = "Số lượng tồn không được để trống";
                return false;
            }

            if (string.IsNullOrEmpty(sp.Gia.ToString()))
            {
                message = "Giá không được để trống";
                return false;
            }

            return SanPham_DAO.ThemSanPham(sp);
        }

    }
}
