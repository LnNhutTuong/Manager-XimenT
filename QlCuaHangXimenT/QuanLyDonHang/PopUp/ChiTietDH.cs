using BUS;
using BUS.QuanLyDonHang;
using BUS.QuanLyKhachHang;
using BUS.QuanLySanPham;
using DTO.QuanLyDonHang;
using QlCuaHangXimenT.Common.Enums;
using QlCuaHangXimenT.QuanLySanPham.SanPham.OverView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.QuanLyDonHang.PopUp
{
    public partial class ChiTietDH : Form
    {
        string maDH;
        DataTable donHang, ctDonHang;

        //bieesn CurrentMode cos kieeur FormMode
        public FormMode CurrentMode;

        public void SetMode(FormMode mode)
        {
            CurrentMode = mode;

            bool isEdit = (mode == FormMode.Edit);

            cboKhachHang.Visible = isEdit;
            cboNhanVien.Visible = isEdit;
            cboTrangThai.Visible = isEdit;

            lblNhanVien.Visible = !isEdit;
            lblKhachHang.Visible = !isEdit;
            lblTrangThai.Visible = !isEdit;

            btnSua.Visible = !isEdit;
            btnXoa.Visible = !isEdit;

            btnLuu.Visible = isEdit;
            btnHuy.Visible = isEdit;

            foreach(Control crl in flpDanhSachSanPham.Controls)
            {
                if(crl is Card_SanPham_Overview item)
                {
                    item.SetMode(mode);
                }
            }

            foreach (Control crl in flpGioHang.Controls)
            {
                if (crl is Card_SanPham_Overview item)
                {
                    item.SetMode(mode);
                }
            }
        }

        public void LayDuLieuCBO()
        {
            #region Danh sách nhân viên
            cboNhanVien.DisplayMember = "MaNV";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DataSource = NhanVien_BUS.DsNvTheoCv("CV002");
            #endregion


            #region Danh sách nhân viên
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
            cboKhachHang.DataSource = KhachHang_BUS.DanhSachKhachHang();
            #endregion
        }

        public ChiTietDH(string maDH, DataTable donHang, DataTable ctDonHang)
        {
            this.maDH = maDH;
            this.donHang = donHang;
            this.ctDonHang = ctDonHang; 

            InitializeComponent();

            LayDuLieuCBO();

        }

        int tongSoLuong = 0;

        public void CapNhatSoLuongTrongGio()
        {
            lblSoLuongTrongGio.Text = tongSoLuong.ToString();
        }

        void tinhTongTien()
        {
            decimal TongTien = 0;
            foreach (Control sanpham in flpGioHang.Controls)
            {
                if (sanpham is Card_SanPham_Overview item && sanpham.Visible == true)
                {
                    TongTien += (decimal)item.giaTien * item.SoLuongMua;
                }
            }

            lblTongTien.Text = TongTien.ToString("N0") + " VNĐ";
        }

        public void XuLiGioHang()
        {

            #region xử lí những sản phẩm trong đơn
            DataTable CartKhach = DonHang_BUS.ChiTietDonHangTheoMa(maDH);

            Dictionary<string, int> gioHangCuaKhach = new Dictionary<string, int>();

            if (CartKhach.Rows.Count > 0)
            {
                foreach (DataRow cart in CartKhach.Rows)
                {
                    string maSP = cart["MaSP"].ToString();
                    int SoLuong = Convert.ToInt32(cart["So_Luong"]);

                    if (!gioHangCuaKhach.ContainsKey(maSP))
                    {
                        gioHangCuaKhach.Add(maSP, SoLuong);
                    }
                    else
                    {
                        gioHangCuaKhach[maSP] += SoLuong;
                    }

                }

            }
            #endregion

            #region xử lí hiển thị những sản phẩm trong đơn
            DataTable dsSanPham = SanPham_BUS.DanhSachSanPham();
            if (dsSanPham.Rows.Count > 0)
            {
                flpDanhSachSanPham.Controls.Clear();
                flpGioHang.Controls.Clear();

                foreach (DataRow dr in dsSanPham.Rows)
                {

                    Card_SanPham_Overview cardTren = new Card_SanPham_Overview();
                    cardTren.SetData(dr["MaSP"].ToString(), dr["TenSP"].ToString(), Convert.ToInt32(dr["GiaBan"]), Convert.ToInt32(dr["SoLuongTon"]));
                    cardTren.SetMode(this.CurrentMode);
                    cardTren.SetContext(CardContext.ChuaVaoGio);
                    if (cardTren.SoLuongTon < 0)
                    {
                        cardTren.Visible = false; //ẩn
                    }


                    Card_SanPham_Overview cardDuoi = new Card_SanPham_Overview();
                    cardDuoi.SetData(dr["MaSP"].ToString(), dr["TenSP"].ToString(), Convert.ToInt32(dr["GiaBan"]), 0); // phải gán là 1 vì nó bị ăn theo cái SetData
                    cardDuoi.SetMode(this.CurrentMode);
                    cardDuoi.SetContext(CardContext.TrongGioHang);
                    cardDuoi.Visible = false; //ẩn                 

                    #region nếu sản phẩm đã có trong card thì
                    if (gioHangCuaKhach.ContainsKey(dr["MaSP"].ToString()))
                    {
                        int soLuongKhachDaMua = gioHangCuaKhach[dr["MaSP"].ToString()];

                        cardDuoi.CapNhatSoLuongMua(soLuongKhachDaMua);
                        cardDuoi.Visible = true;

                        //cardTren.CapNhatSoLuongTon(Convert.ToInt32(dr["SoLuongTon"]) - soLuongKhachDaMua);
                        tongSoLuong += soLuongKhachDaMua;
                 
                    }
                    #endregion

                    #region thêm vào giỏ
                    cardTren.OnActionClick = (c) => {

                        if (cardTren.SoLuongTon > 0)
                        {
                            cardTren.CapNhatSoLuongTon(cardTren.SoLuongTon - 1);

                            tongSoLuong++;
                            CapNhatSoLuongTrongGio();

                            if (cardDuoi.Visible == false)
                            {
                                cardDuoi.CapNhatSoLuongMua(1);
                                cardDuoi.Visible = true;// hiện
                            }
                            else
                            {
                                int them = cardDuoi.SoLuongMua + 1;
                                cardDuoi.CapNhatSoLuongMua(them);
                            }
                            tinhTongTien();
                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm đã hết hàng");
                        }
                    };
                    #endregion

                    #region xóa khỏi giỏi
                    cardDuoi.OnActionClick = (c) => {

                        if (cardDuoi.SoLuongMua > 0)
                        {
                            cardTren.CapNhatSoLuongTon(cardTren.SoLuongTon + 1);

                            tongSoLuong--;
                            CapNhatSoLuongTrongGio();

                            int soLuongMuaMoi = cardDuoi.SoLuongMua - 1;

                            cardDuoi.CapNhatSoLuongMua(soLuongMuaMoi);
                            if (soLuongMuaMoi == 0)
                            {
                                cardDuoi.Visible = false;
                            }
                            tinhTongTien();
                        }
                    };
                    #endregion

                    flpDanhSachSanPham.Controls.Add(cardTren);
                    flpGioHang.Controls.Add(cardDuoi);
                    CapNhatSoLuongTrongGio();
                    tinhTongTien();
                }
            }
            #endregion
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetMode(FormMode.Edit);
            lblTitle.Text = "Chỉnh sửa đơn hàng";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetMode(FormMode.View);
            lblTitle.Text = "Chỉnh sửa đơn hàng";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            decimal TongTien = 0;

            #region dữ liệu Đơn hàng
            DonHang_DTO dh = new DonHang_DTO();
            dh.MaDH = lblMaDonHang.Text.ToUpper();
            dh.MaNV = cboNhanVien.SelectedValue.ToString();
            dh.MaKH = cboKhachHang.SelectedValue.ToString();
            dh.TrangThai = Convert.ToInt32(cboTrangThai.SelectedIndex);
            #endregion

            #region dữ liệu Danh sách đơn hàng
            List<CtDonHang_DTO> ctdh = new List<CtDonHang_DTO>();

            foreach (Control sanpham in flpGioHang.Controls)
            {
                if (sanpham is Card_SanPham_Overview item && sanpham.Visible == true)
                {
                    CtDonHang_DTO ct = new CtDonHang_DTO();
                    ct.MaDH = dh.MaDH;
                    ct.MaSP = item.maSP;
                    ct.MaSP = item.maSP;
                    ct.DonGia = item.giaTien;
                    ct.SoLuong = item.SoLuongMua;

                    ctdh.Add(ct);

                    TongTien += item.giaTien * item.SoLuongMua;
                }
            }

            dh.TongTien = Convert.ToInt32(TongTien);


            #endregion
            string message;
            bool kq = DonHang_BUS.SuaDonHang(dh, ctdh, dh.MaDH,out message);

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

        private void ChiTietDH_Load(object sender, EventArgs e)
        {
            SetMode(FormMode.View);
            lblTitle.Text = "Chi tiết đơn hàng";

            #region Thông tin chi tiết 
            DataRow row = donHang.Rows[0];

            if(donHang.Rows.Count > 0)
            {
                lblMaDonHang.Text = row["MaDH"].ToString();

                lblNhanVien.Text = row["MaNV"].ToString();
                cboNhanVien.SelectedValue = row["MaNV"].ToString();

                lblKhachHang.Text = row["TenKH"].ToString();
                cboKhachHang.SelectedValue = row["MaKH"].ToString();

                lblNgayLap.Text = row["NgayTao"].ToString();

                int trangThai = Convert.ToInt32(row["TrangThai"]);
                if (trangThai == 0)
                {
                    lblTrangThai.ForeColor = Color.Blue;
                    lblTrangThai.Text = "Chưa Giao";
                    cboTrangThai.SelectedIndex= 0;
                    
                }
                else if (trangThai == 1)
                {
                    lblTrangThai.ForeColor = Color.Yellow;
                    lblTrangThai.Text = "Đang Giao";
                    cboTrangThai.SelectedIndex = 1;
                }
                else if (trangThai == 2)
                {
                    lblTrangThai.ForeColor = Color.Green;
                    lblTrangThai.Text = "Giao thành công";
                    cboTrangThai.SelectedIndex = 2;
                }
                else if (trangThai == 3)
                {
                    lblTrangThai.ForeColor = Color.Red;
                    lblTrangThai.Text = "Đã hủy";
                    cboTrangThai.SelectedIndex = 3;
                }

            }
            #endregion

            XuLiGioHang();
        }


    }
}
