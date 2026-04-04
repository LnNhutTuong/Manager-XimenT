namespace QlCuaHangXimenT.ThongKe
{
    partial class UC_ThongKe
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.tcThongKe = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabTongHop = new System.Windows.Forms.TabPage();
            this.tabSanPham = new System.Windows.Forms.TabPage();
            this.tabDoanhThu = new System.Windows.Forms.TabPage();
            this.guna2Panel5.SuspendLayout();
            this.tcThongKe.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 40);
            this.label1.TabIndex = 158;
            this.label1.Text = "Thống kê";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(40, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 159;
            this.label2.Text = "Thống kê và báo cáo doanh thu";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(183, 14);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 19);
            this.label8.TabIndex = 182;
            this.label8.Text = "Ngày kết thúc";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(5, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 19);
            this.label7.TabIndex = 181;
            this.label7.Text = "Ngày bắt đầu:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd-MM-yyyy";
            this.dtpDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(186, 28);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(151, 23);
            this.dtpDenNgay.TabIndex = 184;
            this.dtpDenNgay.ValueChanged += new System.EventHandler(this.dtpTuNgay_ValueChanged);
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd-MM-yyyy";
            this.dtpTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(8, 28);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(151, 23);
            this.dtpTuNgay.TabIndex = 183;
            this.dtpTuNgay.Value = new System.DateTime(2022, 2, 22, 0, 0, 0, 0);
            this.dtpTuNgay.ValueChanged += new System.EventHandler(this.dtpTuNgay_ValueChanged);
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2Panel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel5.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel5.BorderRadius = 15;
            this.guna2Panel5.BorderThickness = 1;
            this.guna2Panel5.Controls.Add(this.label8);
            this.guna2Panel5.Controls.Add(this.label7);
            this.guna2Panel5.Controls.Add(this.dtpDenNgay);
            this.guna2Panel5.Controls.Add(this.dtpTuNgay);
            this.guna2Panel5.FillColor = System.Drawing.Color.Transparent;
            this.guna2Panel5.Location = new System.Drawing.Point(599, 24);
            this.guna2Panel5.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(341, 61);
            this.guna2Panel5.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(596, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 19);
            this.label3.TabIndex = 185;
            this.label3.Text = "Lọc dữ liệu:";
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Black;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(797, 90);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(144, 31);
            this.guna2Button1.TabIndex = 186;
            this.guna2Button1.Text = "Xuất báo cáo";
            // 
            // tcThongKe
            // 
            this.tcThongKe.Controls.Add(this.tabTongHop);
            this.tcThongKe.Controls.Add(this.tabSanPham);
            this.tcThongKe.Controls.Add(this.tabDoanhThu);
            this.tcThongKe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcThongKe.ItemSize = new System.Drawing.Size(180, 50);
            this.tcThongKe.Location = new System.Drawing.Point(0, 126);
            this.tcThongKe.Margin = new System.Windows.Forms.Padding(2);
            this.tcThongKe.Name = "tcThongKe";
            this.tcThongKe.SelectedIndex = 0;
            this.tcThongKe.Size = new System.Drawing.Size(983, 510);
            this.tcThongKe.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tcThongKe.TabButtonHoverState.FillColor = System.Drawing.Color.White;
            this.tcThongKe.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcThongKe.TabButtonHoverState.ForeColor = System.Drawing.Color.Black;
            this.tcThongKe.TabButtonHoverState.InnerColor = System.Drawing.Color.Black;
            this.tcThongKe.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tcThongKe.TabButtonIdleState.FillColor = System.Drawing.Color.Black;
            this.tcThongKe.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcThongKe.TabButtonIdleState.ForeColor = System.Drawing.Color.White;
            this.tcThongKe.TabButtonIdleState.InnerColor = System.Drawing.Color.White;
            this.tcThongKe.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tcThongKe.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
            this.tcThongKe.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcThongKe.TabButtonSelectedState.ForeColor = System.Drawing.Color.Black;
            this.tcThongKe.TabButtonSelectedState.InnerColor = System.Drawing.Color.Black;
            this.tcThongKe.TabButtonSize = new System.Drawing.Size(180, 50);
            this.tcThongKe.TabIndex = 189;
            this.tcThongKe.TabMenuBackColor = System.Drawing.Color.Black;
            this.tcThongKe.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabTongHop
            // 
            this.tabTongHop.ForeColor = System.Drawing.Color.White;
            this.tabTongHop.Location = new System.Drawing.Point(4, 54);
            this.tabTongHop.Margin = new System.Windows.Forms.Padding(2);
            this.tabTongHop.Name = "tabTongHop";
            this.tabTongHop.Padding = new System.Windows.Forms.Padding(2);
            this.tabTongHop.Size = new System.Drawing.Size(975, 452);
            this.tabTongHop.TabIndex = 0;
            this.tabTongHop.Text = "Tổng hợp";
            this.tabTongHop.UseVisualStyleBackColor = true;
            // 
            // tabSanPham
            // 
            this.tabSanPham.Location = new System.Drawing.Point(4, 54);
            this.tabSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.tabSanPham.Name = "tabSanPham";
            this.tabSanPham.Padding = new System.Windows.Forms.Padding(2);
            this.tabSanPham.Size = new System.Drawing.Size(975, 452);
            this.tabSanPham.TabIndex = 1;
            this.tabSanPham.Text = "Thông kế Sản phẩm";
            this.tabSanPham.UseVisualStyleBackColor = true;
            // 
            // tabDoanhThu
            // 
            this.tabDoanhThu.Location = new System.Drawing.Point(4, 54);
            this.tabDoanhThu.Margin = new System.Windows.Forms.Padding(2);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Padding = new System.Windows.Forms.Padding(2);
            this.tabDoanhThu.Size = new System.Drawing.Size(975, 452);
            this.tabDoanhThu.TabIndex = 2;
            this.tabDoanhThu.Text = "Thống kê Doanh thu";
            this.tabDoanhThu.UseVisualStyleBackColor = true;
            // 
            // UC_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tcThongKe);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Panel5);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UC_ThongKe";
            this.Size = new System.Drawing.Size(983, 636);
            this.Load += new System.EventHandler(this.UC_ThongKe_Load);
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel5.PerformLayout();
            this.tcThongKe.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TabControl tcThongKe;
        private System.Windows.Forms.TabPage tabSanPham;
        private System.Windows.Forms.TabPage tabTongHop;
        private System.Windows.Forms.TabPage tabDoanhThu;
    }
}
