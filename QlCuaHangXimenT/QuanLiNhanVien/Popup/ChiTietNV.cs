using BUS;
using DTO;
using QlCuaHangXimenT.Common.Enums;
using QlCuaHangXimenT.Properties;
using System;
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

    public partial class ChiTietNV : Form
    {
        string maNV;
        DataTable nv;

        public void OnOff(bool value)
        {
            txtMaNhanVien.Enabled = value;
            txtTenNhanVien.Enabled = value;
            cboChucVu.Enabled = value;
            txtTenDangNhap.Enabled = value;
            txtMatKhau.Enabled = value;
        }

        //bieesn CurrentMode cos kieeur FormMode
        public FormMode CurrentMode;

        public void SetMode(FormMode mode)
        {
            CurrentMode = mode;

            bool isEdit = (mode == FormMode.Edit);

            txtMaNhanVien.Enabled = isEdit;
            txtTenNhanVien.Enabled = isEdit;
            cboChucVu.Enabled = isEdit;
            txtTenDangNhap.Enabled = isEdit;
            txtMatKhau.Enabled = isEdit;

            btnSua.Visible = !isEdit;
            btnXoa.Visible = !isEdit;

            btnLuu.Visible = isEdit;
            btnHuy.Visible = isEdit;
        }
     

        public void DanhSachChucVu()
        {
            cboChucVu.DataSource = ChucVu_BUS.DanhSachChucVu();
            cboChucVu.DisplayMember = "TenCV";
            cboChucVu.ValueMember = "MaCV";

        }


        public ChiTietNV(string maNV, DataTable nv)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.nv = nv;
            DanhSachChucVu();
        }

        private void Sua_Load(object sender, EventArgs e)
        {
            OnOff(false);

            #region đưa data lên text box

            DataRow row = nv.Rows[0];

            foreach (DataColumn col in nv.Columns)
            {
                MessageBox.Show(col.ColumnName);
            }

            if (nv.Rows.Count > 0)
            {
                txtMaNhanVien.Text = row["MaNV"].ToString();
                txtTenNhanVien.Text = row["TenNV"].ToString();
                cboChucVu.SelectedValue = row["MaCV"].ToString();
                txtTenDangNhap.Text = row["Ten_dang_nhap"].ToString();
                txtMatKhau.Text = row["Mat_khau"].ToString();

                //if ( row["HinhAnh"] == DBNull.Value)
                //{
                //    ptbNhanVien.Image = Resources.nonePicture;
                //}
            }                                
            #endregion

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetMode(FormMode.Edit);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO();

            nv.MaNV = txtMaNhanVien.Text.ToUpper();
            nv.TenNV = txtTenNhanVien.Text;
            nv.Ten_dang_nhap = txtTenDangNhap.Text;
            nv.Mat_khau = txtMatKhau.Text;
            nv.MaCV = cboChucVu.SelectedValue.ToString();

            string message;

            bool kq = NhanVien_BUS.SuaNhanVien(nv, maNV, out message);

            if (kq)
            {
                MessageBox.Show("Sửa thành công");
                SetMode(FormMode.View);
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetMode(FormMode.View);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.MaNV = txtMaNhanVien.Text;
            DialogResult ans;
            ans = MessageBox.Show("Bạn có muốn xóa NV: " + nv.MaNV + " không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                bool kq = NhanVien_BUS.XoaNhanVien(nv);

                if (kq)
                {
                    MessageBox.Show("Xóa thành công");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }
    }
}
