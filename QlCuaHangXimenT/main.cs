using System;
    using BUS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QlCuaHangXimenT.NhanVien;
using QlCuaHangXimenT.QuanLiSanPham;

namespace QlCuaHangXimenT
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        
        private void Reset()
        {
            content.Controls.Clear();
        }


        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            Reset();
            UC_NhanVien nv = new UC_NhanVien();
            lblViTri.Text = "Quản lí Nhân Viên";
            nv.Dock = DockStyle.Fill;
            content.Controls.Add(nv);

            
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            pnlSubSanPham.Visible = !pnlSubSanPham.Visible;
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            Reset();
            UC_DanhMuc dm = new UC_DanhMuc();
            lblViTri.Text = "Quản lí Sản Phẩm / Danh Mục";
            dm.Dock = DockStyle.Fill;
            content.Controls.Add(dm);
        }
    }
}
