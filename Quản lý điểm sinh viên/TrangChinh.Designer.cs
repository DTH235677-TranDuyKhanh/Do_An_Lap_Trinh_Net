namespace Quản_lý_điểm_sinh_viên
{
    partial class TrangChinh
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuTrangChinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyDiemSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXemDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXemDiemRenLuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDiemRenLuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHocKy = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTrangChinh,
            this.mnuThongTin,
            this.mnuXemDiem,
            this.mnuXemDiemRenLuyen});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuTrangChinh
            // 
            this.mnuTrangChinh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuanLyDiemSinhVien,
            this.mnuThoat});
            this.mnuTrangChinh.Name = "mnuTrangChinh";
            this.mnuTrangChinh.Size = new System.Drawing.Size(99, 26);
            this.mnuTrangChinh.Text = "Trang chính";
            // 
            // mnuQuanLyDiemSinhVien
            // 
            this.mnuQuanLyDiemSinhVien.Name = "mnuQuanLyDiemSinhVien";
            this.mnuQuanLyDiemSinhVien.Size = new System.Drawing.Size(245, 26);
            this.mnuQuanLyDiemSinhVien.Text = "Quản lý điểm sinh viên ";
            this.mnuQuanLyDiemSinhVien.Click += new System.EventHandler(this.mnuQuanLyDiemSinhVien_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(245, 26);
            this.mnuThoat.Text = "Thoát ";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuThongTin
            // 
            this.mnuThongTin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSinhVien,
            this.mnuLop});
            this.mnuThongTin.Name = "mnuThongTin";
            this.mnuThongTin.Size = new System.Drawing.Size(86, 26);
            this.mnuThongTin.Text = "Thông tin";
            // 
            // mnuSinhVien
            // 
            this.mnuSinhVien.Name = "mnuSinhVien";
            this.mnuSinhVien.Size = new System.Drawing.Size(155, 26);
            this.mnuSinhVien.Text = "Sinh viên ";
            this.mnuSinhVien.Click += new System.EventHandler(this.mnuSinhVien_Click);
            // 
            // mnuLop
            // 
            this.mnuLop.Name = "mnuLop";
            this.mnuLop.Size = new System.Drawing.Size(155, 26);
            this.mnuLop.Text = "Lớp";
            this.mnuLop.Click += new System.EventHandler(this.mnuLop_Click);
            // 
            // mnuXemDiem
            // 
            this.mnuXemDiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDiem,
            this.mnuMonHoc});
            this.mnuXemDiem.Name = "mnuXemDiem";
            this.mnuXemDiem.Size = new System.Drawing.Size(91, 26);
            this.mnuXemDiem.Text = "Xem điểm";
            // 
            // mnuDiem
            // 
            this.mnuDiem.Name = "mnuDiem";
            this.mnuDiem.Size = new System.Drawing.Size(154, 26);
            this.mnuDiem.Text = "Điểm ";
            this.mnuDiem.Click += new System.EventHandler(this.mnuDiem_Click);
            // 
            // mnuMonHoc
            // 
            this.mnuMonHoc.Name = "mnuMonHoc";
            this.mnuMonHoc.Size = new System.Drawing.Size(154, 26);
            this.mnuMonHoc.Text = "Môn học ";
            this.mnuMonHoc.Click += new System.EventHandler(this.mnuMonHoc_Click);
            // 
            // mnuXemDiemRenLuyen
            // 
            this.mnuXemDiemRenLuyen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDiemRenLuyen,
            this.mnuHocKy});
            this.mnuXemDiemRenLuyen.Name = "mnuXemDiemRenLuyen";
            this.mnuXemDiemRenLuyen.Size = new System.Drawing.Size(159, 26);
            this.mnuXemDiemRenLuyen.Text = "Xem điểm rèn luyện ";
            // 
            // mnuDiemRenLuyen
            // 
            this.mnuDiemRenLuyen.Name = "mnuDiemRenLuyen";
            this.mnuDiemRenLuyen.Size = new System.Drawing.Size(192, 26);
            this.mnuDiemRenLuyen.Text = "Điểm rèn luyện";
            this.mnuDiemRenLuyen.Click += new System.EventHandler(this.mnuDiemRenLuyen_Click);
            // 
            // mnuHocKy
            // 
            this.mnuHocKy.Name = "mnuHocKy";
            this.mnuHocKy.Size = new System.Drawing.Size(192, 26);
            this.mnuHocKy.Text = "Học kỳ ";
            this.mnuHocKy.Click += new System.EventHandler(this.mnuHocKy_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(125, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(650, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chương trình quản lý điểm sinh viên ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrangChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Quản_lý_điểm_sinh_viên.Properties.Resources.ảnh_nền;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 535);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TrangChinh";
            this.Text = "Chương trình quản lý điểm sinh viên ";
            this.Load += new System.EventHandler(this.TrangChinh_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuTrangChinh;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLyDiemSinhVien;
        private System.Windows.Forms.ToolStripMenuItem mnuThongTin;
        private System.Windows.Forms.ToolStripMenuItem mnuSinhVien;
        private System.Windows.Forms.ToolStripMenuItem mnuLop;
        private System.Windows.Forms.ToolStripMenuItem mnuXemDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuMonHoc;
        private System.Windows.Forms.ToolStripMenuItem mnuXemDiemRenLuyen;
        private System.Windows.Forms.ToolStripMenuItem mnuDiemRenLuyen;
        private System.Windows.Forms.ToolStripMenuItem mnuHocKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
    }
}

