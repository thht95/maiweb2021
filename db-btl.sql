
CREATE DATABASE BanMyPham;
GO
USE BanMyPham;

CREATE TABLE tblQuyen (
	iQuyenid INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	sTenquyen NVARCHAR(255) NOT NULL
)
GO
CREATE TABLE tblUser(
	iUserid INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	iQuyenid INT NOT NULL, 
	sHoten NVARCHAR(50) NOT NULL,
	dNgaysinh DATETIME NOT NULL,
	sDiachi NVARCHAR(200) NOT NULL,
	sSdt NVARCHAR(10) NOT NULL,
	sEmail NVARCHAR(255),
	sTaikhoan NVARCHAR (255) NOT NULL,
	sMatkhau NVARCHAR(255) NOT NULL,
	FOREIGN KEY(iQuyenid) REFERENCES tblQuyen(iQuyenid)
)
GO

CREATE TABLE tblHangsanxuat
(
	iHangsanxuatid INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	sTenhang NVARCHAR(255) NOT NULL,
	sDiachi NVARCHAR(255) NOT NULL,
	sSdt NVARCHAR(10) NOT NULL
)
CREATE TABLE tblLoaisanpham
(
	iLoaisanphamid INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	sTenloaisanpham NVARCHAR(255) NOT NULL
)
GO
CREATE TABLE tblSanpham(
	iSanphamid INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	iNguoitao INT NOT NULL,
	dNgaysanxuat DATETIME NOT NULL, 
	iHangsanphamid INT NOT NULL,
	iLoaisanphamid INT NOT NULL,
	sTensanpham NVARCHAR(255) NOT NULL,
	sXuatxu NVARCHAR(255) NOT NULL,
	sImageurl NVARCHAR(255) NOT NULL,
	mGiaban MONEY NOT NULL,
	fPhantramgiamgia FLOAT NOT NULL,
	iSoluong INT NOT NULL,
	sMotangan NVARCHAR(255),
	sThongtinchitiet NVARCHAR(4000),
	FOREIGN KEY (iHangsanphamid) REFERENCES tblHangsanxuat(iHangsanxuatid),
	FOREIGN KEY (iLoaisanphamid) REFERENCES tblLoaisanpham(iLoaisanphamid),
	FOREIGN KEY (iNguoitao) REFERENCES tblUser(iUserid)
)
GO
CREATE TABLE tblMagiamgia(
	iMagiamgiaid INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	iNguoitao INT NOT NULL,
	sMagiamgia NVARCHAR(255) NOT NULL,
	fPhantramgiam FLOAT,
	dThoigianbatdau DATETIME,
	dThoigianketthuc DATETIME,
	FOREIGN KEY (iNguoitao) REFERENCES tblUser(iUserid)
)
GO

CREATE TABLE tblMuahang(
	iMuahangid INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	iNguoimuaid INT NOT NULL,
	dNgaymua DATETIME NOT NULL,
	fTongtien FLOAT
)
GO
CREATE TABLE tblChitietmuahang(
	iMuahangid INT NOT NULL,
	iSanphamid INT NOT NULL,
	iSoluongmua INT NOT NULL,
	mDongia MONEY NOT NULL,
	FOREIGN KEY(iMuahangid) REFERENCES tblMuahang(iMuahangid),
	FOREIGN KEY(iSanphamid) REFERENCES tblSanpham(iSanphamid)
)
GO
--- Create role procedures
CREATE PROC GetAllRole
AS
BEGIN
SELECT * FROM tblQuyen
END
GO

CREATE PROC sp_getRoleById
@roleId INT
AS
BEGIN
SELECT * FROM tblQuyen WHERE iQuyenid = @roleId
END
GO

CREATE PROC GetRoleByName
@sTenQuyen nvarchar(255)
AS
BEGIN
SELECT * FROM tblQuyen WHERE sTenquyen = @sTenQuyen 
END
GO
CREATE PROC AddRole
@sTenQuyen nvarchar(255)
AS
BEGIN
INSERT INTO tblQuyen(sTenQuyen)
VALUES(@sTenQuyen)
END

GO
--- Create user procedures
CREATE PROC GetAllUsers
AS
BEGIN
SELECT * FROM tblUser
END
GO
CREATE PROC AddUser
@iQuyenid int, @sHoTen nvarchar(50), @dNgaySinh datetime, @sDiachi nvarchar(200), @sSdt nvarchar(10), @sEmail nvarchar(255), @sTaiKhoan nvarchar(255), @sMatKhau nvarchar(255)
AS
BEGIN
INSERT INTO tblUser(iQuyenid, sHoten, dNgaysinh, sDiachi, sSdt, sEmail, sTaikhoan, sMatkhau)
VALUES(@iQuyenid, @sHoten, @dNgaysinh, @sDiachi, @sSdt, @sEmail, @sTaiKhoan, @sMatKhau)
END

GO

CREATE PROC UpdateUser
@iUserid int, @iQuyenid int, @sHoTen nvarchar(50), @dNgaySinh datetime, @sDiachi nvarchar(200), @sSdt nvarchar(10), @sEmail nvarchar(255)
AS
BEGIN
UPDATE tblUser
SET iQuyenid = @iQuyenid, sHoten = @sHoten, 
dNgaysinh =@dNgaysinh, sDiachi = @sDiachi, sSdt = @sSdt, sEmail = @sEmail
WHERE iUserid = @iUserid
END
GO

CREATE PROC GetByTaiKhoanAndMatKhau
@sTaiKhoan nvarchar(255), @sMatKhau nvarchar(255)
AS
BEGIN
SELECT iUserid FROM tblUser WHERE sTaikhoan = @sTaiKhoan AND sMatkhau = @sMatKhau
END
GO

CREATE PROC sp_GetUserById @userId INT
AS
BEGIN
	SELECT * FROM tblUser WHERE iUserid = @userId
END

GO

CREATE PROC GetByTaiKhoan
@sTaiKhoan nvarchar(255)
AS
BEGIN
SELECT * FROM tblUser WHERE sTaiKhoan = @sTaiKhoan
END

GO

CREATE PROC sp_getUserByTaiKhoanAndIdNot
@userId INT,
@sTaiKhoan nvarchar(255)
AS
BEGIN
	SELECT * FROM tblUser WHERE sTaiKhoan = @sTaiKhoan AND iUserid <> @userId
END
GO

CREATE PROC GetByEmail
@sEmail nvarchar(255)
AS
BEGIN
SELECT * FROM tblUser WHERE sEmail = @sEmail
END

GO

CREATE PROC sp_getByEmailAndIdNot
@userId INT,
@sEmail nvarchar(255)
AS
BEGIN
SELECT * FROM tblUser WHERE sEmail = @sEmail AND iUserid <> @userId
END

GO

CREATE PROC ChangePassword
@sTaikhoan nvarchar(255), @sMatkhau nvarchar(255)
AS
BEGIN
UPDATE tblUser
SET sMatkhau = @sMatkhau
WHERE sTaiKhoan = @sTaiKhoan
END

GO
-- Create product proc
CREATE PROC ThemSanPham
@iNguoiTao int, @dNgaysanxuat datetime, @fPhantramgiamgia float,
@iHangsanphamid int, @iLoaisanphamid int, @sTensanpham nvarchar(255),
@sXuatxu nvarchar(255), @sImageurl nvarchar(255), @mGiaban money, @iSoluong int,
@sMotangan nvarchar(255), @sThongtinchitiet nvarchar(4000)
AS
BEGIN
INSERT INTO tblSanPham(iNguoitao, dNgaysanxuat, fPhantramgiamgia, iHangsanphamid, iLoaisanphamid, sTensanpham, sXuatxu, sImageurl, mGiaban, iSoluong, sMotangan, sThongtinchitiet)
VALUES (@iNguoitao, @dNgaysanxuat, @fPhantramgiamgia, @iHangsanphamid, @iLoaisanphamid, @sTensanpham, @sXuatxu, @sImageurl, @mGiaban, @iSoluong, @sMotangan, @sThongtinchitiet)
END

GO

CREATE PROC SuaSanPham
@iSanphamid int,  @dNgaysanxuat datetime, @fPhantramgiamgia float,
@iHangsanphamid int, @iLoaisanphamid int,
@sTensanpham nvarchar(255), @sXuatxu nvarchar(255), @sImageurl nvarchar(255),
@mGiaban money, @iSoluong int, @sMotangan nvarchar(255), @sThongtinchitiet nvarchar(4000)
AS
BEGIN
UPDATE tblSanPham
SET iHangsanphamid = @iHangsanphamid, iLoaisanphamid = @iLoaisanphamid, 
dNgaysanxuat = @dNgaysanxuat, fPhantramgiamgia = @fPhantramgiamgia,
sTensanpham = @sTensanpham, sXuatxu = @sXuatxu, sImageurl = @sImageurl, mGiaban = @mGiaban, iSoluong = @iSoluong, sMotangan = @sMotangan, sThongtinchitiet = @sThongtinchitiet
WHERE iSanphamid = @iSanphamid
END

GO

CREATE PROC GetAllSanPham
AS
BEGIN
select * from tblSanpham sp, tblHangsanxuat hsx where sp.iHangSanphamid = hsx.iHangsanxuatid
END

GO

CREATE PROC GetSanPhamById
@iSanphamid int 
AS
BEGIN
select * from tblSanpham sp, tblHangsanxuat hsx
WHERE sp.iSanphamid = @iSanphamid and sp.iHangSanphamid = hsx.iHangsanxuatid
END
GO

CREATE PROC GetSanphamByLoai
@iLoaisanphamid int,
@iLimit INT
AS
BEGIN
IF (@iLimit = 0)
BEGIN
	select * from tblSanpham sp, tblHangsanxuat hsx
	WHERE sp.iLoaisanphamid = @iLoaisanphamid and sp.iHangSanphamid = hsx.iHangsanxuatid
END
ELSE
BEGIN
	select top (@iLimit) * from tblSanpham sp, tblHangsanxuat hsx
WHERE sp.iLoaisanphamid = @iLoaisanphamid and sp.iHangSanphamid = hsx.iHangsanxuatid
END

END
GO

CREATE PROC GetSanPhamMoi
@iLimit INT
AS
BEGIN
IF (@iLimit = 0)
BEGIN
	select * from tblSanpham sp, tblHangsanxuat hsx
	WHERE sp.iHangSanphamid = hsx.iHangsanxuatid
	order by dNgaysanxuat desc
END
ELSE
BEGIN
	select top (@iLimit) * from tblSanpham sp, tblHangsanxuat hsx
	WHERE sp.iHangSanphamid = hsx.iHangsanxuatid
	order by dNgaysanxuat desc
END
END

GO

CREATE PROC GetSanPhamKhuyenMai
@iLimit INT
AS
BEGIN
IF (@iLimit = 0)
BEGIN
	select * from tblSanpham sp, tblHangsanxuat hsx
	where fPhantramgiamgia > 0 and sp.iHangSanphamid = hsx.iHangsanxuatid
	order by fPhantramgiamgia desc
END
ELSE
BEGIN
	select top (@iLimit) * from tblSanpham sp, tblHangsanxuat hsx
	where fPhantramgiamgia > 0 and sp.iHangSanphamid = hsx.iHangsanxuatid
	order by fPhantramgiamgia desc
END
END
GO
