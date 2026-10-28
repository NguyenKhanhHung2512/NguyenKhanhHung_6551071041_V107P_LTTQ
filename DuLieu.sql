CREATE DATABASE DuLieu
GO

USE DuLieu
GO

CREATE TABLE MonHoc(
	MaMonHoc NVARCHAR(10) PRIMARY KEY,
	TenMocHoc nText NOT NULL,
	SoTinChi NVARCHAR(5) NOT NULL,
)

INSERT INTO MonHoc VALUES
('MH001', N'Lập trình C# cơ bản', 3),
('MH002', N'Cơ sở dữ liệu', 4),
('MH003', N'Phân tích thiết kế hệ thống', 3),
('MH004', N'Mạng máy tính', 3),
('MH005', N'Trí tuệ nhân tạo', 3)