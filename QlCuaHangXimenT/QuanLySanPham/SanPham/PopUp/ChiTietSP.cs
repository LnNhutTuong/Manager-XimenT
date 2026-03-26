using BUS;
using BUS.QuanLySanPham;
using DTO;
using DTO.QuanLySanPham;
using QlCuaHangXimenT.Common.Enums;
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
            cboNhanVien.DisplayMember = "MaNV";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DataSource = NhanVien_BUS.DsNvTheoCv("CV002");
            #endregion
            
        }


        public ChiTietSP(string maSP)
        {
            InitializeComponent();
            this.maSP = maSP;
            SetData();
            LayDuLieuCBO();
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
                cboDanhMuc.SelectedValue = sanPham["MaDM"].ToString();

                lblThuongHieu.Text = sanPham["TenTH"].ToString();
                cboThuongHieu.SelectedValue = sanPham["MaTH"].ToString();


                lblSize.Text = sanPham["Size"].ToString();

                decimal gia = Convert.ToInt32(sanPham["Gia"]);
                lblGia.Text = gia.ToString("N0") + " VNĐ";

                lblMaSanPham.Text = sanPham["MaSP"].ToString();

                lblMaNV.Text = sanPham["MaNV"].ToString();
                cboNhanVien.SelectedValue = sanPham["MaNV"].ToString();


                DateTime ngayThem = Convert.ToDateTime(sanPham["NgayThem"]);
                lblNgayThem.Text = ngayThem.ToString("dd-MM-yyyy");

                lblSoLuongTon.Text = sanPham["SoLuongTon"].ToString();

                DateTime ngaySua = Convert.ToDateTime(sanPham["NgaySua"]);
                lblNgaySua.Text = ngaySua.ToString("dd-MM-yyyy HH:mm:ss");

                if (sanPham["HinhAnh"] == DBNull.Value)
                {
                    ptbSanPham.Image = Resources.noImg;
                    ptbSanPham.Tag = null;
                }
                else
                {
                    string pathAnh = sanPham["HinhAnh"].ToString();

                    ptbSanPham.Tag = pathAnh;

                    string fullPath = Path.Combine(Application.StartupPath, pathAnh);

                    if (File.Exists(fullPath))
                    {

                        #region chạm thôi không nắm
                        byte[] imageByte = File.ReadAllBytes(fullPath);

                        using (MemoryStream ms = new MemoryStream(imageByte))
                        {

                            ptbSanPham.Image = Image.FromStream(ms);
                        }
                        #endregion
                    }
                    else
                    {
                        ptbSanPham.Image = Resources.noImg;
                        MessageBox.Show(" ảnh không tồn tại nữa!");
                    }
                }
            }                                      
       }    

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (sanPham == null) return;

            SetMode(FormMode.Edit);
            lblTitle.Text = "Chỉnh sửa sản phẩm";

            txtTenSanPham.Text = sanPham["TenSP"].ToString();
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
            try
            {
                SanPham_DTO sp = new SanPham_DTO();

                sp.TenSP = txtTenSanPham.Text;
                sp.Size = txtSize.Text;
                sp.MaDM = cboDanhMuc.SelectedValue?.ToString();
                sp.MaTH = cboThuongHieu.SelectedValue?.ToString();
                sp.MaNV = cboNhanVien.SelectedValue?.ToString();
                //sp.NgaySua = DateTime.Now;
                sp.HinhAnh = ptbSanPham.Tag?.ToString();


                string message = "";
                bool kq = SanPham_BUS.SuaSanPham(sp, maSP, txtGia.Text, txtSoLuongTon.Text, out message);

                if (kq)
                {
                    MessageBox.Show("Sửa thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show(message);
                {
                }
            }catch( Exception ex)
            {
                MessageBox.Show(ex.Message);

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
                string filename = lblMaSanPham.Text + "_" + date.ToString("ddMMyyyy") + Path.GetExtension(file.FileName);
                //duong dan
                string newPath = folder + filename;
                #endregion


                #region cho ảnh đang chọn đoi vễ kĩ luôn
                if (ptbSanPham.Image != null)
                {
                    ptbSanPham.Image.Dispose(); // hãy buông tha cho tấm ảnh pls
                    ptbSanPham.Image = null;
                }
                #endregion

                File.Copy(file.FileName, newPath, true);


                #region rất lú, hiểu đơn giản: sử dụng thằng "using" để giải quyết cái bug ảnh bị khóa :))
                byte[] imageByte = File.ReadAllBytes(file.FileName);

                using (MemoryStream ms = new MemoryStream(imageByte))
                {

                    ptbSanPham.Image = Image.FromStream(ms);
                }
                #endregion


                //luu tag
                ptbSanPham.Tag = "Image\\" + filename;

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show($"Bạn có muốn xóa {lblMaSanPham.Text} sản phẩm?", "Xác nhận", MessageBoxButtons.YesNo);

            if (ans == DialogResult.Yes)
            {
                bool kq = SanPham_BUS.XoaSanPham(maSP);
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
        
    }
}
