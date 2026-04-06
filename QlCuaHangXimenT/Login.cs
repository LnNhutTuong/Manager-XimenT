using BUS.Auth;
using DTO;
using DTO.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT
{
    public partial class Login : Form
    {

        public NguoiDung_DTO NguoiDungHienTai { get; private set; }

        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string mess;

            NguoiDung_DTO user = Auth_BUS.DangNhap(tenDangNhap, matKhau, out mess);

            if (user != null)
            {
                this.NguoiDungHienTai = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mess, "Thông báo lỗi!");
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string tenDangNhap = txtTenDangNhap.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();
                string mess;

                NguoiDung_DTO user = Auth_BUS.DangNhap(tenDangNhap, matKhau, out mess);

                if (user != null)
                {
                    this.NguoiDungHienTai = user;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(mess, "Thông báo lỗi!");
                }
            }
        }

        private void txtMatKhau_IconRightClick(object sender, EventArgs e)
        {
            if (txtMatKhau.UseSystemPasswordChar)
            {
                // Hiện mật khẩu
                txtMatKhau.UseSystemPasswordChar = false;
                txtMatKhau.PasswordChar = '\0';
                txtMatKhau.IconRight = Properties.Resources.view;
            }
            else
            {
                // Ẩn mật khẩu
                txtMatKhau.UseSystemPasswordChar = true;
                txtMatKhau.PasswordChar = '*';
                txtMatKhau.IconRight = Properties.Resources.hide;
            }
        }

        #region 100% AI
        float swingTimer = 0;
        int loadPercent = 0;

        private async void Login_Shown(object sender, EventArgs e)
        {
            pnlSplash.BringToFront();
            pnlSplash.Visible = true;

            // Bật cái timer bạn kéo từ Toolbox vào (nhớ chỉnh Interval là 30 trong Properties)
            timer1.Start();

            var progress = new Progress<int>(percent =>
            {
                loadPercent = percent;
                lblStatus.Text = $"XimenT đang khởi tạo... {percent}%";
                // Không cần Invalidate ở đây vì timer1 đã làm rồi
            });

            await Task.Run(() => LoadRealData(progress));

            while (loadPercent < 100) await Task.Delay(100);

            timer1.Stop();
            pnlSplash.Visible = false;
        }


        private string LoadRealData(IProgress<int> progress)
        {
            int steps = 50;
            for (int i = 1; i <= steps; i++)
            {
                // 100ms * 50 bước = 5000ms = 5 giây
                Thread.Sleep(100);

                int percent = (i * 100) / steps;
                progress.Report(percent);
            }

            return "Dữ liệu đã sẵn sàng";
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            swingTimer += 0.12f; // Tốc độ lắc, chỉnh số này nếu muốn lắc nhanh/chậm hơn
            picLoader.Invalidate();
        }

        private void picLoader_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Dùng bút màu Đen (hoặc xám đậm) để hiện rõ trên nền trắng
            Pen darkPen = new Pen(Color.FromArgb(200, Color.Black), 2);
            int margin = 20;
            Rectangle rect = new Rectangle(margin, margin, picLoader.Width - margin * 2, picLoader.Height - margin * 2);

            // 1. Vẽ vòng tròn tĩnh mờ phía sau
            e.Graphics.DrawEllipse(new Pen(Color.FromArgb(30, Color.Black), 1), rect);

            // 2. Vẽ cung tròn loading chạy theo %
            float sweepAngle = (loadPercent * 360) / 100f;
            e.Graphics.DrawArc(darkPen, rect, -90, sweepAngle);

            // 3. Vẽ Logo Lắc qua lại
            Image logo = Properties.Resources.Adobe_Express___file;
            if (logo != null)
            {
                var state = e.Graphics.Save();
                e.Graphics.TranslateTransform(picLoader.Width / 2, picLoader.Height / 2);

                // Công thức lắc mượt: Sin(biến) * góc tối đa
                float angle = (float)Math.Sin(swingTimer) * 20; // Lắc biên độ 20 độ
                e.Graphics.RotateTransform(angle);

                int logoSize = 120;
                e.Graphics.DrawImage(logo, -logoSize / 2, -logoSize / 2, logoSize, logoSize);
                e.Graphics.Restore(state);
            }
        }
    }
}
