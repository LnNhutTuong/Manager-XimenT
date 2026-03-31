using BUS;
using BUS.QuanLyDonHang;
using BUS.QuanLyKhachHang;
using BUS.QuanLySanPham;
using QlCuaHangXimenT.Common.Enums;
using QlCuaHangXimenT.QuanLySanPham.SanPham.OverView;
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

namespace DTO.QuanLyDonHang
{
    public partial class ThemDH : Form
    {
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
            DataTable dsSanPham = SanPham_BUS.DanhSachSanPham();

            if (dsSanPham.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSanPham.Rows)
                {

                    Card_SanPham_Overview cardTren = new Card_SanPham_Overview();
                    cardTren.SetData(dr["MaSP"].ToString(), dr["TenSP"].ToString(), Convert.ToInt32(dr["Gia"]), Convert.ToInt32(dr["SoLuongTon"]));
                    cardTren.SetContext(CardContext.ChuaVaoGio);
                    if(cardTren.SoLuongTon < 0)
                    {
                        cardTren.Visible = false; //ẩn
                    }

                    Card_SanPham_Overview cardDuoi = new Card_SanPham_Overview();
                    cardDuoi.SetData(dr["MaSP"].ToString(), dr["TenSP"].ToString(), Convert.ToInt32(dr["Gia"]), 1); // phải gán là 1 vì nó bị ăn theo cái SetData
                    cardDuoi.SetContext(CardContext.TrongGioHang);
                    cardDuoi.Visible = false; //ẩn                 

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
                    tinhTongTien();
                    CapNhatSoLuongTrongGio();

                }
            }
        }

        public void LayDuLieuCBO()
        {

            #region Danh sách nhân viên
            cboNhanVien.DisplayMember = "MaNV";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DataSource = NhanVien_BUS.DsNvTheoCv("CV004");
            #endregion


            #region Danh sách nhân viên
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
            cboKhachHang.DataSource = KhachHang_BUS.DanhSachKhachHang();
            #endregion
        }

        public ThemDH()
        {
            InitializeComponent();
            LayDuLieuCBO();     
            XuLiGioHang();

            lblNgayLap.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }


      

        private void btnLuu_Click(object sender, EventArgs e)
        {
            #region dữ liệu Đơn hàng
            DonHang_DTO dh = new DonHang_DTO();
            dh.MaDH = txtMaDonHang.Text.ToUpper();
            dh.MaNV = cboNhanVien.SelectedValue.ToString();
            dh.MaKH = cboKhachHang.SelectedValue.ToString();
            dh.NgayTao = DateTime.Today;
            #endregion

            #region dữ liệu Danh sách đơn hàng
            List<CtDonHang_DTO> ctdh = new List<CtDonHang_DTO>();

            foreach (Control sanpham in flpGioHang.Controls)
            {
                // nếu sản phẩm là biến item có kiểu card
                if (sanpham is Card_SanPham_Overview item && sanpham.Visible == true)
                {
                    CtDonHang_DTO ct = new CtDonHang_DTO();
                    ct.MaDH = dh.MaDH;
                    ct.MaSP = item.maSP;
                    ct.MaSP = item.maSP;
                    ct.DonGia = item.giaTien;
                    ct.SoLuong = item.SoLuongMua;

                    ctdh.Add(ct);
                }
            }

            #endregion
            string message;
            bool kq = DonHang_BUS.ThemDonHang(dh, ctdh, out message);

            if (kq)
            {
                MessageBox.Show("Thêm thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            #region xử lí Thông tin đơn
            txtMaDonHang.Clear();
            #endregion

            #region xử lí giỏ hàng về MORE
            flpDanhSachSanPham.Controls.Clear();
            flpGioHang.Controls.Clear();

            tongSoLuong = 0;
            CapNhatSoLuongTrongGio();
            tinhTongTien();

            XuLiGioHang();
            #endregion
        }
    }
}
