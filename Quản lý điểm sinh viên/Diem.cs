//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_điểm_sinh_viên
{
    public partial class Diem : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;
        bool themMoi;

        public Diem()
        {
            InitializeComponent();
        }

        private void Diem_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=.;Initial Catalog=QuanLyDiemSinhVien;Integrated Security=True");
            LoadData();
            KhoaDieuKhien(false);
            SetButtonState(true);
        }
        private void LoadData()
        {
            string sql = @"
        SELECT 
            d.MaSV, 
            sv.HoTen, 
            d.MaMH, 
            mh.TenMH, 
            d.MaHK, 
            d.DiemTP, 
            d.DiemThi, 
            ROUND(d.DiemTongKet, 2) AS DiemTongKet
        FROM Diem d
        JOIN SinhVien sv ON d.MaSV = sv.MaSV
        JOIN MonHoc mh ON d.MaMH = mh.MaMH";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvDiem.DataSource = dt;

            // Định dạng hiển thị 2 số thập phân
            dgvDiem.Columns["DiemTP"].DefaultCellStyle.Format = "N2";
            dgvDiem.Columns["DiemThi"].DefaultCellStyle.Format = "N2";
            dgvDiem.Columns["DiemTongKet"].DefaultCellStyle.Format = "N2";
        }

        private void KhoaDieuKhien(bool mo)
        {
            txtMSSV.Enabled = mo;
            cbbMonHoc.Enabled = mo;
            cbbHocKy.Enabled = mo;
            txtDiemTP.Enabled = mo;
            txtDiemThi.Enabled = mo;

            btnLuu.Enabled = mo;
            btnHuy.Enabled = mo;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            themMoi = true;
            SetButtonState(false);
            KhoaDieuKhien(true);
            txtMSSV.Clear();
            txtDiemTP.Clear();
            txtDiemThi.Clear();
            txtMSSV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow != null)
            {
                themMoi = false;
                SetButtonState(false);
                KhoaDieuKhien(true);
                txtMSSV.Text = dgvDiem.CurrentRow.Cells["MaSV"].Value.ToString();
                cbbMonHoc.Text = dgvDiem.CurrentRow.Cells["MaMH"].Value.ToString();
                cbbHocKy.Text = dgvDiem.CurrentRow.Cells["MaHK"].Value.ToString();
                txtDiemTP.Text = dgvDiem.CurrentRow.Cells["DiemTP"].Value.ToString();
                txtDiemThi.Text = dgvDiem.CurrentRow.Cells["DiemThi"].Value.ToString();
                txtMSSV.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow != null)
            {
                string maSV = dgvDiem.CurrentRow.Cells["MaSV"].Value.ToString();
                string maMH = dgvDiem.CurrentRow.Cells["MaMH"].Value.ToString();
                string maHK = dgvDiem.CurrentRow.Cells["MaHK"].Value.ToString();

                if (MessageBox.Show("Bạn có chắc muốn xóa điểm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Diem WHERE MaSV=@MaSV AND MaMH=@MaMH AND MaHK=@MaHK", conn);
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    cmd.Parameters.AddWithValue("@MaMH", maMH);
                    cmd.Parameters.AddWithValue("@MaHK", maHK);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LoadData();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = txtMSSV.Text.Trim();
                string maMH = cbbMonHoc.Text.Trim();
                string maHK = cbbHocKy.Text.Trim();
                float diemTP = float.Parse(txtDiemTP.Text);
                float diemThi = float.Parse(txtDiemThi.Text);

                // ✅ Tính điểm tổng kết để hiển thị (chứ không lưu vào DB)
                float diemTongKet = (float)Math.Round(diemTP * 0.3 + diemThi * 0.7, 2);

                conn.Open();
                SqlCommand cmd;

                if (themMoi)
                {
                    // ✅ Bỏ DiemTongKet khỏi câu lệnh INSERT
                    cmd = new SqlCommand(@"
                INSERT INTO Diem (MaSV, MaMH, MaHK, DiemTP, DiemThi)
                VALUES (@MaSV, @MaMH, @MaHK, @DiemTP, @DiemThi)", conn);
                }
                else
                {
                    // ✅ Bỏ DiemTongKet khỏi câu lệnh UPDATE
                    cmd = new SqlCommand(@"
                UPDATE Diem 
                SET DiemTP = @DiemTP, DiemThi = @DiemThi
                WHERE MaSV = @MaSV AND MaMH = @MaMH AND MaHK = @MaHK", conn);
                }

                // Gán tham số
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaMH", maMH);
                cmd.Parameters.AddWithValue("@MaHK", maHK);
                cmd.Parameters.AddWithValue("@DiemTP", diemTP);
                cmd.Parameters.AddWithValue("@DiemThi", diemThi);

                cmd.ExecuteNonQuery();
                conn.Close();

                // Load lại dữ liệu để hiển thị
                LoadData();
                SetButtonState(true);
                KhoaDieuKhien(false);

                // ✅ Hiển thị điểm tổng kết tính tạm cho người dùng
                MessageBox.Show("Lưu thành công!\nĐiểm tổng kết: " + diemTongKet.ToString("0.00"), "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message);
                conn.Close();
            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetButtonState(true);
            KhoaDieuKhien(false);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetButtonState(bool enable)
        {
            btnThem.Enabled = enable;
            btnXoa.Enabled = enable;
            btnSua.Enabled = enable;
            btnLuu.Enabled = !enable;
            btnHuy.Enabled = !enable;
        }
    }
}
