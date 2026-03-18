using BUS;
using DTO;
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
using System.IO;


namespace QlCuaHangXimenT.QuanLiNhanVien.Popup
{
    public partial class ThemNV : Form
    {
        public void DanhSachChucVu()
        {
            cboChucVu.DataSource = ChucVu_BUS.DanhSachChucVu();
            cboChucVu.DisplayMember = "TenCV";
            cboChucVu.ValueMember = "MaCV";
        }

        public ThemNV()
        {
            InitializeComponent();
            DanhSachChucVu();
            ptbNhanVien.Image = Resources.nonePicture;
        }


        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.MaNV = txtMaNhanVien.Text.ToUpper();
            nv.TenNV = txtTenNhanVien.Text;
            nv.MaCV = cboChucVu.SelectedValue.ToString();
            nv.Ten_dang_nhap = txtTenDangNhap.Text;
            nv.Mat_khau = txtMatKhau.Text;

            #region Kiến thức không mới ( đừng dùng kiểu này, tốn dung lượng quán nhiều)
            //MemoryStream ms = new MemoryStream();
            //if(ptbNhanVien.Image != Resources.nonePicture)
            //{
            //    ptbNhanVien.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //}
            //nv.HinhAnh = ms.ToArray();
            #endregion

            #region og
            nv.HinhAnh = ptbNhanVien.Tag?.ToString();
            #endregion


            string message;

            bool kq = NhanVien_BUS.ThemNhanVien(nv, out message);

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

        private void btnTaiLai_Click_1(object sender, EventArgs e)
        {
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            ptbNhanVien.Image = Resources.nonePicture;
        }

        private void btnThayAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image| *.jpg; *.png; *.bmp; *.gif";

            if (file.ShowDialog() == DialogResult.OK)
            {
                if (ptbNhanVien.Tag != null)
                {
                    string pathHienTai = Path.GetFullPath(Path.Combine(Application.StartupPath, ptbNhanVien.Tag.ToString()));
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
                string filename = txtMaNhanVien.Text + "_" + date.ToString("ddMMyyyy") + Path.GetExtension(file.FileName);

                //duong dan
                string newPath = folder + filename;

                //copy file cua nv vao bin

                File.Copy(file.FileName, newPath, true);

                ptbNhanVien.Image = Image.FromFile(file.FileName);

                //luu tag
                ptbNhanVien.Tag = "Image\\" + filename;


            }
        }        
    }
}

