using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quản_lý_điểm_sinh_viên
{
    public partial class DiemRenLuyen : Form
    {
        string connectionString = @"Data Source=.;Initial Catalog=QuanLyDiemSinhVien;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;
        bool themMoi;
        
        public DiemRenLuyen()
        {
            InitializeComponent();
        }

        private void DiemRenLuyen_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            LoadHocKy(); //  Nạp danh sách học kỳ
            LoadDiemRenLuyen();
            SetButtonState(true);
            KhoaDieuKhien(false);

            // Tự động xếp loại khi người dùng nhập điểm
            txtDRL.TextChanged += txtDRL_TextChanged;
        }
        // ✅ Nạp danh sách điểm rèn luyện
        private void LoadDiemRenLuyen()
        {
            string sql = "SELECT * FROM DiemRenLuyen";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvDiemRenLuyen.DataSource = dt;

            dgvDiemRenLuyen.Columns["MaSV"].HeaderText = "Mã sinh viên";
            dgvDiemRenLuyen.Columns["MaHK"].HeaderText = "Mã học kỳ";
            dgvDiemRenLuyen.Columns["DiemRL"].HeaderText = "Điểm rèn luyện";
            dgvDiemRenLuyen.Columns["XepLoai"].HeaderText = "Xếp loại";
        }
        // ✅ Nạp danh sách học kỳ vào ComboBox
        private void LoadHocKy()
        {
            string sql = "SELECT MaHK, TenHK FROM HocKy"; // đổi tên cột đúng theo CSDL của bạn
            SqlDataAdapter daHK = new SqlDataAdapter(sql, conn);
            DataTable dtHK = new DataTable();
            daHK.Fill(dtHK);

            cbbHocKy.DataSource = dtHK;
            cbbHocKy.DisplayMember = "TenHK"; // hiển thị tên học kỳ
            cbbHocKy.ValueMember = "MaHK";    // lấy mã học kỳ khi lưu
            cbbHocKy.SelectedIndex = -1;
        }

        // ✅ Khóa/Mở điều khiển
        private void KhoaDieuKhien(bool mo)
        {
            txtMSSV.Enabled = mo;
            txtDRL.Enabled = mo;
            cbbHocKy.Enabled = mo;
            txtXepLoai.Enabled = false; // Xếp loại tự động, không cho nhập tay
            btnLuu.Enabled = mo;
            btnHuy.Enabled = mo;
        }

        private void XoaTrang()
        {
            txtMSSV.Clear();
            txtDRL.Clear();
            txtXepLoai.Clear();
            cbbHocKy.SelectedIndex = -1;
            txtMSSV.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            themMoi = true;
            XoaTrang();
            SetButtonState(false);
            KhoaDieuKhien(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "" || cbbHocKy.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sinh viên và học kỳ cần sửa!");
                return;
            }

            themMoi = false;
            SetButtonState(false);
            KhoaDieuKhien(true);
            txtMSSV.Enabled = false;
            cbbHocKy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "" || cbbHocKy.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa bản ghi này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM DiemRenLuyen WHERE MaSV=@MaSV AND MaHK=@MaHK";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSV", txtMSSV.Text);
                cmd.Parameters.AddWithValue("@MaHK", cbbHocKy.SelectedValue);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadDiemRenLuyen();
                XoaTrang();
                MessageBox.Show("Xóa thành công!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "" || cbbHocKy.SelectedIndex == -1 || txtDRL.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string sql;
            if (themMoi)
                sql = "INSERT INTO DiemRenLuyen (MaSV, MaHK, DiemRL, XepLoai) VALUES (@MaSV, @MaHK, @DiemRL, @XepLoai)";
            else
                sql = "UPDATE DiemRenLuyen SET DiemRL=@DiemRL, XepLoai=@XepLoai WHERE MaSV=@MaSV AND MaHK=@MaHK";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", txtMSSV.Text);
            cmd.Parameters.AddWithValue("@MaHK", cbbHocKy.SelectedValue);
            cmd.Parameters.AddWithValue("@DiemRL", int.Parse(txtDRL.Text));
            cmd.Parameters.AddWithValue("@XepLoai", txtXepLoai.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            LoadDiemRenLuyen();
            SetButtonState(true);
            KhoaDieuKhien(false);
            MessageBox.Show("Lưu dữ liệu thành công!");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetButtonState(true);
            KhoaDieuKhien(false);
            XoaTrang();
        }

        private void dgvDiemRenLuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMSSV.Text = dgvDiemRenLuyen.Rows[e.RowIndex].Cells["MaSV"].Value.ToString();
                cbbHocKy.SelectedValue = dgvDiemRenLuyen.Rows[e.RowIndex].Cells["MaHK"].Value.ToString();
                txtDRL.Text = dgvDiemRenLuyen.Rows[e.RowIndex].Cells["DiemRL"].Value.ToString();
                txtXepLoai.Text = dgvDiemRenLuyen.Rows[e.RowIndex].Cells["XepLoai"].Value.ToString();
            }
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
        // ✅ Tự động xếp loại khi nhập điểm
        private void txtDRL_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtDRL.Text, out int diem))
            {
                if (diem >= 90) txtXepLoai.Text = "Xuất sắc";
                else if (diem >= 80) txtXepLoai.Text = "Tốt";
                else if (diem >= 65) txtXepLoai.Text = "Khá";
                else if (diem >= 50) txtXepLoai.Text = "Trung bình";
                else txtXepLoai.Text = "Yếu";
            }
            else
            {
                txtXepLoai.Text = "";
            }
        }
    }
}
