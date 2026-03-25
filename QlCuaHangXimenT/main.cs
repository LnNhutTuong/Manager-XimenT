    using BUS;
using QlCuaHangXimenT.NhanVien;
using QlCuaHangXimenT.Properties;
using QlCuaHangXimenT.QuanLiSanPham;
using QlCuaHangXimenT.QuanLySanPham.SanPham;
using QlCuaHangXimenT.QuanLySanPham.ThuongHieu;
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

        private void ResetBtn()
        {
            //nut to
            Guna.UI2.WinForms.Guna2GradientButton[] btns = { btnTrangChu, btnNhanVien, btnQuanliSanPham };
            foreach (var b in btns)
            {
                b.CustomBorderThickness = new Padding(0);
                b.FillColor = Color.Transparent;
                b.FillColor2 = Color.Transparent;   
            }

            //nut nho
            Guna.UI2.WinForms.Guna2GradientButton[] subBtns = { btnDanhMuc, btnThuongHieu, btnSanPham };
            foreach (var b in subBtns)
            {
                b.FillColor = Color.FromArgb(34, 34, 34);
                b.FillColor2 = Color.FromArgb(34, 34, 34);
            }


        }

        private void ActiveBtn(Guna.UI2.WinForms.Guna2GradientButton btn)
        {
            // Nếu là nút Quản lí sản phẩm thì không reset
            if (btn != btnQuanliSanPham)
            {
                Reset();
                ResetBtn();
            }
            //Reset();
            //ResetBtn(); 

            if (btn == btnDanhMuc || btn == btnThuongHieu || btn == btnSanPham)
            {
                btn.FillColor = Color.FromArgb(80, 80, 80);
                btn.FillColor2 = Color.FromArgb(80, 80, 80);
            }
            else
            {
                btn.CustomBorderThickness = new Padding(0, 1, 0, 1);
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ActiveBtn(btnNhanVien);
            UC_NhanVien nv = new UC_NhanVien();
            nv.Dock = DockStyle.Fill;
            content.Controls.Add(nv);

            pnlSubSanPham.Visible = false; // đóng submenu
            btnQuanliSanPham.Image = Resources.up;
        }

        private void btnQuanliSanPham_Click(object sender, EventArgs e)
        {
            ActiveBtn(btnQuanliSanPham);

            bool isOpen = pnlSubSanPham.Visible;

            pnlSubSanPham.Visible = !isOpen;

            if (pnlSubSanPham.Visible)
                btnQuanliSanPham.Image = Resources.down;
            else
                btnQuanliSanPham.Image = Resources.up;
        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
            ActiveBtn(btnThuongHieu);
            UC_ThuongHieu th = new UC_ThuongHieu();
            th.Dock = DockStyle.Fill;
            content.Controls.Add(th);          
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            ActiveBtn(btnDanhMuc);
            UC_DanhMuc dm = new UC_DanhMuc();
            dm.Dock = DockStyle.Fill;
            content.Controls.Add(dm);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            ActiveBtn(btnSanPham);
            UC_SanPham sp = new UC_SanPham();
            sp.Dock = DockStyle.Fill;
            content.Controls.Add(sp);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            
        }
    }
}
