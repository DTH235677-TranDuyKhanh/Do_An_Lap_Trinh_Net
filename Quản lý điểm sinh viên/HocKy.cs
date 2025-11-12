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
    public partial class HocKy : Form
    {
        SqlConnection conn;
        DataTable tblHocKy;
        bool themMoi = false;
        public HocKy()
        {
            InitializeComponent();
        }

        private void HocKy_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=.;Initial Catalog=QuanLyDiemSinhVien;Integrated Security=True");
            conn = new SqlConnection(@"Data Source=.;Initial Catalog=QuanLyDiemSinhVien;Integrated Security=True");
            conn.Open();
            LoadDataGridView();
            SetButtonState(true);
            KhoaDieuKhien(false);
        }
        private void LoadDataGridView()
        {
            string sql = "SELECT * FROM HOCKY";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            tblHocKy = new DataTable();
            da.Fill(tblHocKy);
            dgvHocKy.DataSource = tblHocKy;

            dgvHocKy.Columns[0].HeaderText = "Mã học kỳ";
            dgvHocKy.Columns[1].HeaderText = "Tên học kỳ";
            dgvHocKy.Columns[2].HeaderText = "Năm học";
        }
        private void SetButtonState(bool enable)
        {
            btnThem.Enabled = enable;
            btnSua.Enabled = enable;
            btnDong.Enabled = enable;

            btnLuu.Enabled = !enable;
            btnHuy.Enabled = !enable;
        }

        private void KhoaDieuKhien(bool mo)
        {
            txtMHocKy.Enabled = mo;
            cbbTenHocKy.Enabled = mo;
            txtNamHoc.Enabled = mo;
        }

        private void XoaTrang()
        {
            txtMHocKy.Clear();
            txtNamHoc.Clear();
            cbbTenHocKy.SelectedIndex = -1;
            txtMHocKy.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            themMoi = true;
            XoaTrang();
            KhoaDieuKhien(true);
            SetButtonState(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMHocKy.Text == "" || cbbTenHocKy.Text == "" || txtNamHoc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string sql;
            if (themMoi)
                sql = "INSERT INTO HOCKY (MaHK, TenHK, NamHoc) VALUES (@MaHK, @TenHK, @NamHoc)";
            else
                sql = "UPDATE HOCKY SET TenHK=@TenHK, NamHoc=@NamHoc WHERE MaHK=@MaHK";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaHK", txtMHocKy.Text);
            cmd.Parameters.AddWithValue("@TenHK", cbbTenHocKy.Text);
            cmd.Parameters.AddWithValue("@NamHoc", txtNamHoc.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu dữ liệu thành công!");
                LoadDataGridView();
                KhoaDieuKhien(false);
                SetButtonState(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMHocKy.Text == "")
            {
                MessageBox.Show("Vui lòng chọn học kỳ cần sửa!");
                return;
            }

            themMoi = false;
            KhoaDieuKhien(true);
            txtMHocKy.Enabled = false; // không cho sửa mã
            SetButtonState(false);
        }

        

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaTrang();
            KhoaDieuKhien(false);
            SetButtonState(true);
        }

        private void dgvHocKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                txtMHocKy.Text = dgvHocKy.Rows[e.RowIndex].Cells["MaHK"].Value.ToString();
                cbbTenHocKy.Text = dgvHocKy.Rows[e.RowIndex].Cells["TenHK"].Value.ToString();
                txtNamHoc.Text = dgvHocKy.Rows[e.RowIndex].Cells["NamHoc"].Value.ToString();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
