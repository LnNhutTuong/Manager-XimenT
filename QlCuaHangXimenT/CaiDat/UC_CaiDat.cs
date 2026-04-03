using BUS.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.CaiDat
{
    public partial class UC_CaiDat : UserControl
    {
        string tenDangNhap;
        public UC_CaiDat(string tenDangNhap)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;

            //MessageBox.Show(tenDangNhap);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string mkCu = txtMatKhauCu.Text;
            string mkMoi = txtMatKhauMoi.Text;
            string nhapLai = txtNhapLai.Text;

            string mess;

            if(mkMoi == nhapLai)
            {
                bool kq = Auth_BUS.DoiMatKhau(tenDangNhap, mkCu, mkMoi, out mess);

                if (kq)
                {
                    MessageBox.Show(mess);
                    txtMatKhauCu.Clear();
                    txtMatKhauMoi.Clear();
                    txtNhapLai.Clear();
                }
                else
                {
                    MessageBox.Show(mess);
                }
            }
            else
            {
                MessageBox.Show("Nhập lại mật khẩu không đúng");
            }
        }

        private void txtMatKhauCu_IconRightClick(object sender, EventArgs e)
        {
            if (txtMatKhauCu.UseSystemPasswordChar)
            {
                // Hiện mật khẩu
                txtMatKhauCu.UseSystemPasswordChar = false;
                txtMatKhauCu.PasswordChar = '\0';
                txtMatKhauCu.IconRight = Properties.Resources.view;
            }
            else
            {
                // Ẩn mật khẩu
                txtMatKhauCu.UseSystemPasswordChar = true;
                txtMatKhauCu.PasswordChar = '*';
                txtMatKhauCu.IconRight = Properties.Resources.hide;
            }
        }

        private void txtMatKhauMoi_IconRightClick(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.UseSystemPasswordChar)
            {
                // Hiện mật khẩu
                txtMatKhauMoi.UseSystemPasswordChar = false;
                txtMatKhauMoi.PasswordChar = '\0';
                txtMatKhauMoi.IconRight = Properties.Resources.view;
            }
            else
            {
                // Ẩn mật khẩu
                txtMatKhauMoi.UseSystemPasswordChar = true;
                txtMatKhauMoi.PasswordChar = '*';
                txtMatKhauMoi.IconRight = Properties.Resources.hide;
            }
        }

        private void txtNhapLai_IconRightClick(object sender, EventArgs e)
        {
            if (txtNhapLai.UseSystemPasswordChar)
            {
                // Hiện mật khẩu
                txtNhapLai.UseSystemPasswordChar = false;
                txtNhapLai.PasswordChar = '\0';
                txtNhapLai.IconRight = Properties.Resources.view;
            }
            else
            {
                // Ẩn mật khẩu
                txtNhapLai.UseSystemPasswordChar = true;
                txtNhapLai.PasswordChar = '*';
                txtNhapLai.IconRight = Properties.Resources.hide;
            }
        }
    }
}
