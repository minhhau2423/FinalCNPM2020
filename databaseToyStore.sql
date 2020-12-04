use master
go
create database ToyStoreManager
go 
use ToyStoreManager
go

create table Users(
	MaNV char(30),
	NameLogin varchar(20),
	PassW varchar(20),
	QuyenHan nvarchar(50),
	primary key(NameLogin)
)
go


create table NhanVien(
	MaNV char(30),
	TenNV nvarchar(100),
	NgaySinh date,
	Email char(50),
	SDT char(12),
	DiaChi nvarchar(100),
	ViTri nvarchar(50),
	GioiTinh nvarchar(5)
	primary key(MaNV)
)
go

create table SanPham(
	MaSP char(10),
	TenSP nvarchar(50),
	NSX nvarchar(50),
	SoLuong int,
	DonGia int,
	primary key(MaSP)
)
go

create table KhachHang(
	MaKH char(10),
	TenKH nvarchar(100),
	SdtKH char(12),
	DiaChiKH nvarchar(100),
	primary key(MaKH)
)
go

create table HoaDon(
	MaHD char(10),
	MaNV char(30),
	MaKH char(10),
	NgayLapHD date,
	TongTien int,
	Primary key(MaHD)
)
go


create table ChiTietHoaDon(
	MaHD char(10),
	SanPham char(10),
	SoLuong int,
	ThanhTien int,
	primary key(MaHD, SanPham)
)
go 



create table Kho(
	MaSP char(10),
	NgayNhap date,
	SoLuongNhap int,
	NgayXuatGanNhat date,
	SoLuongXuatGanNhat int,
	GiaNhap int,
	primary key(MaSP)
)
go

ALTER TABLE Users ADD CONSTRAINT fk_DangNhap  FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
go
ALTER TABLE HoaDon ADD CONSTRAINT fk_CTHD  FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
go
ALTER TABLE HoaDon ADD CONSTRAINT fk_CTHD2  FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
go
ALTER TABLE ChiTietHoaDon ADD CONSTRAINT fk_CTHD3  FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD)
go
ALTER TABLE Kho ADD CONSTRAINT fk_Kho  FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
go


