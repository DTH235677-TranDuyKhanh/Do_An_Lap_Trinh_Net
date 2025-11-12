namespace Quản_lý_điểm_sinh_viên
{
    partial class QuanLyDiemSinhVien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnTaiDanhSach = new System.Windows.Forms.Button();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvQuanLyDiemRenLuyen = new System.Windows.Forms.DataGridView();
            this.cbbMaHocKy = new System.Windows.Forms.ComboBox();
            this.cbbTenMonHoc = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyDiemRenLuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 16);
            this.label8.TabIndex = 39;
            this.label8.Text = "Danh sách sinh viên: ";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(157, 95);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(109, 37);
            this.btnDong.TabIndex = 20;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(20, 95);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(109, 37);
            this.btnHuy.TabIndex = 19;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Controls.Add(this.btnTaiDanhSach);
            this.groupBox1.Controls.Add(this.btnHuy);
            this.groupBox1.Location = new System.Drawing.Point(513, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 163);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(20, 38);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(109, 37);
            this.btnTimKiem.TabIndex = 21;
            this.btnTimKiem.Text = "Tìm kiếm ";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnTaiDanhSach
            // 
            this.btnTaiDanhSach.Location = new System.Drawing.Point(157, 38);
            this.btnTaiDanhSach.Name = "btnTaiDanhSach";
            this.btnTaiDanhSach.Size = new System.Drawing.Size(109, 37);
            this.btnTaiDanhSach.TabIndex = 16;
            this.btnTaiDanhSach.Text = "Tải danh sách ";
            this.btnTaiDanhSach.UseVisualStyleBackColor = true;
            this.btnTaiDanhSach.Click += new System.EventHandler(this.btnTaiDanhSach_Click);
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(198, 144);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(237, 23);
            this.txtMSSV.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(287, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 26);
            this.label3.TabIndex = 25;
            this.label3.Text = "QUẢN LÝ ĐIỂM SINH VIÊN ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Mã số sinh viên: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Tên môn học: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 40;
            this.label5.Text = "Mã học kỳ: ";
            // 
            // dgvQuanLyDiemRenLuyen
            // 
            this.dgvQuanLyDiemRenLuyen.AllowUserToAddRows = false;
            this.dgvQuanLyDiemRenLuyen.AllowUserToDeleteRows = false;
            this.dgvQuanLyDiemRenLuyen.AllowUserToResizeRows = false;
            this.dgvQuanLyDiemRenLuyen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuanLyDiemRenLuyen.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuanLyDiemRenLuyen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuanLyDiemRenLuyen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuanLyDiemRenLuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuanLyDiemRenLuyen.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQuanLyDiemRenLuyen.EnableHeadersVisualStyles = false;
            this.dgvQuanLyDiemRenLuyen.GridColor = System.Drawing.Color.Gray;
            this.dgvQuanLyDiemRenLuyen.Location = new System.Drawing.Point(43, 333);
            this.dgvQuanLyDiemRenLuyen.MultiSelect = false;
            this.dgvQuanLyDiemRenLuyen.Name = "dgvQuanLyDiemRenLuyen";
            this.dgvQuanLyDiemRenLuyen.ReadOnly = true;
            this.dgvQuanLyDiemRenLuyen.RowHeadersWidth = 51;
            this.dgvQuanLyDiemRenLuyen.RowTemplate.Height = 24;
            this.dgvQuanLyDiemRenLuyen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuanLyDiemRenLuyen.Size = new System.Drawing.Size(802, 177);
            this.dgvQuanLyDiemRenLuyen.TabIndex = 44;
            this.dgvQuanLyDiemRenLuyen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuanLyDiemRenLuyen_CellContentClick);
            // 
            // cbbMaHocKy
            // 
            this.cbbMaHocKy.FormattingEnabled = true;
            this.cbbMaHocKy.Location = new System.Drawing.Point(198, 250);
            this.cbbMaHocKy.Name = "cbbMaHocKy";
            this.cbbMaHocKy.Size = new System.Drawing.Size(237, 24);
            this.cbbMaHocKy.TabIndex = 45;
            // 
            // cbbTenMonHoc
            // 
            this.cbbTenMonHoc.FormattingEnabled = true;
            this.cbbTenMonHoc.Location = new System.Drawing.Point(198, 200);
            this.cbbTenMonHoc.Name = "cbbTenMonHoc";
            this.cbbTenMonHoc.Size = new System.Drawing.Size(237, 24);
            this.cbbTenMonHoc.TabIndex = 46;
            // 
            // QuanLyDiemSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(900, 534);
            this.Controls.Add(this.cbbTenMonHoc);
            this.Controls.Add(this.cbbMaHocKy);
            this.Controls.Add(this.dgvQuanLyDiemRenLuyen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QuanLyDiemSinhVien";
            this.Text = "Quản lý điểm sinh viên ";
            this.Load += new System.EventHandler(this.QuanLyDiemSinhVien_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyDiemRenLuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTaiDanhSach;
        private System.Windows.Forms.DataGridView dgvQuanLyDiemRenLuyen;
        private System.Windows.Forms.ComboBox cbbMaHocKy;
        private System.Windows.Forms.ComboBox cbbTenMonHoc;
    }
}