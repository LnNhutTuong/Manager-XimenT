using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.QuanLySanPham
{
    public class DanhMuc_BUS
    {
        public static DataTable DanhSachDanhMuc()
        {
            return DanhMuc_DAO.DanhSachDanhMuc();
        }

        public static bool KiemTraDM(string maDM)
        {
            List<string> dsMaDM = DanhMuc_DAO.DanhSachMaDM();
            return dsMaDM.Contains(maDM.ToUpper());
        }

        public static bool ThemDanhMuc(DanhMuc_DTO dm, out string message)
        {
            message = "";

            if (dm.MaDM.Length != 5)
            {
                message = "Mã danh mục phải bằng 5";
                return false;
            }

            if (string.IsNullOrEmpty(dm.MaDM))
            {
                message = "Mã danh mục không được bỏ trống";
                return false;
            }

            if (KiemTraDM(dm.MaDM))
            {
                message = "Mã này đã tồn tại";
                return false;
            }
            return DanhMuc_DAO.ThemDanhMuc(dm);
        }

        public static DataTable TimDanhMucTheoMa(string maDM, out string message)
        {
            message = "";

            //validate ben day di thang lam bieng :D
            if (!KiemTraDM(maDM))
            {
                message = "Không tồn tại mã này!";
                return null;
            }
            return DanhMuc_DAO.TimDanhMucTheoMa(maDM);
        }

        public static bool SuaDanhMuc(DanhMuc_DTO dm, string maDMcu, out string message)
        {
            message = "";

            if (dm.MaDM.Length != 5)
            {
                message = "Mã danh mục phải bằng 5";
                return false;
            } 

            if (string.IsNullOrEmpty(dm.MaDM))
            {
                message = "Mã danh mục không được bỏ trống";
                return false;
            }

            if (string.IsNullOrEmpty(dm.TenDM))
            {
                message = "Tên danh mục không được bỏ trống";
                return false;
            }
            return DanhMuc_DAO.SuaDanhMuc(dm, maDMcu);
        }

        public static bool XoaDanhMuc(DanhMuc_DTO dm)
        {
            return DanhMuc_DAO.XoaDanhMuc(dm);
        }
    }
}

