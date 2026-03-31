using BUS;
using BUS.QuanLyDonHang;
using BUS.QuanLyKhachHang;
using BUS.QuanLySanPham;
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

            txtMaDonHang.Visible = isEdit;

            cboKhachHang.Visible = isEdit;
            cboNhanVien.Visible = isEdit;


            lblMaDonHang.Visible = !isEdit;

            lblMaDonHang.Visible = !isEdit;
            lblNhanVien.Visible = !isEdit;
            lblKhachHang.Visible = !isEdit;

            btnSua.Visible = !isEdit;
            btnXoa.Visible = !isEdit;

            btnLuu.Visible = isEdit;
            btnHuy.Visible = isEdit;
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
            DataTable CartKhach = DonHang_BUS.DonHangTheoMa(maDH);

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
                    cardTren.SetData(dr["MaSP"].ToString(), dr["TenSP"].ToString(), Convert.ToInt32(dr["Gia"]), Convert.ToInt32(dr["SoLuongTon"]));
                    cardTren.SetContext(CardContext.ChuaVaoGio);
                    if (cardTren.SoLuongTon < 0)
                    {
                        cardTren.Visible = false; //ẩn
                    }


                    Card_SanPham_Overview cardDuoi = new Card_SanPham_Overview();
                    cardDuoi.SetData(dr["MaSP"].ToString(), dr["TenSP"].ToString(), Convert.ToInt32(dr["Gia"]), 1); // phải gán là 1 vì nó bị ăn theo cái SetData
                    cardDuoi.SetContext(CardContext.TrongGioHang);
                    cardDuoi.Visible = false; //ẩn                 

                    #region nếu sản phẩm đã có trong card thì
                    if (gioHangCuaKhach.ContainsKey(dr["MaSP"].ToString()))
                    {
                        int soLuongKhachDaMua = gioHangCuaKhach[dr["MaSP"].ToString()];

                        cardDuoi.CapNhatSoLuongMua(soLuongKhachDaMua);
                        cardDuoi.Visible = true;

                        cardTren.CapNhatSoLuongTon(Convert.ToInt32(dr["SoLuongTon"]) - soLuongKhachDaMua);
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
                }
            }
            #endregion
        }


        private void ChiTietDH_Load(object sender, EventArgs e)
        {
            SetMode(FormMode.View);
            lblTitle.Text = "Chi tiết đơn hàng";

            #region Thông tin chi tiết 
            DataRow row = donHang.Rows[0];

            if(donHang.Rows.Count >0)
            {
                lblMaDonHang.Text = row["MaDH"].ToString();

                lblNhanVien.Text = row["TenNV"].ToString();
                cboNhanVien.SelectedValue = row["MaNV"].ToString();

                lblKhachHang.Text = row["TenKH"].ToString();
                cboKhachHang.SelectedValue = row["MaKH"].ToString();
            }
            #endregion

            XuLiGioHang();
            


        }


    }
}
