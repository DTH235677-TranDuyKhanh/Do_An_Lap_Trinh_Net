using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quản_lý_điểm_sinh_viên
{
    public partial class QuanLyDiemSinhVien : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;

        string connectionString = @"Data Source=.;Initial Catalog=QuanLyDiemSinhVien;Integrated Security=True";

        public QuanLyDiemSinhVien()
        {
            InitializeComponent();
        }

        private void QuanLyDiemSinhVien_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            LoadMonHoc();
            LoadHocKy();
            LoadDanhSach();
        }

        // 🔹 Load tên môn học vào combobox
        private void LoadMonHoc()
        {
            string sql = "SELECT MaMH, TenMH FROM MonHoc";
            SqlDataAdapter daMH = new SqlDataAdapter(sql, conn);
            DataTable dtMH = new DataTable();
            daMH.Fill(dtMH);
            cbbTenMonHoc.DataSource = dtMH;
            cbbTenMonHoc.DisplayMember = "TenMH";
            cbbTenMonHoc.ValueMember = "MaMH";
            cbbTenMonHoc.SelectedIndex = -1;
        }

        // 🔹 Load mã học kỳ
        private void LoadHocKy()
        {
            string sql = "SELECT DISTINCT MaHK FROM Diem";
            SqlDataAdapter daHK = new SqlDataAdapter(sql, conn);
            DataTable dtHK = new DataTable();
            daHK.Fill(dtHK);
            cbbMaHocKy.DataSource = dtHK;
            cbbMaHocKy.DisplayMember = "MaHK";
            cbbMaHocKy.ValueMember = "MaHK";
            cbbMaHocKy.SelectedIndex = -1;
        }

        // 🔹 Load toàn bộ danh sách sinh viên (kể cả chưa có điểm)
        private void LoadDanhSach()
        {
            string sql = @"
                SELECT 
                    sv.MaSV, 
                    sv.HoTen, 
                    ISNULL(mh.TenMH, N'Chưa có môn học') AS TenMH,
                    ISNULL(d.MaHK, N'') AS MaHK,
                    ISNULL(d.DiemTP, 0) AS DiemTP,
                    ISNULL(d.DiemThi, 0) AS DiemThi,
                    ISNULL(ROUND(d.DiemTongKet, 2), 0) AS DiemTongKet
                FROM SinhVien sv
                LEFT JOIN Diem d ON sv.MaSV = d.MaSV
                LEFT JOIN MonHoc mh ON d.MaMH = mh.MaMH";

            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvQuanLyDiemRenLuyen.DataSource = dt;

            dgvQuanLyDiemRenLuyen.Columns["MaSV"].HeaderText = "Mã SV";
            dgvQuanLyDiemRenLuyen.Columns["HoTen"].HeaderText = "Họ tên";
            dgvQuanLyDiemRenLuyen.Columns["TenMH"].HeaderText = "Môn học";
            dgvQuanLyDiemRenLuyen.Columns["MaHK"].HeaderText = "Học kỳ";
            dgvQuanLyDiemRenLuyen.Columns["DiemTP"].HeaderText = "Điểm quá trình";
            dgvQuanLyDiemRenLuyen.Columns["DiemThi"].HeaderText = "Điểm thi";
            dgvQuanLyDiemRenLuyen.Columns["DiemTongKet"].HeaderText = "Điểm tổng kết";
        }

        // 🔍 Nút tìm kiếm sinh viên theo MSSV, môn học, học kỳ
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = @"
                SELECT 
                    sv.MaSV, 
                    sv.HoTen, 
                    ISNULL(mh.TenMH, N'Chưa có môn học') AS TenMH,
                    ISNULL(d.MaHK, N'') AS MaHK,
                    ISNULL(d.DiemTP, 0) AS DiemTP,
                    ISNULL(d.DiemThi, 0) AS DiemThi,
                    ISNULL(ROUND(d.DiemTongKet, 2), 0) AS DiemTongKet
                FROM SinhVien sv
                LEFT JOIN Diem d ON sv.MaSV = d.MaSV
                LEFT JOIN MonHoc mh ON d.MaMH = mh.MaMH
                WHERE 1=1";

            if (!string.IsNullOrEmpty(txtMSSV.Text))
                sql += " AND sv.MaSV LIKE N'%" + txtMSSV.Text + "%'";
            if (cbbTenMonHoc.SelectedIndex != -1)
                sql += " AND d.MaMH = '" + cbbTenMonHoc.SelectedValue + "'";
            if (cbbMaHocKy.SelectedIndex != -1)
                sql += " AND d.MaHK = '" + cbbMaHocKy.SelectedValue + "'";

            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvQuanLyDiemRenLuyen.DataSource = dt;

            if (dt.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp!");
        }

        // 🔁 Tải lại danh sách
        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            LoadDanhSach();
            txtMSSV.Clear();
            cbbTenMonHoc.SelectedIndex = -1;
            cbbMaHocKy.SelectedIndex = -1;
        }

        // 🔄 Hủy tìm kiếm
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            cbbTenMonHoc.SelectedIndex = -1;
            cbbMaHocKy.SelectedIndex = -1;
        }

        // ❌ Đóng form
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvQuanLyDiemRenLuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
