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
using QlCuaHangXimenT.Common.Enums;

namespace QlCuaHangXimenT.QuanLySanPham.SanPham.PopUp
{
    public partial class card_SanPham : UserControl
    {
        public CardMode CurrentMode;

        public void SetMode(CardMode mode)
        {
            CurrentMode = mode;

            bool isSelected = (mode == CardMode.Selected);

            if (isSelected)
            {
                borderCard.BorderColor = Color.FromArgb(67, 243, 70);
                borderCard.BorderThickness = 2;

            }
            else
            {
                borderCard.BorderColor = Color.Black;
                borderCard.BorderThickness = 2  ;

            }

        }

        public card_SanPham()
        {
            InitializeComponent();
            SetMode(CardMode.NoSelected);

            //Cái này rất hay, lick đâu cũng dính (Cảm ơn skibidi)
            foreach (Control c in this.Controls)
            {
                c.Click += (s, e) => this.OnClick(e);
            }
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
                    #region chạm thôi không nắm
                    byte[] imageByte = File.ReadAllBytes(fullPath);

                    using (MemoryStream ms = new MemoryStream(imageByte))
                    {

                        ptbHinhAnh.Image = Image.FromStream(ms);
                    }
                    #endregion
                }
            }
        }

        public Action added;

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            ChiTietSP ctsp = new ChiTietSP(lblMaSanPham.Text);

            //ctsp.ShowDialog();

            if (ctsp.ShowDialog() == DialogResult.OK)
            {
                added.Invoke();
            }

        }

        //Dùng prop
        public string MaSP => lblMaSanPham.Text;

        private void card_SanPham_Click(object sender, EventArgs e)
        {
            if(this.CurrentMode == CardMode.Selected)
            {
                SetMode(CardMode.NoSelected);
            }
            else
            {
                SetMode(CardMode.Selected);
            }
        }

      
    }
}
