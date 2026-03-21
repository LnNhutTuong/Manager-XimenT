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

namespace BUS.QuanLySanPham
{
    public class ThuongHieu_BUS
    {
        public static DataTable DanhSachThuongHieu()
        {
            return ThuongHieu_DAO.DanhSachThuongHieu();
        }

        public static bool KiemTraTH(string maTH)
        {
            List<string> dsMaTH = ThuongHieu_DAO.DanhSachMaTH();
            return dsMaTH.Contains(maTH.ToUpper());
        }

        public static bool ThemThuongHieu(ThuongHieu_DTO th, out string message)
        {
            message = "";

            if (th.MaTH.Length != 5)
            {
                message = "Mã thương hiệu phải bằng 5";
                return false;
            }

            if (string.IsNullOrEmpty(th.MaTH))
            {
                message = "Mã thương hiệu không được bỏ trống";
                return false;
            }

            if (KiemTraTH(th.MaTH))
            {
                message = "Mã này đã tồn tại";
                return false;
            }
            return ThuongHieu_DAO.ThemThuongHieu(th);
        }

        public static DataTable TimThuongHieuTheoMa(string maTh, out string message)
        {
            message = "";

            //validate ben day di thang lam bieng :D
            if (!KiemTraTH(maTh))
            {
                message = "Không tồn tại mã này!";
                return null;
            }
            return ThuongHieu_DAO.TimThuongHieuTheoMa(maTh);
        }

        public static bool SuaThuongHieu(ThuongHieu_DTO th, string maTHCu, out string message)
        {
            message = "";

            if (string.IsNullOrEmpty(th.TenTH))
            {
                message = "Tên thương hiệu không được bỏ trống";
                return false;
            }
            return ThuongHieu_DAO.SuaThuongHieu(th, maTHCu);
        }

        public static bool XoaThuongHieu(ThuongHieu_DTO th)
        {
            return ThuongHieu_DAO.XoaThuongHieu(th);
        }

        public static DataTable DanhSachSPTheoTH(string maTh, out string message)
        {
            message = "";

            if (!KiemTraTH(maTh))
            {
                message = "Không tồn tại mã này!";
                return null;
            }
            return ThuongHieu_DAO.DanhSachSPTheoTH(maTh);
        }
    }
}
