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

        public static bool ThemSanPham(SanPham_DTO sp, string giaBanRaw, string giaNhapRaw, string soLuongTonRaw, out string message)
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

            #region Giá nhập sản phẩm
            if (string.IsNullOrWhiteSpace(giaNhapRaw)) 
            { 
                message = "Giá không được để trống"; 
                return false; 
            }

            if (!int.TryParse(giaNhapRaw, out int giaNhap)) 
            { 
                message = "Giá phải là số nguyên"; 
                return false; 
            }

            if (giaNhap <= 0) 
            { 
                message = "Giá phải lớn hơn 0"; 
                return false; 
            }
            sp.GiaNhap = giaNhap;
            #endregion

            #region Giá bán sản phẩm
            if (string.IsNullOrWhiteSpace(giaBanRaw))
            {
                message = "Giá không được để trống";
                return false;
            }

            if (!int.TryParse(giaBanRaw, out int giaBan))
            {
                message = "Giá phải là số nguyên";
                return false;
            }

            if (giaBan <= 0)
            {
                message = "Giá phải lớn hơn 0";
                return false;
            }
            sp.GiaBan = giaBan;
            #endregion

            #region Sò lương tốns
            if (string.IsNullOrWhiteSpace(soLuongTonRaw)) 
            { 
                message = "Số lượng không được để trống"; 
                return false; 
            }

            if (!int.TryParse(soLuongTonRaw, out int soLuong)) 
            { message = "Số lượng tồn phải là số"; 
                return false; 
            }

            if (soLuong < 0) 
            { message = "Số lượng tồn không được âm"; 
                return false; 
            }

            sp.SoLuongTon = soLuong;
            #endregion


            return SanPham_DAO.ThemSanPham(sp);
        }

        public static bool SuaSanPham(SanPham_DTO sp,string maSP, string giaBanRaw, string giaNhapRaw, string soLuongTonRaw, out string message)
        {
            message = "";

            if (string.IsNullOrWhiteSpace(sp.TenSP))
            {
                message = "Tên không được để trống";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sp.Size))
            {
                message = "Size không được để trống";
                return false;
            }
            #region Giá nhập sản phẩm
            if (string.IsNullOrWhiteSpace(giaNhapRaw))
            {
                message = "Giá không được để trống";
                return false;
            }

            if (!int.TryParse(giaNhapRaw, out int giaNhap))
            {
                message = "Giá phải là số nguyên";
                return false;
            }

            if (giaNhap <= 0)
            {
                message = "Giá phải lớn hơn 0";
                return false;
            }
            sp.GiaNhap = giaNhap;
            #endregion

            #region Giá bán sản phẩm
            if (string.IsNullOrWhiteSpace(giaBanRaw))
            {
                message = "Giá không được để trống";
                return false;
            }

            if (!int.TryParse(giaBanRaw, out int giaBan))
            {
                message = "Giá phải là số nguyên";
                return false;
            }

            if (giaBan <= 0)
            {
                message = "Giá phải lớn hơn 0";
                return false;
            }
            sp.GiaBan = giaBan;
            #endregion

            #region Sò lương tốns
            if (string.IsNullOrWhiteSpace(soLuongTonRaw))
            {
                message = "Số lượng không được để trống";
                return false;
            }

            if (!int.TryParse(soLuongTonRaw, out int soLuong))
            {
                message = "Số lượng tồn phải là số";
                return false;
            }

            if (soLuong < 0)
            {
                message = "Số lượng tồn không được âm";
                return false;
            }

            sp.SoLuongTon = soLuong;
            #endregion

            return SanPham_DAO.SuaSanPham(sp, maSP);
        }

        public static bool XoaSanPham(string maSP)
        {
            return SanPham_DAO.XoaSanPham(maSP);
        }

        public static DataTable LocSanPham(string maDM, string maTH, DateTime? tuNgay, DateTime? denNgay, string tuKhoa)
        {
            return SanPham_DAO.LocSanPham(maDM, maTH, tuNgay, denNgay, tuKhoa);
        }

        public static bool KiemTraSPCoDinhCTDH(string maSP)
        {
            return SanPham_DAO.KiemTraSPCoDinhCTDH(maSP);
        }

    }
}
