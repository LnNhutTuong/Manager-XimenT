    using BUS;
using QlCuaHangXimenT.NhanVien;
using QlCuaHangXimenT.Properties;
using QlCuaHangXimenT.QuanLiSanPham;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void ResetBtn ()
        {
            btnTrangChu.CustomBorderThickness = new Padding(0);
            btnNhanVien.CustomBorderThickness = new Padding(0);
            btnDanhMuc.CustomBorderThickness = new Padding(0);
            btnThuongHieu.CustomBorderThickness = new Padding(0);
            btnQuanliSanPham.CustomBorderThickness = new Padding(0);
        }

        private void ActiveBtn (Guna.UI2.WinForms.Guna2GradientButton btn)
        {
            ResetBtn();
            btn.CustomBorderThickness = new Padding(0,1,0,1);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            Reset();
            ActiveBtn(btnNhanVien);
            UC_NhanVien nv = new UC_NhanVien();
            nv.Dock = DockStyle.Fill;
            content.Controls.Add(nv);

            pnlSubSanPham.Visible = false; // đóng submenu
            btnQuanliSanPham.Image = Resources.up;
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            ActiveBtn(btnQuanliSanPham);

            bool isOpen = pnlSubSanPham.Visible;

            pnlSubSanPham.Visible = !isOpen;

            if (pnlSubSanPham.Visible)
                btnQuanliSanPham.Image = Resources.down;
            else
                btnQuanliSanPham.Image = Resources.up;
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            Reset();
            btnDanhMuc.FillColor = Color.FromArgb(80, 80, 80);
            btnDanhMuc.FillColor2 = Color.FromArgb(80, 80, 80);
            UC_DanhMuc dm = new UC_DanhMuc();
            dm.Dock = DockStyle.Fill;
            content.Controls.Add(dm);
        }
    }
}
