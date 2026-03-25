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
using System.IO;

namespace QlCuaHangXimenT.QuanLySanPham.SanPham.PopUp
{
    public partial class card_SanPham : UserControl
    {
       
        public card_SanPham()
        {
            InitializeComponent();         
        }

        public void SetData(string maSP, string tenSP, int gia, string hinhAnh)
        {
            lblMaSanPham.Text = maSP;
            lblTenSanPham.Text = tenSP;

            decimal giaTien = Convert.ToInt32(gia);
            lblGia.Text = giaTien.ToString("N0") + "VNĐ";

            if(hinhAnh == null)
            {
                ptbHinhAnh.Image = Resources.noImg;
            }
            else
            {
                string pathAnh = hinhAnh;

                string fullPath = Path.Combine(Application.StartupPath, pathAnh);

                if (File.Exists(fullPath))
                {
                    ptbHinhAnh.Image = Image.FromFile(fullPath);
                    ptbHinhAnh.Tag = pathAnh;
                }
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            ChiTietSP ctsp = new ChiTietSP(lblMaSanPham.Text);

            ctsp.ShowDialog();

            //if(ctsp.ShowDialog() == DialogResult.OK)
            //{
            //    SetData(, tenSP);
            //}
          
        }
    }
}
