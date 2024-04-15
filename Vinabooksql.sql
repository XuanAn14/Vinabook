USE Vinabook

CREATE TABLE [dbo].[DanhMuc]
(
	MaDanhMuc int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Ten nvarchar(50) NOT NULL
)
Insert Into DanhMuc (Ten) Values (N'Phiêu lưu');
Insert Into DanhMuc (Ten) Values (N'Tình cảm');
Insert Into DanhMuc (Ten) Values (N'Kinh dị');
Insert Into DanhMuc (Ten) Values (N'Kinh doanh');
Insert Into DanhMuc (Ten) Values (N'Khoa học');
Insert Into DanhMuc (Ten) Values (N'Tâm lý');

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
Insert Into Sach (Ten,TacGia,MoTa,URLAnh,Gia,SoLuong,MaDanhMuc) Values (N'Rừng Nauy',N'Haruki Murakami',N'Rừng Na-Uy là tiểu thuyết của nhà văn Nhật Bản Murakami Haruki, được xuất bản lần đầu năm 1987.',N'/assets/img/rungnauy.jpg',100000,23,2);
Insert Into Sach (Ten,TacGia,MoTa,URLAnh,Gia,SoLuong,MaDanhMuc) Values (N'Hoang Dại',N'Phan Hồn Nhiên',N'Truyện dài kì mới nhất của tác giả Phan Hồn Nhiên là một câu chuyện hồi hộp nghẹt thở ngay từ lúc bắt đầu cho đến tận khi kết thúc. Về một khởi đầu bất ngờ dẫn đến một hành trình không thể quay đầu.',N'/assets/img/sach_1.jpg',81000,43,1);
Insert Into Sach (Ten,TacGia,MoTa,URLAnh,Gia,SoLuong,MaDanhMuc) Values (N'Con Chim Xanh Biếc Bay Về',N'Nguyễn Nhật Ánh',N'Như một cuốn phim “trinh thám tình yêu”, Con chim xanh biếc bay về dẫn bạn đi hết từ bất ngờ này đến tò mò suy đoán khác, để kết thúc bằng một nỗi hân hoan vô bờ sau bao phen hồi hộp nghi kỵ đến khó thở.',N'/assets/img/sach_2.jpg',202000,33,2);
Insert Into Sach (Ten,TacGia,MoTa,URLAnh,Gia,SoLuong,MaDanhMuc) Values (N'Muôn Kiếp Nhân Sinh',N'Nguyên Phong',N'tập 3 bàn về khía cạnh đạo đức của con người, đặc biệt là lòng tham và cực đối lập của nó – thái độ sống cho đi. Qua đó, tác giả cùng nhân vật chính Thomas và bậc thầy giác ngộ Kris đã gửi gắm vào quyển sách những thông điệp mạnh mẽ về tương lai nhân loại.',N'/assets/img/sach_3.jpg',109000,23,5);
Insert Into Sach (Ten,TacGia,MoTa,URLAnh,Gia,SoLuong,MaDanhMuc) Values (N'Đường Mây Qua Xứ Tuyết', N'Anagarika Govinda',N'"Đường Mây Qua Xứ Tuyết" ("The Way of the White Clouds") ghi lại những điều Anagarika Govinda chứng kiến trong thời gian du hành ở Tây Tạng. ',N'/assets/img/sach_4.jpg',70000,23,1);
Insert Into Sach (Ten,TacGia,MoTa,URLAnh,Gia,SoLuong,MaDanhMuc) Values (N'Sự Im Lặng Của Bầy Cừu', N'Thomas Harris',N'Sự im lặng của bầy cừu hội tụ đầy đủ những yếu tố làm nên một cuốn tiểu thuyết trinh thám kinh dị xuất sắc nhất: không một dấu vết lúng túng trong những chi tiết thuộc lĩnh vực chuyên môn, với các tình tiết giật gân, cái chết luôn lơ lửng, với cuộc so găng của những bộ óc lớn mà không có chỗ cho kẻ ngu ngốc để cuộc chơi trí tuệ trở nên dễ dàng.',N'/assets/img/sach_5.jpg',98000,23,3);

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

