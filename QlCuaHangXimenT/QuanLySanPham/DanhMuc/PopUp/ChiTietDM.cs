using BUS;
using BUS.QuanLySanPham;
using DTO;
using QlCuaHangXimenT.Common.Enums;
using QlCuaHangXimenT.QuanLySanPham.SanPham;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QlCuaHangXimenT.QuanLySanPham.DanhMuc.PopUp
{
    public partial class ChiTietDM : Form
    {


        string maDM;
        DataTable dm;

        public FormMode CurrentMode;

        public void SetMode(FormMode mode)
        {
            CurrentMode = mode;

            bool isEdit = (mode == FormMode.Edit);

            //txtMaDanhMuc.Enabled = isEdit;
            txtTenDanhMuc.Enabled = isEdit;

            btnSua.Visible = !isEdit;
            btnXoa.Visible = !isEdit;

            btnLuu.Visible = isEdit;
            btnHuy.Visible = isEdit;
        }

        public ChiTietDM(string maDM, DataTable dm)
        {
            InitializeComponent();
            this.maDM = maDM;
            this.dm = dm;
        }

        private void ChiTietDM_Load(object sender, EventArgs e)
        {
            SetMode(FormMode.View);
            lblTitle.Text = "Chi tiết Danh mục";
            DataRow row = dm.Rows[0];
            if (dm.Rows.Count > 0)
            {
                txtMaDanhMuc.Text = row["MaDM"].ToString();
                txtTenDanhMuc.Text = row["TenDM"].ToString();

            }
            string message;
            DataTable dsSanPham = DanhMuc_BUS.DanhSachSPTheoMaDM(maDM, out message);


            if (dsSanPham.Rows.Count>0)
            {
                foreach (DataRow dr in dsSanPham.Rows)
                {
                    short_SanPham spSort = new short_SanPham();

                    flpSanPham.Controls.Add(spSort);
                }
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetMode(FormMode.Edit);
            lblTitle.Text = "Sửa danh mục";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DanhMuc_DTO dm = new DanhMuc_DTO();

            //dm.MaDM = txtMaDanhMuc.Text.ToUpper();
            dm.TenDM = txtTenDanhMuc.Text;

            string message;

            bool kq = DanhMuc_BUS.SuaDanhMuc(dm, maDM, out message);

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
            DanhMuc_DTO dm = new DanhMuc_DTO();

            dm.MaDM = maDM;

            DialogResult ans;
            ans = MessageBox.Show("Bạn có muốn xóa DM: " + dm.MaDM + " không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                bool kq = DanhMuc_BUS.XoaDanhMuc(dm);

                if (kq)
                {
                    MessageBox.Show("Xóa thành công");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }
    }
}
