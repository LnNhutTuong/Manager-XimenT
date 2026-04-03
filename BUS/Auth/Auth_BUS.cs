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
        public static NhanVien_DTO DangNhap(string tenDangNhap, string matKhau, out string mess)
        {
            mess = "";

            if (string.IsNullOrEmpty(tenDangNhap) )
            {
                mess = "Vui lòng nhập đủ thông tin!";
                return null;
            }

            DataTable tt = Auth_DAO.LayThongTin(tenDangNhap);

            if(tt == null)
            {
                mess = "Không tồn tại nhân viên này!";
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

                        NhanVien_DTO nv = new NhanVien_DTO();
                        DataRow row = tt.Rows[0];

                        nv.MaNV = row["MaNV"].ToString();
                        nv.TenNV = row["TenNV"].ToString();
                        nv.MaCV = row["MaCV"].ToString();
                        nv.HinhAnh = row["HinhAnh"].ToString();

                        return nv;
                    }
                    else
                    {

                        mess = "Mật khẩu không chính xác!" +
                                "pass hash:" + passwordHash + " " +
                                "pass bth: " + matKhau;
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
               

    }
}
