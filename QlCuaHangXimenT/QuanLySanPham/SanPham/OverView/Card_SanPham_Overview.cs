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

namespace QlCuaHangXimenT.QuanLySanPham.SanPham.OverView
{
    public partial class Card_SanPham_Overview : UserControl
    {
        public string maSP;
        public string tenSP;
        public int giaTien;
        public int SoLuongton;

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
                btnChucNang.Image = Resources.ecommerce__1_;
                label2.Text = "Còn tồn:";
            }
            else if (context == CardContext.TrongGioHang)
            {
                btnChucNang.Image = Resources.ecommerce;
                label2.Text = "Số lượng:";
            }
        }

        public FormMode CurrentMode;
        public void SetMode(FormMode mode)
        {
            CurrentMode = mode;

            if(mode == FormMode.View)
            {
                btnChucNang.Visible = false;
            }
            else if (mode == FormMode.Edit)
            {
                btnChucNang.Visible = true;
            }
        }
    
        public void SetData(string maSP, string tenSP, int giaTien, int SoLuongton)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.giaTien = giaTien;
            this.SoLuongton = SoLuongton;

            lblMaSanPham.Text = maSP;
            lblTenSanPham.Text = tenSP;
            lblGiaTien.Text = giaTien.ToString("N0") + "VNĐ";
            lblSoLuongTon.Text = SoLuongton.ToString();
        }

        #region chưa vào giỏ
        public int SoLuongTon => int.Parse(lblSoLuongTon.Text);
        public void CapNhatSoLuongTon(int soLuong)
        {
            lblSoLuongTon.Text = soLuong.ToString();
        }
        #endregion

        #region vào giỏ
        public int SoLuongMua = 0 ;
        public void CapNhatSoLuongMua(int soLuong)
        {
            SoLuongMua = soLuong;
            lblSoLuongTon.Text = soLuong.ToString();
            decimal thanhTien = (decimal)SoLuongMua * giaTien;
            lblGiaTien.Text = thanhTien.ToString("N0") + " VNĐ";
        }
        #endregion

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
