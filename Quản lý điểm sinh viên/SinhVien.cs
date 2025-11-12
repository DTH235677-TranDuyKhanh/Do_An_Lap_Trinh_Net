using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Quản_lý_điểm_sinh_viên
{
    public partial class SinhVien : Form
    {
        string connectionString = @"Data Source=.;Initial Catalog=QuanLyDiemSinhVien;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;

        public SinhVien()
        {
            InitializeComponent();
        }

        private void SinhVien_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            LoadSinhVien();
            LoadLop();
            LoadDiaChi();
            SetButtonState(true);
            KhoaDieuKhien(false); // 🔒 Khóa các ô nhập khi vừa mở form
        }
        // ✅ Load địa chỉ từ bảng SinhVien (không có bảng DiaChi)
        private void LoadDiaChi()
        {
            string sql = "SELECT DISTINCT DiaChi FROM SinhVien WHERE DiaChi IS NOT NULL";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbbDiaChi.DataSource = dt;
            cbbDiaChi.DisplayMember = "DiaChi";
            cbbDiaChi.ValueMember = "DiaChi";
            cbbDiaChi.SelectedIndex = -1;
        }

        // ✅ Nạp danh sách sinh viên
        private void LoadSinhVien()
        {
            string sql = "SELECT * FROM SinhVien";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvSinhVien.DataSource = dt;
        }

        // ✅ Nạp danh sách lớp
        private void LoadLop()
        {
            string sql = "SELECT MaLop, TenLop FROM Lop";
            SqlDataAdapter daLop = new SqlDataAdapter(sql, conn);
            DataTable dtLop = new DataTable();
            daLop.Fill(dtLop);
            cbbML.DataSource = dtLop;
            cbbML.DisplayMember = "TenLop";
            cbbML.ValueMember = "MaLop";
            cbbML.SelectedIndex = -1;
        }
        // 🔹 Hàm khóa/mở điều khiển nhập liệu
        private void KhoaDieuKhien(bool mo)
        {
            txtMSSV.Enabled = mo;
            txtHoTen.Enabled = mo;
            dtpNgaySinh.Enabled = mo;
            rdbNam.Enabled = mo;
            rdbNu.Enabled = mo;
            cbbDiaChi.Enabled = mo;
            cbbML.Enabled = mo;
        }
        // Nút thêm 
        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearText();
            SetButtonState(false);
            KhoaDieuKhien(true);
            txtMSSV.Enabled = true;
            txtMSSV.Focus();
        }
        // Nút lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSSV.Text) ||
               string.IsNullOrWhiteSpace(txtHoTen.Text) ||
               cbbML.SelectedIndex == -1 ||
               (rdbNam.Checked == false && rdbNu.Checked == false))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql;
            bool isInsert = txtMSSV.Enabled; // true = thêm mới, false = cập nhật

            if (isInsert)
                sql = "INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, MaLop) VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @MaLop)";
            else
                sql = "UPDATE SinhVien SET HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, DiaChi=@DiaChi, MaLop=@MaLop WHERE MaSV=@MaSV";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSV", txtMSSV.Text.Trim());
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", rdbNam.Checked ? "Nam" : "Nữ");
                cmd.Parameters.AddWithValue("@DiaChi", cbbDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@MaLop", cbbML.SelectedValue.ToString());

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lưu thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
                conn.Close();
            }

            LoadSinhVien();
            SetButtonState(true);
            KhoaDieuKhien(false); // 🔒 Khóa lại điều khiển
            ClearText();
        }
        // Nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên này? (Tất cả điểm và rèn luyện của sinh viên cũng sẽ bị xóa)",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                string maSV = txtMSSV.Text.Trim();

                conn.Open();
                try
                {
                    // 1️⃣ Xóa bảng DiemRenLuyen trước
                    string sqlXoaDRL = "DELETE FROM DiemRenLuyen WHERE MaSV=@MaSV";
                    SqlCommand cmd0 = new SqlCommand(sqlXoaDRL, conn);
                    cmd0.Parameters.AddWithValue("@MaSV", maSV);
                    cmd0.ExecuteNonQuery();

                    // 2️⃣ Xóa bảng Diem
                    string sqlXoaDiem = "DELETE FROM Diem WHERE MaSV=@MaSV";
                    SqlCommand cmd1 = new SqlCommand(sqlXoaDiem, conn);
                    cmd1.Parameters.AddWithValue("@MaSV", maSV);
                    cmd1.ExecuteNonQuery();

                    // 3️⃣ Cuối cùng xóa sinh viên
                    string sqlXoaSV = "DELETE FROM SinhVien WHERE MaSV=@MaSV";
                    SqlCommand cmd2 = new SqlCommand(sqlXoaSV, conn);
                    cmd2.Parameters.AddWithValue("@MaSV", maSV);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Đã xóa sinh viên cùng toàn bộ điểm và điểm rèn luyện thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                LoadSinhVien();
                ClearText();
            }
        }


        // Nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!");
                return;
            }

            SetButtonState(false);
            KhoaDieuKhien(true);
            txtMSSV.Enabled = false; // Không cho sửa mã sinh viên
        }
        // Nút hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearText();
            SetButtonState(true);
            KhoaDieuKhien(false);
        }
        // Nút đóng
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];
                txtMSSV.Text = row.Cells["MaSV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                string gt = row.Cells["GioiTinh"].Value.ToString();
                if (gt == "Nam") rdbNam.Checked = true; else rdbNu.Checked = true;
                cbbDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                cbbML.SelectedValue = row.Cells["MaLop"].Value.ToString();
            }
        }
        // ======== Hàm phụ =========
        // ======== Hàm phụ =========
        private void ClearText()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            cbbML.SelectedIndex = -1;
            cbbDiaChi.Text = "";
            rdbNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
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
