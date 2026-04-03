using BUS.QuanLySanPham;
using QlCuaHangXimenT.Common.Enums;
using QlCuaHangXimenT.QuanLySanPham.DanhMuc.PopUp;
using QlCuaHangXimenT.QuanLySanPham.SanPham.PopUp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QlCuaHangXimenT.QuanLySanPham.SanPham
{
    public partial class UC_SanPham : UserControl
    {

        void TongSoLuong()
        {
            DataTable TongSoLuong = SanPham_BUS.DanhSachSanPham();
            lblSoLuongSanPham.Text = TongSoLuong.Rows.Count.ToString();

        }

        public UC_SanPham()
        {
            InitializeComponent();
            TongSoLuong();
            LayDuLieuCBO();
            LoadFlowTheoDK();

            dtpBatDau.MaxDate = DateTime.Now;

            dtpKetThuc.MaxDate = DateTime.Now;
        }

        public void LayDuLieuCBO()
        {
            #region Danh sách Danh mục
            DataTable dm = DanhMuc_BUS.DanhSachDanhMuc();

            DataRow dr = dm.NewRow();
            dr["MaDM"] = DBNull.Value;          
            dr["TenDM"] = "*Chọn danh mục*"; 

            dm.Rows.InsertAt(dr, 0);

            cboDanhMuc.DisplayMember = "TenDM";
            cboDanhMuc.ValueMember = "MaDM";
            cboDanhMuc.DataSource = dm;
            #endregion

            #region Danh sách thương hiệu
             DataTable tt = ThuongHieu_BUS.DanhSachThuongHieu();

            DataRow dro = tt.NewRow();
            dro["MaTH"] = DBNull.Value;
            dro["TenTH"] = "*Chọn thương hiệu*"; 

            tt.Rows.InsertAt(dro, 0);
            cboThuongHieu.DisplayMember = "TenTH";
            cboThuongHieu.ValueMember = "MaTH";
            cboThuongHieu.DataSource = tt;
            #endregion

        }

        private void LoadFlowTheoDK()
        {
            flpSanPham.Controls.Clear();

            string maDM = (cboDanhMuc.SelectedIndex <= 0) ? null : cboDanhMuc.SelectedValue.ToString();
            string maTH = (cboThuongHieu.SelectedIndex <= 0) ? null : cboThuongHieu.SelectedValue.ToString();

            DateTime? tuNgay = dtpBatDau.Checked ? dtpBatDau.Value.Date : (DateTime?)null;
            DateTime? denNgay = dtpKetThuc.Checked ? dtpKetThuc.Value.Date.AddDays(1).AddTicks(-1) : (DateTime?)null;

            string tuKhoa = string.IsNullOrEmpty(txtTimKiem.Text) ? null : txtTimKiem.Text;
            DataTable dsSanPham = SanPham_BUS.LocSanPham(maDM, maTH, tuNgay, denNgay, tuKhoa);

            if (dsSanPham.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSanPham.Rows)
                {
                    card_SanPham sanpham = new card_SanPham();

                    sanpham.SetData(dr["MaSP"].ToString(), dr["TenSP"].ToString(), Convert.ToInt32(dr["GiaBan"]), dr["HinhAnh"].ToString());

                    sanpham.added = () =>
                    {
                        LoadFlowTheoDK();
                    };
                    flpSanPham.Controls.Add(sanpham);
                }
            }

            lblSoSanPhamPhuHop.Text = flpSanPham.Controls.Count.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSP them = new ThemSP();
            if (them.ShowDialog() == DialogResult.OK)
            {
                LoadFlowTheoDK();
            }
        }


        #region Xóa theo số lượng Card được chọn
        List<string> dsSpChon = new List<string>();

        private List<string> DsSpChon()
        {

            // chạy foreach hết tất cả thứ trong flow, bao gồm tất cả btn, label, panle,... ko bỏ gì hết
            foreach (Control ctrl in flpSanPham.Controls)
            {
                //nếu đó là panel mang tên ... do mình đặt 
                if (ctrl is card_SanPham card)
                {
                    // ez
                    if (card.CurrentMode == CardMode.Selected)
                    {
                        dsSpChon.Add(card.MaSP);
                    }
                    else 
                    {
                        dsSpChon.Remove(card.MaSP);
                    }
                }
            }
            return dsSpChon;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            List<string> dsDaChon = DsSpChon();
            if ( dsSpChon.Count == 0){
                MessageBox.Show("Vui lòng chọn sản phẩm đế xóa");
            }
            else
            {
                DialogResult ans = MessageBox.Show($"Bạn có muốn xóa {dsSpChon.Count} sản phẩm?", "Xác nhận", MessageBoxButtons.YesNo);

                if (ans == DialogResult.Yes)
                {
                    int flag = 0;
                    foreach (string maSP in dsDaChon)
                    {
                       bool kq = SanPham_BUS.XoaSanPham(maSP);

                        if (!kq)
                        {                            
                            flag++;
                            break;
                        }
                    }

                    if(flag != 0)
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                    else
                    {
                        LoadFlowTheoDK();
                        MessageBox.Show("Xóa thành công");
                    }
                }
                       
            }
        }

        #endregion

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFlowTheoDK();
        }

        private void cboThuongHieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFlowTheoDK();
        }

        private void dtpBatDau_ValueChanged(object sender, EventArgs e)
        {
            LoadFlowTheoDK();
        }

        private void dtpKetThuc_ValueChanged(object sender, EventArgs e)
        {
            LoadFlowTheoDK();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadFlowTheoDK();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            cboDanhMuc.SelectedIndex = 0;
            cboThuongHieu.SelectedIndex = 0;

            dtpBatDau.Value = new DateTime(2022,02,22);
            dtpKetThuc.Value = DateTime.Today;

            txtTimKiem.Clear();

            LoadFlowTheoDK();
        }
    }
}
