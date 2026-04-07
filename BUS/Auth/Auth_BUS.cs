using DTO;
using DTO.Auth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace BUS.Auth
{
    public class Auth_BUS
    {
        public static NguoiDung_DTO DangNhap(string tenDangNhap, string matKhau, out string mess)
        {
            mess = "";

            if (string.IsNullOrEmpty(tenDangNhap) )
            {
                mess = "Vui lòng nhập đủ thông tin!";
                return null;
            }

            DataTable tt = Auth_DAO.LayThongTin(tenDangNhap);

            if(tt == null || tt.Rows.Count == 0)
            {
                mess = "Tên đăng nhập không đúng!";
                return null;
            }
            else
            {
                string passwordHash = tt.Rows[0]["Mat_khau"].ToString();

                try
                {
                    if (BC.Verify(matKhau, passwordHash))
                    {
                        mess = "Đăng nhập thành công";

                        NguoiDung_DTO nd = new NguoiDung_DTO();
                        DataRow row = tt.Rows[0];

                        nd.MaNV = row["MaNV"].ToString();
                        nd.TenNV = row["TenNV"].ToString();
                        nd.MaCV = row["MaCV"].ToString();
                        nd.TenCV = row["TenCV"].ToString();
                        nd.HinhAnh = row["HinhAnh"].ToString();
                        nd.Ten_dang_nhap = row["Ten_dang_nhap"].ToString();

                        return nd;
                    }
                    else
                    {

                        mess = "Mật khẩu không chính xác!";
                        return null;
                    }
                }

                catch
                {
                    mess = "Định dạng mật khẩu trong DB không hợp lệ!";
                    return null;
                }
            }
        }

        public static bool DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi, out string mess)
        {
            mess = "";

            if(string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(matKhauCu))
            {
                mess = "Vui lòng nhập đủ mật khẩu!";
                return false;
            }
            DataTable tt = Auth_DAO.LayThongTin(tenDangNhap);

            if (tt == null)
            {
                mess = "Không tồn tại nhân viên này!";
                return false;
            }
            else
            {
                string passwordHash = tt.Rows[0]["Mat_khau"].ToString();

                try
                {
                    if (BC.Verify(matKhauCu, passwordHash))
                    {

                        bool kq = Auth_DAO.DoiMatKhau(tenDangNhap, matKhauMoi);

                        if (kq)
                        {
                            mess = "Đổi mật khẩu thành công";
                            return true;
                        }
                        else
                        {
                            mess = "Lỗi hệ thống khi cập nhật mật khẩu!";
                            return true;
                        }
                    }
                    else
                    {
                        mess = "Mật khẩu không chính xác !";
                    }
                }

                catch (Exception ex) {
                {
                    mess = ex.ToString();
                    return false;
                }
            }
                return false;

            }
        }

        public static bool SaoLuu(string sDuongDan)
        {
            return Auth_DAO.SaoLuuDuLieu(sDuongDan);
        }
        public static bool PhucHoi(string sDuongDan)
        {
            return Auth_DAO.PhucHoiDuLieu(sDuongDan);
        }
    }
}
