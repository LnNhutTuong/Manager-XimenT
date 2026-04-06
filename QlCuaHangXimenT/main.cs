    using BUS;
using BUS.Auth;
using DTO;
using DTO.Auth;
using QlCuaHangXimenT.CaiDat;
using QlCuaHangXimenT.KhachHang;
using QlCuaHangXimenT.NhanVien;
using QlCuaHangXimenT.Properties;
using QlCuaHangXimenT.QuanLiSanPham;
using QlCuaHangXimenT.QuanLyDonHang;
using QlCuaHangXimenT.QuanLySanPham.SanPham;
using QlCuaHangXimenT.QuanLySanPham.ThuongHieu;
using QlCuaHangXimenT.ThongKe;
using QlCuaHangXimenT.ThongKe.tab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BC = BCrypt.Net.BCrypt;
using System.Windows.Forms;
using System.Threading;
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
            Guna.UI2.WinForms.Guna2GradientButton[] btns = { btnNhanVien, btnQuanliSanPham, btnKhachHang, btnDonHang, btnThongKe, btnCaiDat };
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
            UC_NhanVien nv = new UC_NhanVien(this.nguoiDangNhap);
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
            //DangNhap();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ActiveBtn(btnKhachHang);
            UC_KhachHang kh = new UC_KhachHang();
            kh.Dock = DockStyle.Fill;
            content.Controls.Add(kh);
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            ActiveBtn(btnDonHang);
            UC_DonHang dh = new UC_DonHang();
            dh.Dock = DockStyle.Fill;
            content.Controls.Add(dh);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            ActiveBtn(btnThongKe);
            UC_ThongKe tk = new UC_ThongKe();
            tk.Dock = DockStyle.Fill;
            content.Controls.Add(tk);
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            ActiveBtn(btnCaiDat);
            UC_CaiDat cd = new UC_CaiDat(this.nguoiDangNhap.Ten_dang_nhap);
            cd.Dock = DockStyle.Fill;
            content.Controls.Add(cd);
        }

        void PhanQuyen()
        {
            string chucvu = nguoiDangNhap.MaCV;

            if (chucvu == "ADMIN") 
            {
                btnNhanVien.Visible = true;
                btnQuanliSanPham.Visible = true;
                btnKhachHang.Visible = true;
                btnDonHang.Visible = true;
                btnThongKe.Visible = true;
            }

            else if (chucvu == "CV001")
            {
                btnQuanliSanPham.Visible = true;
                btnThongKe.Visible = true;
            }

            else if (chucvu == "CV002")
            {
                btnKhachHang.Visible = true;
                btnThongKe.Visible = true;
            }

            else if (chucvu == "CV003")
            {
                btnDonHang.Visible = true;
                btnThongKe.Visible = true;
            }

        }

        private NguoiDung_DTO nguoiDangNhap;

        private bool DangNhap()
        {
          using(Login login = new Login())
            {
                if(login.ShowDialog() == DialogResult.OK)
                {
                    this.nguoiDangNhap = login.NguoiDungHienTai;

                    this.Show();

                    PhanQuyen();

                    lblTenNV.Text = this.nguoiDangNhap.TenNV.ToString();
                    lblChucVu.Text = this.nguoiDangNhap.TenCV.ToString();

                    if (this.nguoiDangNhap.HinhAnh == null)
                    {
                        ptbNhanVien.Image = Resources.nonePicture;
                    }
                    else
                    {
                        string pathAnh = this.nguoiDangNhap.HinhAnh.ToString();

                        string fullPath = Path.Combine(Application.StartupPath, pathAnh);

                        if (File.Exists(fullPath))
                        {
                            ptbNhanVien.Image = Image.FromFile(fullPath);
                            ptbNhanVien.Tag = pathAnh;
                        }
                        else
                        {
                            ptbNhanVien.Image = Resources.nonePicture;
                            MessageBox.Show(" ảnh không tồn tại nữa!");
                        }
                    }


                    btnDangXuat.Visible = true;
                    return true;                    
                }
                
                
                    return false;
                
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            this.Hide();
            if (!DangNhap())
            {
                Application.Exit();
            }
            guna2HtmlToolTip1.SetToolTip(lblHoTro, "<b style='color:Black'>Mẹo:</b> Click để xem hướng dẫn chi tiết!");

            lblNgay.Text = DateTime.Today.ToString("dd-MM-yyyy");

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.nguoiDangNhap = null;
                content.Controls.Clear();
                this.Hide();

                if (!DangNhap())
                {
                    Application.Exit();
                }
            }

        }

    }
}
