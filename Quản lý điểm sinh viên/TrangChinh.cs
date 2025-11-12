using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_điểm_sinh_viên
{
    public partial class TrangChinh : Form
    {
        public TrangChinh()
        {
            InitializeComponent();
        }

        private void TrangChinh_Load(object sender, EventArgs e)
        {

        }
        // Khi click "Quản lý điểm sinh viên"
        private void mnuQuanLyDiemSinhVien_Click(object sender, EventArgs e)
        {
            QuanLyDiemSinhVien frm = new QuanLyDiemSinhVien();
            frm.ShowDialog(); // Mở form con để quản lý điểm
        }
        // Khi click "Thoát"
        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Thoát chương trình
        }
        // Khi chọn "Sinh viên"
        private void mnuSinhVien_Click(object sender, EventArgs e)
        {
            SinhVien frm = new SinhVien();
            frm.ShowDialog();  // Mở form quản lý sinh viên
        }
        // Khi chọn "Lớp"
        private void mnuLop_Click(object sender, EventArgs e)
        {
            Lop frm = new Lop();
            frm.ShowDialog();  // Mở form quản lý lớp
        }
        // Khi chọn "điểm"
        private void mnuDiem_Click(object sender, EventArgs e)
        {
            Diem frm = new Diem();
            frm.ShowDialog();  // Mở form xem điểm
        }
        // Khi chọn "Môn học"
        private void mnuMonHoc_Click(object sender, EventArgs e)
        {
            MonHoc frm = new MonHoc();
            frm.ShowDialog();  // Mở form danh sách môn học
        }
        // Khi chọn "Điểm rèn luyện"
        private void mnuDiemRenLuyen_Click(object sender, EventArgs e)
        {
            DiemRenLuyen frm = new DiemRenLuyen();
            frm.ShowDialog();  // Mở form điểm rèn luyện
        }
        // Khi chọn "Học kỳ"
        private void mnuHocKy_Click(object sender, EventArgs e)
        {
            HocKy frm = new HocKy();
               frm.ShowDialog();  // Mở form học kỳ
        }
    }
}
