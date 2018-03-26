create database QuanLyNhanSu

create table PHONGBAN(
	MaPB char(10) primary key,
	TenPB text,
	DiaChi text,
	SDT text,
)

create table CHUCVU(
	MaCV char(10) primary key,
	TenCV text
)

create table TRINHDOHOCVAN(
	MaTDHV char(10) primary key,
	TenTDHV text,
	ChuyenNganhHoc text
)

create table LUONG(
	BacLuong float primary key,
	LuongCB float,
	HeSoLuong float,
	HeSoPhuCap float
)

create table SOQUYETDINHKHENTHUONG_KYLUAT(
	SoQD char(10) primary key,
	LyDo text,
	HinhThuc text
)

create table NHANVIEN(
	MaNV char(10) primary key,
	HoTen text,
	GioiTinh text,
	NgaySinh date,
	DiaChi text,
	DanToc text,
	QuocTich text,
	SDT text,
	MaPB char(10) references PHONGBAN(MaPB),
	MaCV char(10) references CHUCVU(MaCV),
	MaTDHV char(10) references TRINHDOHOCVAN(MaTDHV),
	BacLuong float references LUONG(BacLuong)
)

create table HOPDONGLAODONG(
	MaHD char(10) primary key,
	MaNV char(10) references NHANVIEN(MaNV),
	LoaiHD text,
	TuNgay date,
	DenNgay date,
)

create table KHENTHUONG_KYLUAT(
	MaNV char(10) references NHANVIEN(MaNV),
	SoQD char(10) references SOQUYETDINHKHENTHUONG_KYLUAT(SoQD),
	ThoiGian date,
	primary key (MaNV, SoQD)
)


create table NGUOIDUNG(
	MaNV char(10) references NHANVIEN(MaNV),
	primary key (MaNV),
	MatKhau text,
	Them bit,
	Sua bit,
	Xoa bit,
	CreateLogin bit,
)
