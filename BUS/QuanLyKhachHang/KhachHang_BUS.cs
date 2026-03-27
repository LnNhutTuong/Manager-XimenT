using DAO;
using DAO.QuanLyKhachHang;
using DTO;
using DTO.QuanLyKhachHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS.QuanLyKhachHang
{
    public class KhachHang_BUS
    {
        public static DataTable DanhSachKhachHang()
        {
            return KhachHang_DAO.DanhSachKhachHang();
        }

        public static bool KiemTraMaKH(string MaKH)
        {
            List<string> dsMaKH = KhachHang_DAO.DanhSachMaKH();
            return dsMaKH.Contains(MaKH.ToUpper());
        }

        public static bool ThemKhachHang(KhachHang_DTO kh, out string message)
        {

            message = "";

            if (kh.MaKH.Length != 5)
            {
                message = "Mã khách hàng phải bằng 5";
                return false;
            }

            if (KiemTraMaKH(kh.MaKH))
            {
                message = "Mã này đã tồn tại";
                return false;
            }

            if (string.IsNullOrEmpty(kh.TenKH))
            {
                message = "Tên nhân viên không được bỏ trống";
                return false;
            }      

            if (string.IsNullOrEmpty(kh.DiaChi))
            {
                message = "Tên đăng nhập không được bỏ trống";
                return false;
            }

            if (!kh.SoDienThoai.StartsWith("0"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0");
                return false;
            }

            if (kh.SoDienThoai.Length != 10)
            {
                message = "Số điện thoại phải có đủ 10 số";
                return false;
            }

            return KhachHang_DAO.ThemKhanchHang(kh);
        }

        public static bool SuaKhachHang(KhachHang_DTO kh, string maKH, out string message)
        {

            message = "";

            if (string.IsNullOrEmpty(kh.TenKH))
            {
                message = "Tên nhân viên không được bỏ trống";
                return false;
            }

            if (string.IsNullOrEmpty(kh.DiaChi))
            {
                message = "Tên đăng nhập không được bỏ trống";
                return false;
            }

            if (!kh.SoDienThoai.StartsWith("0"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0");
                return false;
            }

            if (kh.SoDienThoai.Length != 10)
            {
                message = "Số điện thoại phải có đủ 10 số";
                return false;
            }

            return KhachHang_DAO.SuaKhachHang(kh, maKH);
        }

        public static bool XoaKhachHang(string maKh)
        {
            return KhachHang_DAO.XoaKhachHang(maKh);
        }

        public static DataTable TimKiemKh(string tuKhoa)
        {       
            return KhachHang_DAO.TimKiemKhachHang(tuKhoa);
        }
    }
}
