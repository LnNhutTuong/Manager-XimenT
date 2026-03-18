using QlCuaHangXimenT.Common.Enums;
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

            txtMaDanhMuc.Enabled = isEdit;
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
            DataRow row = dm.Rows[0];
            if (dm.Rows.Count > 0)
            {
                txtMaDanhMuc.Text = row["MaDM"].ToString();
                txtTenDanhMuc.Text = row["TenDM"].ToString();

            }
        }
    }
}
