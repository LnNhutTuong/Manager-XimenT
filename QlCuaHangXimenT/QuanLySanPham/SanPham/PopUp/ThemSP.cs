using BUS;
using BUS.QuanLySanPham;
using DTO;
using DTO.QuanLySanPham;
using QlCuaHangXimenT.Properties;
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

namespace QlCuaHangXimenT.QuanLySanPham.SanPham.PopUp
{
    public partial class ThemSP : Form
    {
        private void LayDuLieuCBO()
        {
            #region Danh sách danh mục
            cboDanhMuc.DisplayMember = "TenDM";
            cboDanhMuc.ValueMember = "MaDM";
            cboDanhMuc.DataSource = DanhMuc_BUS.DanhSachDanhMuc();

            #endregion

            #region Danh sách thương hiệu
            cboThuongHieu.DisplayMember = "TenTH";
            cboThuongHieu.ValueMember = "MaTH";
            cboThuongHieu.DataSource = ThuongHieu_BUS.DanhSachThuongHieu();

            #endregion

            #region Danh sách nhân viên
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DataSource = NhanVien_BUS.DanhSachNhanVien();

            #endregion
        }

        public ThemSP()
        {
            InitializeComponent();
            LayDuLieuCBO();
            lblNgayThem.Text = DateTime.Now.ToString("dd-MM-yyyy");

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SanPham_DTO sp = new SanPham_DTO();

            sp.MaSP = txtMaSanPham.Text.ToUpper().Trim();
            sp.TenSP = txtTenSanPham.Text;
            sp.Size = txtSize.Text;

            sp.MaDM = cboDanhMuc.SelectedValue.ToString();
            sp.MaTH= cboThuongHieu.SelectedValue.ToString();
            sp.MaNV= cboNhanVien.SelectedValue.ToString();
            sp.NgayThem = DateTime.Now;
            //sp.NgaySua = DateTime.Now;
            sp.HinhAnh = ptbSanPham.Tag?.ToString();

            string message;

            bool kq = SanPham_BUS.ThemSanPham(sp,txtGia.Text, txtSoLuongTon.Text, out message);

            if (kq)
            {
                MessageBox.Show("Thêm thành công");
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

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            txtSize.Clear();
            txtGia.Clear();
            txtSoLuongTon.Clear();
            ptbSanPham.Image = Resources.noImg;
        }
    }
}
