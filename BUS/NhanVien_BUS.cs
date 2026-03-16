using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVien_BUS
    {
        public static DataTable DanhSachNhanVien()
        {
            return NhanVien_DAO.DanhSachNhanVien();
        }

        public static bool KiemTraMaNV(string maNV)
        {
            List<string> dsMaNV = NhanVien_DAO.DanhSachMaNV();
            return dsMaNV.Contains(maNV.ToUpper());
        }

        public static bool ThemNhanVien(NhanVien_DTO nv, out string message)
        {
            message = "";

            if(nv.MaNV.Length != 5)
            {
                message = "Mã nhân viên phải bằng 5";
                return false;
            }

            if (string.IsNullOrEmpty(nv.TenNV))
            {
                message = "Tên nhân viên không được bỏ trống";
                return false;
            }

            if (KiemTraMaNV(nv.MaNV))
            {
                message = "Mã này đã tồn tại";
                return false;
            }

            if (string.IsNullOrEmpty(nv.Ten_dang_nhap))
            {
                message = "Tên đăng nhập không được bỏ trống";
                return false;
            }

            return NhanVien_DAO.ThemNhanVien(nv);
        }

        public static bool SuaNhanVien(NhanVien_DTO nv , string maNVcu, out string message)
        {
            message = "";

            if (nv.MaNV.Length != 5)
            {
                message = "Mã nhân viên phải bằng 5";
                return false;
            }

            if (string.IsNullOrEmpty(nv.TenNV))
            {
                message = "Tên nhân viên không được bỏ trống";
                return false;
            }

            if (string.IsNullOrEmpty(nv.Ten_dang_nhap))
            {
                message = "Tên đăng nhập không được bỏ trống";
                return false;
            }

            return NhanVien_DAO.SuaNhanVien(nv, maNVcu);
        }

    public static bool XoaNhanVien (NhanVien_DTO nv)
        {
            return NhanVien_DAO.XoaNhanVien(nv);
        }
    }
}
