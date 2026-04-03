using BUS.Auth;
using DTO;
using DTO.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT
{
    public partial class Login : Form
    {

        public NguoiDung_DTO NguoiDungHienTai { get; private set; }
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string mess;

            NguoiDung_DTO user = Auth_BUS.DangNhap(tenDangNhap, matKhau, out mess);

            if (user != null)
            {
                this.NguoiDungHienTai = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mess, "Thông báo lỗi!");
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string tenDangNhap = txtTenDangNhap.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();
                string mess;

                NguoiDung_DTO user = Auth_BUS.DangNhap(tenDangNhap, matKhau, out mess);

                if (user != null)
                {
                    this.NguoiDungHienTai = user;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(mess, "Thông báo lỗi!");
                }
            }
        }

        private void txtMatKhau_IconRightClick(object sender, EventArgs e)
        {
            if (txtMatKhau.UseSystemPasswordChar)
            {
                // Hiện mật khẩu
                txtMatKhau.UseSystemPasswordChar = false;
                txtMatKhau.PasswordChar = '\0';
                txtMatKhau.IconRight = Properties.Resources.view;
            }
            else
            {
                // Ẩn mật khẩu
                txtMatKhau.UseSystemPasswordChar = true;
                txtMatKhau.PasswordChar = '*';
                txtMatKhau.IconRight = Properties.Resources.hide;
            }
        }
    }
}
