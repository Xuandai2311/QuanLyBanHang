Create database QuanLyBanHang;
use QuanLyBanHang;

Create table KhachHang (
	MaKH nvarchar(30) not null primary key,
	TenKH nvarchar(150),
	DiaChi nvarchar(150),
	DienThoai nvarchar(12),
)

Create table NhanVien (
	MaNV nvarchar(30) not null primary key,
	TenNV nvarchar(150),
	DiaChi nvarchar(150),
	GioiTinh nvarchar(10),
	DienThoai nvarchar(20),
	NgaySinh Date
)
drop table NhanVien;


Create table HangHoa (
	MaHang nvarchar(30) not null primary key,
	MaNCC nvarchar(30),
	TenHang nvarchar(150),
	DVTinh nvarchar(10),
	XuatXu nvarchar(150),
	SoLuong float,
	DonGiaNhap float,
	DonGiaBan float
)


Create table HDBan (
	MaHDBan nvarchar(30) not null primary key,
	MaKH nvarchar(30) not null,
	MaNV nvarchar(30) not null,
	TongTien float not null,
	NgayBan Datetime
)

Create table ChiTietHDBan (
	MaHDBan nvarchar(30) not null,
	MaHang nvarchar(30) not null,
	SoLuong float,
	DonGia float,
	GiamGia float,
	ThanhTien float,
	primary key clustered (MaHDBan asc, MaHang asc)
)

Create table NCC (
	MaNCC nvarchar(30) not null primary key,
	TenNCC nvarchar(150)
)

