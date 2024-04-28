USE test

CREATE TABLE [dbo].[users]
(
	id int(11) PRIMARY KEY NOT NULL,
	Ten nvarchar(50) NOT NULL
)

Create Table [dbo].[Sach]
(
	MaSach int Identity(1,1) Primary Key NOT NULL,
	Ten nvarchar(50) NOT NULL,
	TacGia nvarchar(50) NOT NULL,
	MoTa nvarchar(500) NOT NULL,
	URLAnh nvarchar(50) NOT NULL,
	Gia decimal(8,0) NOT NULL,
	SoLuong int NOT NULL,
	MaDanhMuc int NOT NULL,
	Foreign Key(MaDanhMuc) References DanhMuc(MaDanhMuc)
)


Create Table [dbo].[NguoiDung]
(
	MaNguoiDung int Identity(1,1) Primary Key NOT NULL,
	TenNguoiDung nvarchar(50) NOT NULL,
	Email nvarchar(50) NOT NULL,
	NgaySinh date NOT NULL,
	MatKhau nvarchar(50) NOT NULL,
	VaiTro nvarchar(50) NOT NULL
)
Insert Into NguoiDung(TenNguoiDung,Email,NgaySinh,MatKhau,VaiTro) Values (N'Admin',N'admin@','2003/1/1',N'admin123',N'Quản lý');

CREATE TABLE [dbo].[DongGioHang] (
    [MaDong]    INT           IDENTITY (1, 1) NOT NULL,
    [Ten]       NVARCHAR (50) NOT NULL,
    [URLAnh]    NVARCHAR (50) NOT NULL,
    [Gia]       DECIMAL (8)   NOT NULL,
    [SoLuong]   INT           NOT NULL,
    [ThanhTien] DECIMAL (8)   NOT NULL,
    [MaSach]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([MaDong] ASC),
    FOREIGN KEY ([MaSach]) REFERENCES [dbo].[Sach] ([MaSach])
);

CREATE TABLE [dbo].[GioHang] (
    [MaGioHang]   INT IDENTITY (1, 1) NOT NULL,
    [MaDong]      INT NOT NULL,
    [MaNguoiDung] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([MaGioHang] ASC),
    FOREIGN KEY ([MaDong]) REFERENCES [dbo].[DongGioHang] ([MaDong]),
    FOREIGN KEY ([MaNguoiDung]) REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
);

