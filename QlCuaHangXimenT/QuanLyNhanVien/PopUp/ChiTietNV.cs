using BUS;
using DTO;
using QlCuaHangXimenT.Common.Enums;
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

    public partial class ChiTietNV : Form
    {
        string maNV;
        DataTable nv;

        //bieesn CurrentMode cos kieeur FormMode
        public FormMode CurrentMode;

        public void SetMode(FormMode mode)
        {
            CurrentMode = mode;

            bool isEdit = (mode == FormMode.Edit);

            txtMaNhanVien.Enabled = isEdit;
            txtTenNhanVien.Enabled = isEdit;
            cboChucVu.Enabled = isEdit;
            txtTenDangNhap.Enabled = isEdit;
            txtMatKhau.Enabled = isEdit;
            btnThayAnh.Enabled = isEdit;

            btnSua.Visible = !isEdit;
            btnXoa.Visible = !isEdit;

            btnLuu.Visible = isEdit;
            btnHuy.Visible = isEdit;
        }
     

        public void DanhSachChucVu()
        {
            cboChucVu.DataSource = ChucVu_BUS.DanhSachChucVu();
            cboChucVu.DisplayMember = "TenCV";
            cboChucVu.ValueMember = "MaCV";

        }


        public ChiTietNV(string maNV, DataTable nv)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.nv = nv;
            DanhSachChucVu();
        }

        private void Sua_Load(object sender, EventArgs e)
        {
            SetMode(FormMode.View);
            lblTitle.Text = "Chi tiết Nhân viên";

            #region đưa data lên text box

            DataRow row = nv.Rows[0];
            if (nv.Rows.Count > 0)
            {
                txtMaNhanVien.Text = row["MaNV"].ToString();
                txtTenNhanVien.Text = row["TenNV"].ToString();
                cboChucVu.SelectedValue = row["MaCV"].ToString();
                txtTenDangNhap.Text = row["Ten_dang_nhap"].ToString();
                txtMatKhau.Text = row["Mat_khau"].ToString();

                if (row["HinhAnh"] == DBNull.Value)
                {
                    ptbNhanVien.Image = Resources.nonePicture;
                }
                else
                {
                    string pathAnh = row["HinhAnh"].ToString();

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
                    
            }                                
            #endregion

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetMode(FormMode.Edit);
            lblTitle.Text = "Sửa Nhân viên";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO();

            nv.MaNV = txtMaNhanVien.Text.ToUpper();
            nv.TenNV = txtTenNhanVien.Text;
            nv.Ten_dang_nhap = txtTenDangNhap.Text;
            nv.Mat_khau = txtMatKhau.Text;
            nv.MaCV = cboChucVu.SelectedValue.ToString();
            nv.HinhAnh = ptbNhanVien.Tag?.ToString();

            string message;

            bool kq = NhanVien_BUS.SuaNhanVien(nv, maNV, out message);

            if (kq)
            {
                MessageBox.Show("Sửa thành công");
                SetMode(FormMode.View);
            }
            else
            {
                MessageBox.Show(message);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetMode(FormMode.View);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.MaNV = txtMaNhanVien.Text;
            DialogResult ans;
            ans = MessageBox.Show("Bạn có muốn xóa NV: " + nv.MaNV + " không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                bool kq = NhanVien_BUS.XoaNhanVien(nv);

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

                #region Thư mục
                string folder = Application.StartupPath + "\\Image\\";

                //neu ko co Folder thi tao
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                #endregion

                #region Tên
                //ten ko trung
                DateTime date = DateTime.Now;
                string filename = txtMaNhanVien.Text + "_" + date.ToString("ddMMyyyy") + Path.GetExtension(file.FileName);
                //duong dan
                string newPath = folder + filename;
                #endregion

                #region rất lú, hiểu đơn giản: sử dụng thằng "using" để giải quyết cái bug ảnh bị khóa :))
                byte[] imageByte = File.ReadAllBytes(file.FileName);

                using (MemoryStream ms = new MemoryStream(imageByte)) {

                    ptbNhanVien.Image = Image.FromStream(ms);
                }
                #endregion

                File.Copy(file.FileName, newPath, true);

                //luu tag
                ptbNhanVien.Tag = "Image\\" + filename;

            }

        }
    }
}
