using BUS.QuanLySanPham;
using QlCuaHangXimenT.Common.Enums;
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
            flpSanPham.Controls.Clear();

            string message;
            DataTable dsSanPham = SanPham_BUS.DanhSachSanPham();
            if (dsSanPham.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSanPham.Rows)
                {
                    card_SanPham sanpham = new card_SanPham();                   

                    sanpham.SetData(dr["MaSP"].ToString(), dr["TenSP"].ToString(), Convert.ToInt32(dr["Gia"]), dr["HinhAnh"].ToString());


                    sanpham.added = () =>
                    {
                        LayDuLieu();
                    };

                    flpSanPham.Controls.Add(sanpham);
                }
            }

            lblSoLuongSanPham.Text = dsSanPham.Rows.Count.ToString();


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSP them = new ThemSP();
            if (them.ShowDialog() == DialogResult.OK)
            {
                flpSanPham.Controls.Clear();
                LayDuLieu();
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
                        flpSanPham.Controls.Clear();
                        LayDuLieu();
                        MessageBox.Show("Xóa thành công");
                    }
                }
                       
            }
        }

        #endregion 
    }
}
