using BUS;
using BUS.QuanLySanPham;
using DTO;
using DTO.QuanLySanPham;
using QlCuaHangXimenT.Common.Enums;
using QlCuaHangXimenT.QuanLySanPham.SanPham;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.QuanLySanPham.ThuongHieu
{
    public partial class ChiTietTH : Form
    {
        string maTH;
        DataTable th;

        public FormMode CurrentMode;

        public ChiTietTH(string maTH, DataTable th )
        {
            InitializeComponent();
            this.maTH = maTH;
            this.th = th;
        }

        public void SetMode(FormMode mode)
        {
            CurrentMode = mode;

            bool isEdit = (mode == FormMode.Edit);

            //txtMaDanhMuc.Enabled = isEdit;
            txtTenThuongHieu.Enabled = isEdit;

            btnSua.Visible = !isEdit;
            btnXoa.Visible = !isEdit;

            btnLuu.Visible = isEdit;
            btnHuy.Visible = isEdit;
        }

        private void ChiTietTH_Load(object sender, EventArgs e)
        {
            #region Data ThuongHieu
            SetMode(FormMode.View);
            lblTitle.Text = "Chi tiết Thương hiệu";
            DataRow row = th.Rows[0];
            if (th.Rows.Count > 0)
            {
                txtMaThuongHieu.Text = row["MaTH"].ToString();
                txtTenThuongHieu.Text = row["TenTH"].ToString();

            }
            #endregion

            #region ListSanPham theo TH
            string message;
            DataTable dsSanPham = ThuongHieu_BUS.DanhSachSPTheoTH(maTH, out message);
            if (dsSanPham.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSanPham.Rows)
                {
                    short_SanPham spSort = new short_SanPham();

                    spSort.SetData(dr["MaSP"].ToString(), dr["TenSP"].ToString(), Convert.ToInt32(dr["Gia"]));
                    flpSanPham.Controls.Add(spSort);
                }
            }
            #endregion

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetMode(FormMode.Edit);
            lblTitle.Text = "Chỉnh sửa Thương hiệu";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThuongHieu_DTO th = new ThuongHieu_DTO();

            th.TenTH = txtTenThuongHieu.Text;

            string message;

            bool kq = ThuongHieu_BUS.SuaThuongHieu(th, maTH, out message);

            if (kq)
            {
                MessageBox.Show("Sửa thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ThuongHieu_DTO th = new ThuongHieu_DTO();

            th.MaTH = txtMaThuongHieu.Text;

            DialogResult ans;
            ans = MessageBox.Show("Bạn có muốn xóa TH: " + th.MaTH + " không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                bool kq = ThuongHieu_BUS.XoaThuongHieu(th);

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
