-- ===============================================
--  CƠ SỞ DỮ LIỆU: QUẢN LÝ ĐIỂM SINH VIÊN
--  Tác giả: TRAN DUY KHANH
--  Ngày tạo: 31/10/2025
-- ===============================================

-- Tạo database (nếu chưa có)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QuanLyDiemSinhVien')
    CREATE DATABASE QuanLyDiemSinhVien;
GO

USE QuanLyDiemSinhVien;
GO

-- Xóa các bảng cũ (nếu có)
DROP TABLE IF EXISTS Diem;
DROP TABLE IF EXISTS DiemRenLuyen;
DROP TABLE IF EXISTS SinhVien;
DROP TABLE IF EXISTS Lop;
DROP TABLE IF EXISTS HocKy;
DROP TABLE IF EXISTS MonHoc;
DROP TABLE IF EXISTS Khoa;
GO

-- ===============================================
-- BẢNG KHOA
-- ===============================================
CREATE TABLE Khoa (
    MaKhoa CHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);

-- Dữ liệu KHOA
INSERT INTO Khoa VALUES
('CNTT', N'Công nghệ thông tin'),
('KT', N'Kế toán'),
('QTKD', N'Quản trị kinh doanh'),
('SP', N'Sư phạm'),
('DL', N'Du lịch'),
('CK', N'Cơ khí'),
('DK', N'Điện - Điện tử'),
('XD', N'Xây dựng'),
('MK', N'Marketing'),
('NN', N'Ngoại ngữ');
GO

-- ===============================================
-- BẢNG LỚP
-- ===============================================
CREATE TABLE Lop (
    MaLop CHAR(10) PRIMARY KEY,
    TenLop NVARCHAR(50) NOT NULL,
    MaKhoa CHAR(10) NOT NULL,
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);

-- Dữ liệu LOP
INSERT INTO Lop VALUES
('CTK45A', N'Công nghệ thông tin 45A', 'CNTT'),
('CTK45B', N'Công nghệ thông tin 45B', 'CNTT'),
('KTK45A', N'Kế toán 45A', 'KT'),
('QTK45A', N'Quản trị kinh doanh 45A', 'QTKD'),
('SPK45A', N'Sư phạm Toán 45A', 'SP'),
('DLK45A', N'Du lịch 45A', 'DL'),
('CKK45A', N'Cơ khí 45A', 'CK'),
('DKK45A', N'Điện - Điện tử 45A', 'DK'),
('XDK45A', N'Xây dựng 45A', 'XD'),
('MK45A',  N'Marketing 45A', 'MK');
GO

-- ===============================================
-- BẢNG SINH VIÊN
-- ===============================================
CREATE TABLE SinhVien (
    MaSV CHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(5),
    DiaChi NVARCHAR(100),
    MaLop CHAR(10) NOT NULL,
    FOREIGN KEY (MaLop) REFERENCES Lop(MaLop)
);

-- Dữ liệu SINHVIEN
INSERT INTO SinhVien VALUES
('SV001', N'Nguyễn Văn An', '2004-02-15', N'Nam', N'TP.HCM', 'CTK45A'),
('SV002', N'Lê Thị Bình', '2004-06-22', N'Nữ', N'TP.HCM', 'CTK45A'),
('SV003', N'Phạm Minh Đức', '2003-11-10', N'Nam', N'Hà Nội', 'CTK45B'),
('SV004', N'Trần Hoàng Giang', '2004-05-12', N'Nam', N'Đà Nẵng', 'QTK45A'),
('SV005', N'Vũ Thị Hạnh', '2004-03-08', N'Nữ', N'Hải Phòng', 'KTK45A'),
('SV006', N'Đỗ Văn Khánh', '2004-09-20', N'Nam', N'TP.HCM', 'SPK45A'),
('SV007', N'Trần Thị Lan', '2004-12-01', N'Nữ', N'Cần Thơ', 'DLK45A'),
('SV008', N'Nguyễn Hoài Nam', '2003-08-30', N'Nam', N'TP.HCM', 'CKK45A'),
('SV009', N'Lưu Hữu Phước', '2004-07-05', N'Nam', N'Huế', 'DKK45A'),
('SV010', N'Bùi Thị Yến', '2004-10-11', N'Nữ', N'Hà Nội', 'MK45A');
GO

-- ===============================================
-- BẢNG MÔN HỌC
-- ===============================================
CREATE TABLE MonHoc (
    MaMH CHAR(10) PRIMARY KEY,
    TenMH NVARCHAR(50) NOT NULL,
    SoTinChi INT CHECK (SoTinChi > 0)
);

-- Dữ liệu MONHOC
INSERT INTO MonHoc VALUES
('MH01', N'Lập trình C#', 3),
('MH02', N'Cơ sở dữ liệu', 3),
('MH03', N'Toán cao cấp', 4),
('MH04', N'Triết học Mác-Lênin', 2),
('MH05', N'Hệ điều hành', 3),
('MH06', N'Mạng máy tính', 3),
('MH07', N'Cấu trúc dữ liệu', 4),
('MH08', N'Lập trình Web', 3),
('MH09', N'Phân tích thiết kế HTTT', 3),
('MH10', N'Thiết kế giao diện', 2);
GO

-- ===============================================
-- BẢNG HỌC KỲ
-- ===============================================
CREATE TABLE HocKy (
    MaHK CHAR(10) PRIMARY KEY,
    TenHK NVARCHAR(30) NOT NULL,
    NamHoc CHAR(9) NOT NULL
);

-- Dữ liệu HOCKY
INSERT INTO HocKy VALUES
('HK01', N'Học kỳ 1', N'2023-2024'),
('HK02', N'Học kỳ 2', N'2023-2024'),
('HK03', N'Học kỳ 1', N'2024-2025'),
('HK04', N'Học kỳ 2', N'2024-2025'),
('HK05', N'Học kỳ 1', N'2025-2026'),
('HK06', N'Học kỳ 2', N'2025-2026'),
('HK07', N'Học kỳ 1', N'2026-2027'),
('HK08', N'Học kỳ 2', N'2026-2027'),
('HK09', N'Học kỳ 1', N'2027-2028'),
('HK10', N'Học kỳ 2', N'2027-2028');
GO

-- ===============================================
-- BẢNG ĐIỂM
-- ===============================================
CREATE TABLE Diem (
    MaSV CHAR(10),
    MaMH CHAR(10),
    MaHK CHAR(10),
    DiemTP FLOAT CHECK (DiemTP BETWEEN 0 AND 10),
    DiemThi FLOAT CHECK (DiemThi BETWEEN 0 AND 10),
    DiemTongKet AS (DiemTP * 0.4 + DiemThi * 0.6),
    PRIMARY KEY (MaSV, MaMH, MaHK),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaMH) REFERENCES MonHoc(MaMH),
    FOREIGN KEY (MaHK) REFERENCES HocKy(MaHK)
);

-- Dữ liệu DIEM
INSERT INTO Diem (MaSV, MaMH, MaHK, DiemTP, DiemThi) VALUES
('SV001','MH01','HK01',8.0,7.5),
('SV001','MH02','HK01',7.0,8.0),
('SV002','MH01','HK01',6.5,7.0),
('SV003','MH03','HK02',7.5,8.0),
('SV004','MH04','HK02',8.0,8.5),
('SV005','MH05','HK03',9.0,8.5),
('SV006','MH06','HK03',6.0,6.5),
('SV007','MH07','HK04',7.0,7.0),
('SV008','MH08','HK04',8.0,7.5),
('SV009','MH09','HK05',7.5,7.0);
GO

-- ===============================================
-- BẢNG ĐIỂM RÈN LUYỆN
-- ===============================================
CREATE TABLE DiemRenLuyen (
    MaSV CHAR(10),
    MaHK CHAR(10),
    DiemRL INT CHECK (DiemRL BETWEEN 0 AND 100),
    XepLoai NVARCHAR(20),
    PRIMARY KEY (MaSV, MaHK),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaHK) REFERENCES HocKy(MaHK)
);

-- Dữ liệu DIEMRENLUYEN
INSERT INTO DiemRenLuyen VALUES
('SV001','HK01',85,N'Tốt'),
('SV002','HK01',80,N'Tốt'),
('SV003','HK02',75,N'Khá'),
('SV004','HK02',90,N'Xuất sắc'),
('SV005','HK03',70,N'Khá'),
('SV006','HK03',65,N'Trung bình'),
('SV007','HK04',88,N'Tốt'),
('SV008','HK04',95,N'Xuất sắc'),
('SV009','HK05',78,N'Khá'),
('SV010','HK05',82,N'Tốt');
GO

SELECT * FROM Diem;
SELECT * FROM DiemRenLuyen;
SELECT * FROM MonHoc;
SELECT * FROM HocKy;
SELECT * FROM Khoa;
SELECT * FROM SinhVien;
SELECT * FROM Lop;
