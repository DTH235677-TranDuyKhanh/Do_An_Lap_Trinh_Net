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
    public partial class MonHoc : Form
    {
        string connectionString = @"Data Source=.;Initial Catalog=QuanLyDiemSinhVien;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;
        bool themMoi;
        public MonHoc()
        {
            InitializeComponent();
        }

        private void MonHoc_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            LoadData();
            SetButtonState(true);
            KhoaDieuKhien(false);
        }
        private void LoadData()
        {
            string sql = "SELECT * FROM MonHoc";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvMonHoc.DataSource = dt;

            // Đặt tiêu đề cột dễ đọc
            dgvMonHoc.Columns["MaMH"].HeaderText = "Mã môn học";
            dgvMonHoc.Columns["TenMH"].HeaderText = "Tên môn học";
            dgvMonHoc.Columns["SoTinChi"].HeaderText = "Số tín chỉ";
        }

        private void KhoaDieuKhien(bool mo)
        {
            txtMMonHoc.Enabled = mo;
            txtTenMonHoc.Enabled = mo;
            txtSTC.Enabled = mo;
        }

        private void XoaTrang()
        {
            txtMMonHoc.Clear();
            txtTenMonHoc.Clear();
            txtSTC.Clear();
            txtMMonHoc.Focus();
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
            if (txtMMonHoc.Text == "")
            {
                MessageBox.Show("Vui lòng chọn môn học cần sửa!");
                return;
            }
            themMoi = false;
            SetButtonState(false);
            KhoaDieuKhien(true);
            txtMMonHoc.Enabled = false; // Không cho sửa mã
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMMonHoc.Text == "" || txtTenMonHoc.Text == "" || txtSTC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string sql;
            if (themMoi)
                sql = "INSERT INTO MonHoc (MaMH, TenMH, SoTinChi) VALUES (@MaMH, @TenMH, @SoTinChi)";
            else
                sql = "UPDATE MonHoc SET TenMH=@TenMH, SoTinChi=@SoTinChi WHERE MaMH=@MaMH";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaMH", txtMMonHoc.Text);
            cmd.Parameters.AddWithValue("@TenMH", txtTenMonHoc.Text);
            cmd.Parameters.AddWithValue("@SoTinChi", int.Parse(txtSTC.Text));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            LoadData();
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

        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMMonHoc.Text = dgvMonHoc.Rows[e.RowIndex].Cells["MaMH"].Value.ToString();
                txtTenMonHoc.Text = dgvMonHoc.Rows[e.RowIndex].Cells["TenMH"].Value.ToString();
                txtSTC.Text = dgvMonHoc.Rows[e.RowIndex].Cells["SoTinChi"].Value.ToString();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetButtonState(bool enable)
        {
            btnThem.Enabled = enable;
            btnSua.Enabled = enable;
            btnLuu.Enabled = !enable;
            btnHuy.Enabled = !enable;
        }
    }
}
