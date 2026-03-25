using BUS.QuanLySanPham;
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
        public UC_SanPham()
        {
            InitializeComponent();
            LayDuLieu();
        }

        public void LayDuLieu()
        {
            string message;
            DataTable dsSanPham = SanPham_BUS.DanhSachSanPham();
            if (dsSanPham.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSanPham.Rows)
                {
                    card_SanPham sanpham = new card_SanPham();                   

                    sanpham.SetData(dr["MaSP"].ToString(), dr["TenSP"].ToString(), Convert.ToInt32(dr["Gia"]), dr["HinhAnh"].ToString());

                    flpSanPham.Controls.Add(sanpham);
                }
            }

            lblSoLuongSanPham.Text = dsSanPham.Rows.Count.ToString();


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSP them = new ThemSP();
            
            if(them.ShowDialog() == DialogResult.OK)
            {
                LayDuLieu();
            }
        }
    }
}
