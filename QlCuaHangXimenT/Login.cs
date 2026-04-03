using BUS.Auth;
using DTO;
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

        public NhanVien_DTO NhanVienHienTai { get; private set; }
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string mess;

            NhanVien_DTO user = Auth_BUS.DangNhap(tenDangNhap, matKhau, out mess);

            if (user != null)
            {
                this.NhanVienHienTai = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mess, "Thông báo lỗi!");
            }
        }

        private void btnDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("skibidi");
                btnDangNhap_Click(sender, e);
            }
        }
    }
}
