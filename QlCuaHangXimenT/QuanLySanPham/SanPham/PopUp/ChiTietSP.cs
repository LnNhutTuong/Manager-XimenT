using BUS;
using BUS.QuanLySanPham;
using DTO;
using DTO.QuanLySanPham;
using QlCuaHangXimenT.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.QuanLySanPham.SanPham
{
    public partial class ChiTietSP : Form
    {
        string maSP;
        DataTable dm;

        public FormMode CurrentMode;

        public void SetMode(FormMode mode)
        {
            CurrentMode = mode;

            bool isEdit = (mode == FormMode.Edit);

            //txtMaDanhMuc.Enabled = isEdit;
            txtTenSanPham.Visible = isEdit;
            txtMaSanPham.Visible = isEdit;
            txtSize.Visible = isEdit;
            txtGia.Visible = isEdit;
            txtSoLuongTon.Visible = isEdit;

            cboDanhMuc.Visible = isEdit;
            cboThuongHieu.Visible = isEdit;
            cboNhanVien.Visible = isEdit;



            lblTenSP.Visible = !isEdit;

            lblDanhMuc.Visible = !isEdit;
            lblThuongHieu.Visible = !isEdit;
            lblSize.Visible = !isEdit;
            lblGia.Visible = !isEdit;

            lblMaSanPham.Visible = !isEdit;
            lblMaNV.Visible = !isEdit;
            lblSoLuongTon.Visible = !isEdit;


            btnSua.Visible = !isEdit;
            btnXoa.Visible = !isEdit;

            btnLuu.Visible = isEdit;
            btnHuy.Visible = isEdit;
            btnThayAnh.Visible = isEdit;
        }

        private void LayDuLieuCBO()
        {
            #region Danh sách danh mục
            cboDanhMuc.DataSource = DanhMuc_BUS.DanhSachDanhMuc();
            cboDanhMuc.DisplayMember = "TenDM";
            cboDanhMuc.ValueMember = "MaDM";
            #endregion

            #region Danh sách thương hiệu
            cboThuongHieu.DataSource = ThuongHieu_BUS.DanhSachThuongHieu();
            cboThuongHieu.DisplayMember = "TenTH";
            cboThuongHieu.ValueMember = "MaTH";
            #endregion

            #region Danh sách nhân viên
            cboNhanVien.DataSource = NhanVien_BUS.DanhSachNhanVien();
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";
            #endregion
        }


        public ChiTietSP(string maSP)
        {
            InitializeComponent();
            this.maSP = maSP;
            LayDuLieuCBO();
            SetData();
            SetMode(FormMode.View);
            lblTitle.Text = ("Chi tiết sản phẩm");

        }


        DataRow sanPham;
        public void SetData()
        {
            string message;
            DataTable sp = SanPham_BUS.SanPhamTheoMa(maSP, out message);
            if (sp != null && sp.Rows.Count > 0)
            {
                 sanPham = sp.Rows[0];

                lblTenSP.Text = sanPham["TenSP"].ToString();

                lblDanhMuc.Text = sanPham["TenDM"].ToString();
                lblThuongHieu.Text = sanPham["TenTH"].ToString();
                lblSize.Text = sanPham["Size"].ToString();

                decimal gia = Convert.ToInt32(sanPham["Gia"]);
                lblGia.Text = gia.ToString("N0") + " VNĐ";

                lblMaSanPham.Text = sanPham["MaSP"].ToString();
                lblMaNV.Text = sanPham["MaNV"].ToString();

                DateTime ngayThem = Convert.ToDateTime(sanPham["NgayThem"]);
                lblNgayThem.Text = ngayThem.ToString("dd-MM-yyyy");

                lblSoLuongTon.Text = sanPham["SoLuongTon"].ToString();

                DateTime ngaySua = Convert.ToDateTime(sanPham["NgaySua"]);
                lblNgaySua.Text = ngaySua.ToString("dd-MM-yyyy HH:mm:ss");
            }                                      
       }    

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (sanPham == null) return;

            SetMode(FormMode.Edit);
            lblTitle.Text = "Chỉnh sửa sản phẩm";

            txtTenSanPham.Text = sanPham["TenSP"].ToString();
            txtMaSanPham.Text = sanPham["MaSP"].ToString();
            txtSize.Text = sanPham["Size"].ToString();
            txtGia.Text = sanPham["Gia"].ToString(); 
            txtSoLuongTon.Text = sanPham["SoLuongTon"].ToString();

            cboDanhMuc.SelectedValue = sanPham["MaDM"].ToString();
            cboThuongHieu.SelectedValue = sanPham["MaTH"].ToString();
            cboNhanVien.SelectedValue = sanPham["MaNV"].ToString();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetMode(FormMode.View);
            lblTitle.Text = ("Chi tiết sản phẩm");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SanPham_DTO sp = new SanPham_DTO();

            sp.MaSP = txtMaSanPham.Text;
            sp.TenSP = txtTenSanPham.Text;
            sp.Size = txtSize.Text;
            sp.MaDM = cboDanhMuc.SelectedValue?.ToString();
            sp.MaTH = cboThuongHieu.SelectedValue?.ToString();
            sp.MaNV = cboNhanVien.SelectedValue?.ToString();
            sp.NgaySua = DateTime.Now; 
            sp.HinhAnh = ptbSanPham.Tag?.ToString();

            // vì lý do an toàn nên hãy làm một cách an toàn đi, đừng mạo hiểm nữa my boy! dear XimenT
            int gia, soLuong;
            int.TryParse(txtGia.Text, out gia);
            int.TryParse(txtSoLuongTon.Text, out soLuong);

            sp.Gia = gia;
            sp.SoLuongTon = soLuong;

            string message;
            bool kq = SanPham_BUS.SuaSanPham(sp, maSP, out message);

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

        private void btnThayAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image| *.jpg; *.png; *.bmp; *.gif";

            if (file.ShowDialog() == DialogResult.OK)
            {
                if (ptbSanPham.Tag != null)
                {
                    string pathHienTai = Path.GetFullPath(Path.Combine(Application.StartupPath, ptbSanPham.Tag.ToString()));
                    string pathMoi = Path.GetFullPath(file.FileName);

                    if (pathHienTai.Equals(pathMoi, StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }
                }
                //tao bien folder
                string folder = Application.StartupPath + "\\Image\\";

                //neu ko co Folder thi tao
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                //ten ko trung
                DateTime date = DateTime.Now;
                string filename = txtMaSanPham.Text + "_" + date.ToString("ddMMyyyy") + Path.GetExtension(file.FileName);

                //duong dan
                string newPath = folder + filename;

                //copy file cua nv vao bin

                File.Copy(file.FileName, newPath, true);

                ptbSanPham.Image = Image.FromFile(file.FileName);

                //luu tag
                ptbSanPham.Tag = "Image\\" + filename;
            }
        }
    }
}
