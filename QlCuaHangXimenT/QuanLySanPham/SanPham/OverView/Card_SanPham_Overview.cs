using QlCuaHangXimenT.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.QuanLySanPham.SanPham.OverView
{
    public partial class Card_SanPham_Overview : UserControl
    {
        public Card_SanPham_Overview()
        {
            InitializeComponent();
        }

        public CardContext CurrentContext;

        public void SetContext(CardContext context)
        {
            CurrentContext = context;

            if (context == CardContext.ChuaVaoGio)
            {
                btnChucNang.Text = "Thêm vào giỏ";
            }
            else if (context == CardContext.TrongGioHang)
            {
                btnChucNang.Text = "Xóa vào giỏ";
            }
        }

        public void SetData(string maSP, string tenSP, int giaTien, int SoLuongton)
        {
            lblMaSanPham.Text = maSP;
            lblTenSanPham.Text = tenSP;
            lblGiaTien.Text = giaTien.ToString();
            lblSoLuongTon.Text = SoLuongton.ToString();
        }

        public int SoLuongTon => int.Parse(lblSoLuongTon.Text);

        public void CapNhatSoLuongTon(int soLuong)
        {
            lblSoLuongTon.Text = soLuong.ToString();
        }

        public int SoLuongMua = 0 ;
        public void CapNhatSoLuongMua(int soLuong)
        {
            SoLuongMua = soLuong;

            lblSoLuongTon.Text = soLuong.ToString();
        }


        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            string maSP = lblMaSanPham.Text;
            ChiTietSP ctsp = new ChiTietSP(maSP);

            ctsp.Show();
        }

        public Action<Card_SanPham_Overview> OnActionClick;

        private void btnChucNang_Click(object sender, EventArgs e)
        {
            OnActionClick(this);
        }


    }
}
