CREATE DATABASE Vinamilk
USE Vinamilk
CREATE TABLE [DanhMuc](
	[MaDM] [nvarchar](20) NOT NULL,
	[TenDM] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[MaDM] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [DanhMuc] ([MaDM], [TenDM]) VALUES (N'dm01', N'Sữa Chua Vinamilk')
INSERT [DanhMuc] ([MaDM], [TenDM]) VALUES (N'dm02', N'Sữa Tươi Vinamilk')
INSERT [DanhMuc] ([MaDM], [TenDM]) VALUES (N'dm03', N'Sữa Dinh Dưỡng Organic')
INSERT [DanhMuc] ([MaDM], [TenDM]) VALUES (N'dm04', N'Sữa Đậu Nành')
INSERT [DanhMuc] ([MaDM], [TenDM]) VALUES (N'dm05', N'Sữa Tươi Không Đường')
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
select * from DanhMuc
CREATE TABLE [TaiKhoan](
	[TenTK] [nvarchar](100) NOT NULL,
	[Mat_Khau] [varchar](50) NULL,
	[HoTen] [nvarchar](100) NULL,
	[Dia_Chi] [nvarchar](255) NULL,
	[SDT] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Quyen] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[TenTK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TenTK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [TaiKhoan] ([TenTK], [Mat_Khau], [HoTen], [Dia_Chi], [SDT], [Email], [Quyen]) VALUES (N'admin@gmail.com', N'123jqk', N'Trần Bằng', N'Bắc Ninh', NULL, N'bang2000@gmail.com', 1)
INSERT [TaiKhoan] ([TenTK], [Mat_Khau], [HoTen], [Dia_Chi], [SDT], [Email], [Quyen]) VALUES (N'user1@gmail.com', N'123jqk', N'Tiến Thành Fmoiz', N'Hải Dương', N'0123456789', N'thanhkhmt@gmail.com',0)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
delete from SanPham
select * from TaiKhoan
CREATE TABLE [SanPham](
	[MaSP] [nvarchar](20) NOT NULL,
	[TenSP] [nvarchar](100) NOT NULL,
	[Anh] [nvarchar](100) NOT NULL,
	[SoLuongCo] [int] NOT NULL,
	[GiaHT] [float] NULL,
	[MoTa] [nvarchar](max) NULL,
	[MaDM] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [SanPham] ([MaSP], [TenSP], [Anh], [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'123', N'Sữa Chua Táo', N'1.jpg', 10000, 12000, N'-    Sữa Chua Táo không chỉ chứa các chất dinh dưỡng cần thiết cho não như đường, vitamin, khoáng chất...', N'dm01')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'124', N'Sữa Chua Kiwi', N'2.jpg', 1020, 13000, N'Sữa Chua Kiwi: Ngoài những chất khoáng tương tự như Kiwi xanh, nó còn cung cấp thêm Vitamin C tốt cho cơ thể.', N'dm01')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'125', N'Sữa Chua Vị Đào', N'3.jpg', 200, 3000, N'Sữa Chua Vị Đào rất giàu pectin là chất giúp làm tăng độ xốp và men vi sinh giúp hệ tiêu hóa ổn địn', N'dm01')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'126', N'Sữa Chua Vị Cherry Đỏ', N'4.jpg', 500, 5000, N'Sữa Chua Vị Cherry Đỏ là nguồn vitamin A tuyệt vời, là loại sữa chua giàu chất sắt, chất xơ cao, chất béo, không cholesterol, tốt cho hệ miễn dịch, tiêu hóa và làm đẹp da.', N'dm01')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'127', N'Sữa Tươi Hữu Cơ', N'5.jpg', 999, 25000, N'Sữa Tươi Hữu Cơ nhằm nâng cao tầm voc VIỆT... và còn chứa các nguyên tố vi lượng khác như canxi, kali, sắt, phốtpho, các vitamin C, B1, B2.', N'dm02')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'128', N'Sữa Bắp', N'6.jpg',2000, 26000, N'Sữa Bắp có thể giảm nguy cơ tai biến tim mạch,và giúp cơ thể tăng cường hệ miễn dịch.', N'dm02')
INSERT [SanPham] ([MaSP], [TenSP], [Anh], [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'129', N'Sữa Tươi Phomai', N'7.jpg', 2000, 27000, N'TSữa Tươi Phomai bổ xung Lipit cho cơ thể giúp trẻ tăng cân nhanh chóng.', N'dm02')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'130', N'Sữa Tươi Alpha', N'8.jpg', 998, 17000, N'Sữa Tươi Alpha chứa Vitamin A và C, cũng như lượng folate và kali,giúp ngăn ngừa các bệnh tim mạch và thúc đẩy sự tiêu hóa lành mạnh.', N'dm02')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'131', N'Organic Gold', N'9.jpg',199, 18000, N'Organic Gold với một lượng calo thấp và chất béo thấp, Diva organic là một bổ sung tuyệt vừa cho bữa ăn, lượng magiê và kali giúp điều chỉnh áp suất máu và giữ cho nhịp đập tim ở ổn định, bảo vệ thành mạch máu.', N'dm03')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'132', N'Organic Yoko', N'10.jpg',2000, 19000, N'Organic Yoko cung cấp nhiều chất chống oxi hóa rất tốt cho tim mạch, huyết áp cao.', N'dm03')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'133', N'Organic Grow Plus', N'11.jpg',4000, 20000, N'Organic Grow Plus có có hàm lượng dĩnh dưỡng cao, giúp tăng cường hệ miễn dịch và cực tốt cho hệ tiêu hóa.', N'dm03')
INSERT [SanPham] ([MaSP], [TenSP], [Anh], [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'134', N'Organic Optimum', N'12.jpg',2233, 2000, N'Organic Optimum nhằm nâng cao tầm voc VIỆT.', N'dm03')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'135', N'Sữa Đậu Nành GoldSoy', N'13.jpg',1420, 11000, N'Sữa Đậu Nành GoldSoy cung cấp nhiều chất chống oxi hóa rất tốt cho tim mạch, huyết áp cao, làm đẹp da.', N'dm04')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'136', N'Sữa Đậu Nành Óc Chó', N'14.jpg',3000, 19500, N'Sữa Đậu Nành Óc Chó không chỉ là thức uống ngon và bổ dưỡng, mà có thể được xem là bài thuốc phòng và trị bệnh do thành phần dinh dưỡng chứa nhiều loại vitamin,giúp trẻ thông minh hơn...', N'dm04')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'137', N'Sữa Đậu Nành Đậu Đỏ', N'15.jpg', 200, 12500, N'TSữa Đậu Nành Đậu Đỏ cũng giống như những loại sữa khác có nhiều vitamin A, C, canxi, và sắt, cùng với pectin, và những chất tốt cho hệ tiêu hóa. Với một lượng calo thấp và chất béo thấp', N'dm04')
INSERT [SanPham] ([MaSP], [TenSP], [Anh], [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'138', N'Sữa Đậu Nành Nha Đam', N'16.jpg', 1989, 30000, N'Sữa Đậu Nành Nha Đam chứa nhiều chất pectin, một chất xơ hòa tan làm giảm cholesterol và chất chống oxy hóa, ngăn ngừa bệnh tim.', N'dm04')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'139', N'Sữa Tươi Thiên Nhiên', N'17.jpg',200, 31000, N'Sữa Tươi Thiên Nhiên có chứa nhiều Vitamin C, tốt cho da. ', N'dm05')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'140', N'Sữa Tươi', N'18.jpg',2999, 9000, N'Sữa Tươi nói chung đều là nguồn cung cấp vitamin A, cũng như chất sắt, chất xơ, chất béo dồi dào, đồng thời không chứa cholesterol, tốt cho hệ miễn dịch.', N'dm05')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'141', N'Sữa Tươi Nguyên Chất', N'19.jpg', 1000, 3000, N'Không chứa cất bảo quản tốt cho da tăng sức đề kháng chống lão hóa.', N'dm05')
INSERT [SanPham] ([MaSP], [TenSP], [Anh],  [SoLuongCo], [GiaHT], [MoTa], [MaDM]) VALUES (N'142', N'Sữa Tươi Tiệt Trùng', N'20.jpg', 1122, 3100, N'Bảo quản ở nhiệt độ vừa đủ giúp cho sữa được tươi mát trong lành đảm bảo an toàn giúp tăng sức đề kháng, dẻo dai...', N'dm05')
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
select * from SanPham
CREATE TABLE [HoaDon](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[TenTK] [nvarchar](100) NULL,
	[DiaChiNhan] [nvarchar](255) NOT NULL,
	[SoLuongMua] [int] NOT NULL,
	[DonGia] [int] NOT NULL,
	[Sodienthoai] [nvarchar](100) NOT NULL,
	[ThanhTien] [nvarchar](100) NOT NULL,
	
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
select * from HoaDon
CREATE TABLE [GioHang](
	[MaGH] [int] IDENTITY(1,1) NOT NULL,
	[MaSP] [nvarchar](20) NOT NULL,
	[MaHD] [int] NOT NULL,
	[SoLuongMua] [int] NOT NULL,
	[Tensanpham] [nvarchar](100) NULL,
	[DonGia] [int] NOT NULL,
	[ThanhTien] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGH] ASC,
	[MaSP] ASC,
	[MaHD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_DanhMuc1] FOREIGN KEY([MaDM])
REFERENCES [DanhMuc] ([MaDM])
GO
ALTER TABLE [SanPham] CHECK CONSTRAINT [FK_SanPham_DanhMuc1]
GO
ALTER TABLE [HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_TaiKhoan] FOREIGN KEY([TenTK])
REFERENCES [TaiKhoan] ([TenTK])
GO
ALTER TABLE [HoaDon] CHECK CONSTRAINT [FK_HoaDon_TaiKhoan]
GO
ALTER TABLE [GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_HoaDon] FOREIGN KEY([MaHD])
REFERENCES [HoaDon] ([MaHD])
GO
ALTER TABLE [GioHang] CHECK CONSTRAINT [FK_GioHang_HoaDon]
GO
ALTER TABLE [GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_SanPham] FOREIGN KEY([MaSP])
REFERENCES [SanPham] ([MaSP])
GO
ALTER TABLE [GioHang] CHECK CONSTRAINT [FK_GioHang_SanPham]
GO

select * from DanhMuc
select * from GioHang
select * from HoaDon
select * from SanPham
select * from TaiKhoan
select Anh from SanPham where MaSP=122

