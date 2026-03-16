using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.NhanVien
{
    public partial class UC_NhanVien : UserControl
    {
        private void OnOff(bool value)
        {
            txtMaNhanVien.Enabled = value;
            txtTenNhanVien.Enabled = value;
            txtTenDangNhap.Enabled = value;
            txtMatKhau.Enabled = value;
            cboChucVu.Enabled = value;

            //txtTenDangNhap.Enabled = value;

            btnThem.Enabled = !value;
            btnSua.Enabled = !value;
            btnXoa.Enabled = !value;

            btnHuy.Enabled = value;
            btnLuu.Enabled = value;
        }

        private void LayDuLieu()
        {
            dgvNhanVien.DataSource = NhanVien_BUS.DanhSachNhanVien();

            txtMaNhanVien.DataBindings.Clear();
            txtTenNhanVien.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Clear();
            txtMatKhau.DataBindings.Clear();
            cboChucVu.DataBindings.Clear();



            txtMaNhanVien.DataBindings.Add("Text", dgvNhanVien.DataSource, "MaNV");
            txtTenNhanVien.DataBindings.Add("Text", dgvNhanVien.DataSource, "TenNV");
            txtTenDangNhap.DataBindings.Add("Text", dgvNhanVien.DataSource, "Ten_dang_nhap");
            txtMatKhau.DataBindings.Add("Text", dgvNhanVien.DataSource, "Mat_khau");

            cboChucVu.DataSource = ChucVu_BUS.DanhSachChucVu();
            cboChucVu.DisplayMember = "TenCV";
            cboChucVu.ValueMember = "MaCV";


            cboChucVu.DataBindings.Add("SelectedValue", dgvNhanVien.DataSource, "MaCV");
        }


        public UC_NhanVien()
        {
            InitializeComponent();
            LayDuLieu();
            OnOff(false);
        }

        string maNV;
        private void btnThem_Click(object sender, EventArgs e)
        {
            maNV = "";

            OnOff(true);
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();

            txtMaNhanVien.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            maNV = txtMaNhanVien.Text;
            OnOff(true);

            //txtMaNhanVien.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO();

            nv.MaNV = txtMaNhanVien.Text;

            DialogResult ans;
            ans = MessageBox.Show("Bạn có muốn xóa NV: " + txtMaNhanVien.Text + " không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if( ans == DialogResult.Yes)
            {
                bool kq = NhanVien_BUS.XoaNhanVien(nv);

                if (kq)
                {
                    MessageBox.Show("Xóa thành công");
                    LayDuLieu();              
                        }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LayDuLieu();
            OnOff(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO();

            try
            {
                #region Thêm mới
                if (maNV == "")
                {
                    nv.MaNV = txtMaNhanVien.Text;
                    nv.TenNV = txtTenNhanVien.Text;
                    nv.Ten_dang_nhap = txtTenDangNhap.Text;
                    nv.Mat_khau = txtMatKhau.Text;
                    nv.MaCV = cboChucVu.SelectedValue.ToString();

                    string message;

                    bool kq = NhanVien_BUS.ThemNhanVien(nv, out message);

                    if (kq)
                    {
                        MessageBox.Show("Thêm thành công");
                        LayDuLieu();
                        OnOff(false);
                    }
                    else
                    {
                        MessageBox.Show(message);
                    }
                }
                #endregion
                #region Sửa thằng đã có 
                else
                {
                    nv.MaNV = txtMaNhanVien.Text.ToUpper();
                    nv.TenNV = txtTenNhanVien.Text;
                    nv.Ten_dang_nhap = txtTenDangNhap.Text;
                    nv.Mat_khau = txtMatKhau.Text;
                    nv.MaCV = cboChucVu.SelectedValue.ToString();

                    string message;

                    bool kq = NhanVien_BUS.SuaNhanVien(nv ,maNV , out message);

                    if (kq)
                    {
                        MessageBox.Show("Sửa thành công");
                        LayDuLieu();
                        OnOff(false);
                    }
                    else
                    {
                        MessageBox.Show(message);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
