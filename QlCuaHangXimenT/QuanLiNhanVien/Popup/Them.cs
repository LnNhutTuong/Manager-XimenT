using System;
using DTO;
using BUS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.QuanLiNhanVien.Popup
{
    public partial class Them : Form
    {
        public void DanhSachChucVu()
        {
            cboChucVu.DataSource = ChucVu_BUS.DanhSachChucVu();
            cboChucVu.DisplayMember = "TenCV";
            cboChucVu.ValueMember = "MaCV";

        }

        public Them()
        {
            InitializeComponent();
            DanhSachChucVu();
        }

        
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.MaNV = txtMaNhanVien.Text.ToUpper();
            nv.TenNV = txtTenNhanVien.Text;
            nv.MaCV = cboChucVu.SelectedValue.ToString();
            nv.Ten_dang_nhap = txtTenDangNhap.Text;
            nv.Mat_khau = txtMatKhau.Text;

            string message;

            bool kq = NhanVien_BUS.ThemNhanVien(nv, out message);

            if (kq)
            {
                MessageBox.Show("Thêm thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();       
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnTaiLai_Click_1(object sender, EventArgs e)
        {
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();           
        }
    }
}
