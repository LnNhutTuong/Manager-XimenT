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
        public void LayDuLieu()
        {
            DataTable dsSanPham = SanPham_BUS.DanhSachSanPham();

            if (dsSanPham.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSanPham.Rows)
                {

                    Card_SanPham_Overview cardTren = new Card_SanPham_Overview();
                    cardTren.SetData(dr["MaSP"].ToString(), dr["TenSP"].ToString(), Convert.ToInt32(dr["Gia"]), Convert.ToInt32(dr["SoLuongTon"]));
                    cardTren.SetContext(CardContext.ChuaVaoGio);

                    Card_SanPham_Overview cardDuoi = new Card_SanPham_Overview();
                    cardDuoi.SetData(dr["MaSP"].ToString(), dr["TenSP"].ToString(), Convert.ToInt32(dr["Gia"]), 1);
                    cardDuoi.SetContext(CardContext.TrongGioHang);
                    cardDuoi.Visible = false; //ẩn

                    #region thêm vào giỏ
                    cardTren.OnActionClick = (c) => {
                        if (cardTren.SoLuongTon > 0)
                        {
                            cardTren.CapNhatSoLuongTon(cardTren.SoLuongTon - 1);

                            if(cardDuoi.Visible == false)
                            {
                                cardDuoi.CapNhatSoLuongMua(1);
                                cardDuoi.Visible = true;// hiện
                            }
                            else
                            {
                                int them = cardDuoi.SoLuongMua + 1;
                                cardDuoi.CapNhatSoLuongMua(them);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm đã hết hàng");
                        }
                    };
                    #endregion

                    #region xóa khỏi giỏi
                    cardDuoi.OnActionClick = (c) => {
                       if(cardDuoi.SoLuongMua > 0)
                        {
                            cardTren.CapNhatSoLuongTon(cardTren.SoLuongTon + 1);

                            int soLuongMuaMoi = cardDuoi.SoLuongMua - 1;

                            cardDuoi.CapNhatSoLuongMua(soLuongMuaMoi);

                            if (soLuongMuaMoi == 0)
                            {
                                cardDuoi.Visible = false;
                            }
                        }
                    };
                    #endregion

                    flpDanhSachSanPham.Controls.Add(cardTren);
                    flpGioHang.Controls.Add(cardDuoi);
                }

            }
        }


        //public void ChuyenCard(Card_SanPham_Overview card)
        //{
        //    if(card.CurrentContext == CardContext.ChuaVaoGio)
        //    {
        //        if(card.SoLuongTon > 0)
        //        {
        //            card.CapNhatSoLuongTon(card.SoLuongTon - 1);

        //            card.SetContext(CardContext.TrongGioHang);

        //            flpGioHang.Controls.Add(card);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Sản phẩm đã hết hàng");
        //        }
        //    }
        //    else if (card.CurrentContext == CardContext.TrongGioHang)
        //    {
        //        card.CapNhatSoLuongTon(card.SoLuongTon + 1);

        //        card.SetContext(CardContext.ChuaVaoGio);

        //        flpDanhSachSanPham.Controls.Add(card);
        //    }
        //}
        public ThemDH()
        {
            InitializeComponent();
            LayDuLieu();
        }

       
    }
}
