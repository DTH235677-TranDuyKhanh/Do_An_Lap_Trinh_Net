using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quản_lý_điểm_sinh_viên
{
    public partial class Lop : Form
    {
        string connectionString = @"Data Source=.;Initial Catalog=QuanLyDiemSinhVien;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;
        bool themMoi = false;
        public Lop()
        {
            InitializeComponent();
        }

        private void Lop_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();

            LoadKhoa();
            LoadLop();
            SetButton(true);

            KhoaDieuKhien(false);
        }
        private void LoadKhoa()
        {
            string sql = "SELECT MaKhoa, TenKhoa FROM Khoa";
            da = new SqlDataAdapter(sql, conn);
            DataTable dtKhoa = new DataTable();
            da.Fill(dtKhoa);

            cbbKhoa.DataSource = dtKhoa;
            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "MaKhoa";
        }

        // Load dữ liệu Lớp vào DataGridView
        private void LoadLop()
        {
            string sql = "SELECT Lop.MaLop, Lop.TenLop, Khoa.TenKhoa FROM Lop INNER JOIN Khoa ON Lop.MaKhoa = Khoa.MaKhoa";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvLop.DataSource = dt;

            dgvLop.Columns[0].HeaderText = "Mã lớp";
            dgvLop.Columns[1].HeaderText = "Tên lớp";
            dgvLop.Columns[2].HeaderText = "Khoa";
        }

        private void SetButton(bool enable)
        {
            btnThem.Enabled = enable;
            btnXoa.Enabled = enable;
            btnSua.Enabled = enable;
            btnLuu.Enabled = !enable;
            btnHuy.Enabled = !enable;
        }
        // 🔹 Khóa/Mở các ô nhập liệu
        private void KhoaDieuKhien(bool mo)
        {
            txtML.Enabled = mo;
            txtTenLop.Enabled = mo;
            cbbKhoa.Enabled = mo;
        }
        // Nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            themMoi = true;
            txtML.Clear();
            txtTenLop.Clear();
            cbbKhoa.SelectedIndex = 0;

            KhoaDieuKhien(true);
            txtML.Focus();
            SetButton(false);
        }
        // Nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtML.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa!");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Bạn có chắc muốn xóa lớp này? (Tất cả sinh viên và điểm của họ cũng sẽ bị xóa)",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                string maLop = txtML.Text.Trim();

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // 1️⃣ Xóa điểm rèn luyện của sinh viên thuộc lớp
                        string sqlXoaDiemRL = @"
                    DELETE FROM DiemRenLuyen
                    WHERE MaSV IN (SELECT MaSV FROM SinhVien WHERE MaLop = @MaLop)";
                        using (SqlCommand cmdDRL = new SqlCommand(sqlXoaDiemRL, conn))
                        {
                            cmdDRL.Parameters.AddWithValue("@MaLop", maLop);
                            cmdDRL.ExecuteNonQuery();
                        }

                        // 2️⃣ Xóa điểm học tập của sinh viên
                        string sqlXoaDiem = @"
                    DELETE FROM Diem
                    WHERE MaSV IN (SELECT MaSV FROM SinhVien WHERE MaLop = @MaLop)";
                        using (SqlCommand cmdDiem = new SqlCommand(sqlXoaDiem, conn))
                        {
                            cmdDiem.Parameters.AddWithValue("@MaLop", maLop);
                            cmdDiem.ExecuteNonQuery();
                        }

                        // 3️⃣ Xóa sinh viên thuộc lớp
                        string sqlXoaSV = "DELETE FROM SinhVien WHERE MaLop=@MaLop";
                        using (SqlCommand cmdSV = new SqlCommand(sqlXoaSV, conn))
                        {
                            cmdSV.Parameters.AddWithValue("@MaLop", maLop);
                            cmdSV.ExecuteNonQuery();
                        }

                        // 4️⃣ Xóa lớp
                        string sqlXoaLop = "DELETE FROM Lop WHERE MaLop=@MaLop";
                        using (SqlCommand cmdLop = new SqlCommand(sqlXoaLop, conn))
                        {
                            cmdLop.Parameters.AddWithValue("@MaLop", maLop);
                            cmdLop.ExecuteNonQuery();
                        }

                        MessageBox.Show("Đã xóa lớp, sinh viên và điểm liên quan thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }

                LoadLop();
            }
        }




        // Nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLop.CurrentRow == null) return;

            themMoi = false;
            txtML.Text = dgvLop.CurrentRow.Cells["MaLop"].Value.ToString();
            txtTenLop.Text = dgvLop.CurrentRow.Cells["TenLop"].Value.ToString();
            cbbKhoa.Text = dgvLop.CurrentRow.Cells["TenKhoa"].Value.ToString();

            txtML.Enabled = false;
            KhoaDieuKhien(true);
            SetButton(false);
        }
        // Nút Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maLop = txtML.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            string maKhoa = cbbKhoa.SelectedValue.ToString();

            if (maLop == "" || tenLop == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }

            SqlCommand cmd;
            if (themMoi)
            {
                // 🟢 Thêm mới lớp
                string sqlInsert = "INSERT INTO Lop (MaLop, TenLop, MaKhoa) VALUES (@MaLop, @TenLop, @MaKhoa)";
                cmd = new SqlCommand(sqlInsert, conn);
                cmd.Parameters.AddWithValue("@MaLop", maLop);
                cmd.Parameters.AddWithValue("@TenLop", tenLop);
                cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm lớp thành công!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi thêm lớp: " + ex.Message);
                }
            }
            else
            {
                // 🟡 Cập nhật lớp
                string sqlUpdate = "UPDATE Lop SET TenLop=@TenLop, MaKhoa=@MaKhoa WHERE MaLop=@MaLop";
                cmd = new SqlCommand(sqlUpdate, conn);
                cmd.Parameters.AddWithValue("@MaLop", maLop);
                cmd.Parameters.AddWithValue("@TenLop", tenLop);
                cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã cập nhật lớp thành công!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
            }

            LoadLop();
            txtML.Enabled = true;
            SetButton(true);
            KhoaDieuKhien(false);
        }
        // Nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtML.Enabled = true;
            SetButton(true);
            KhoaDieuKhien(false);
        }
        // Nút Đóng
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtML.Text = dgvLop.Rows[e.RowIndex].Cells["MaLop"].Value.ToString();
                txtTenLop.Text = dgvLop.Rows[e.RowIndex].Cells["TenLop"].Value.ToString();
                cbbKhoa.Text = dgvLop.Rows[e.RowIndex].Cells["TenKhoa"].Value.ToString();
            }
        }
    }
}
