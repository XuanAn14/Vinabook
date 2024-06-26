USE [Vinabook]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 02/05/2024 21:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[MaDanhMuc] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DongGioHang]    Script Date: 02/05/2024 21:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DongGioHang](
	[MaDong] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[URLAnh] [nvarchar](50) NOT NULL,
	[Gia] [decimal](8, 0) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [decimal](8, 0) NOT NULL,
	[MaSach] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 02/05/2024 21:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[MaGioHang] [int] IDENTITY(1,1) NOT NULL,
	[MaDong] [int] NOT NULL,
	[MaNguoiDung] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGioHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 02/05/2024 21:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[TenNguoiDung] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[VaiTro] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 02/05/2024 21:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[TacGia] [nvarchar](50) NOT NULL,
	[MoTa] [nvarchar](500) NOT NULL,
	[URLAnh] [nvarchar](50) NOT NULL,
	[Gia] [decimal](8, 0) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[MaDanhMuc] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DanhMuc] ON 

INSERT [dbo].[DanhMuc] ([MaDanhMuc], [Ten]) VALUES (1, N'Phiêu lưu')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [Ten]) VALUES (2, N'Tình cảm')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [Ten]) VALUES (3, N'Kinh dị')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [Ten]) VALUES (4, N'Kinh doanh')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [Ten]) VALUES (5, N'Khoa học')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [Ten]) VALUES (6, N'Tâm lý')
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([MaNguoiDung], [TenNguoiDung], [Email], [NgaySinh], [MatKhau], [VaiTro]) VALUES (1, N'Admin', N'admin@', CAST(N'2003-01-01' AS Date), N'an1234', N'Quản lý')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [TenNguoiDung], [Email], [NgaySinh], [MatKhau], [VaiTro]) VALUES (6, N'An', N'anxuan1234@gmail.com', CAST(N'2024-03-14' AS Date), N'an1234', N'Khách hàng')
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[Sach] ON 

INSERT [dbo].[Sach] ([MaSach], [Ten], [TacGia], [MoTa], [URLAnh], [Gia], [SoLuong], [MaDanhMuc]) VALUES (1, N'Rừng Nauy', N'Haruki Murakami', N'Rừng Na-Uy là tiểu thuyết của nhà văn Nhật Bản Murakami Haruki, được xuất bản lần đầu năm 1987.', N'/assets/img/rungnauy.jpg', CAST(100000 AS Decimal(8, 0)), 23, 2)
INSERT [dbo].[Sach] ([MaSach], [Ten], [TacGia], [MoTa], [URLAnh], [Gia], [SoLuong], [MaDanhMuc]) VALUES (2, N'Hoang Dại', N'Phan Hồn Nhiên', N'Truyện dài kì mới nhất của tác giả Phan Hồn Nhiên là một câu chuyện hồi hộp nghẹt thở ngay từ lúc bắt đầu cho đến tận khi kết thúc. Về một khởi đầu bất ngờ dẫn đến một hành trình không thể quay đầu.', N'/assets/img/sach_1.jpg', CAST(81000 AS Decimal(8, 0)), 43, 1)
INSERT [dbo].[Sach] ([MaSach], [Ten], [TacGia], [MoTa], [URLAnh], [Gia], [SoLuong], [MaDanhMuc]) VALUES (3, N'Con Chim Xanh Biếc Bay Về', N'Nguyễn Nhật Ánh', N'Như một cuốn phim “trinh thám tình yêu”, Con chim xanh biếc bay về dẫn bạn đi hết từ bất ngờ này đến tò mò suy đoán khác, để kết thúc bằng một nỗi hân hoan vô bờ sau bao phen hồi hộp nghi kỵ đến khó thở.', N'/assets/img/sach_2.jpg', CAST(202000 AS Decimal(8, 0)), 33, 2)
INSERT [dbo].[Sach] ([MaSach], [Ten], [TacGia], [MoTa], [URLAnh], [Gia], [SoLuong], [MaDanhMuc]) VALUES (4, N'Muôn Kiếp Nhân Sinh', N'Nguyên Phong', N'tập 3 bàn về khía cạnh đạo đức của con người, đặc biệt là lòng tham và cực đối lập của nó – thái độ sống cho đi. Qua đó, tác giả cùng nhân vật chính Thomas và bậc thầy giác ngộ Kris đã gửi gắm vào quyển sách những thông điệp mạnh mẽ về tương lai nhân loại.', N'/assets/img/sach_3.jpg', CAST(109000 AS Decimal(8, 0)), 23, 5)
INSERT [dbo].[Sach] ([MaSach], [Ten], [TacGia], [MoTa], [URLAnh], [Gia], [SoLuong], [MaDanhMuc]) VALUES (5, N'Đường Mây Qua Xứ Tuyết', N'Anagarika Govinda', N'"Đường Mây Qua Xứ Tuyết" ("The Way of the White Clouds") ghi lại những điều Anagarika Govinda chứng kiến trong thời gian du hành ở Tây Tạng. ', N'/assets/img/sach_4.jpg', CAST(70000 AS Decimal(8, 0)), 23, 1)
INSERT [dbo].[Sach] ([MaSach], [Ten], [TacGia], [MoTa], [URLAnh], [Gia], [SoLuong], [MaDanhMuc]) VALUES (6, N'Sự Im Lặng Của Bầy Cừu', N'Thomas Harris', N'Sự im lặng của bầy cừu hội tụ đầy đủ những yếu tố làm nên một cuốn tiểu thuyết trinh thám kinh dị xuất sắc nhất: không một dấu vết lúng túng trong những chi tiết thuộc lĩnh vực chuyên môn, với các tình tiết giật gân, cái chết luôn lơ lửng, với cuộc so găng của những bộ óc lớn mà không có chỗ cho kẻ ngu ngốc để cuộc chơi trí tuệ trở nên dễ dàng.', N'/assets/img/sach_5.jpg', CAST(98000 AS Decimal(8, 0)), 23, 3)
SET IDENTITY_INSERT [dbo].[Sach] OFF
GO
ALTER TABLE [dbo].[DongGioHang]  WITH CHECK ADD FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD FOREIGN KEY([MaDong])
REFERENCES [dbo].[DongGioHang] ([MaDong])
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([MaDanhMuc])
REFERENCES [dbo].[DanhMuc] ([MaDanhMuc])
GO
