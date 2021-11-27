USE BanMyPham
GO
--các thủ tục liên quan tới bảng tblLoaisanpham 

CREATE PROC sp_GetLoaiSanPhamTheoId @iLoaisanphamid INT
AS
BEGIN
	SELECT * FROM tblLoaisanpham WHERE iLoaisanphamid = @iLoaisanphamid
END
GO

CREATE PROC sp_GetAllLoaiSanPham
AS
BEGIN
	SELECT * FROM tblLoaisanpham
END
GO

CREATE PROC sp_checkTenLoaiSanPham @sTenloaisanpham NVARCHAR(255)
AS
BEGIN
	SELECT * FROM tblLoaisanpham WHERE sTenloaisanpham = @sTenloaisanpham
END
GO
CREATE PROC sp_checkTenLoaiSanPhamVoiId @iLoaisanphamid INT,  @sTenLoaisanpham NVARCHAR(255) 
AS
BEGIN
	SELECT * FROM tblLoaisanpham WHERE sTenloaisanpham = @sTenLoaisanpham AND iLoaisanphamid <> @iLoaisanphamid
END
GO

CREATE PROC sp_ThemLoaiSanPham @sTenloaisanpham NVARCHAR(255)
AS
BEGIN
	INSERT INTO tblLoaisanpham(sTenloaisanpham)
	VALUES (@sTenloaisanpham)
END
GO

CREATE PROC sp_SuaLoaiSanPham @iLoaisanphamid INT, @sTenloaisanpham NVARCHAR(255)
AS
BEGIN
	UPDATE tblLoaisanpham
	SET sTenloaisanpham = @sTenloaisanpham 
	WHERE iLoaisanphamid = @iLoaisanphamid
END
GO

-- Các thủ tục liên quan tới bảng mã giảm giá
-- lấy tất cả mã giảm giá
CREATE PROC sp_GetALLMaGiamGia
AS
BEGIN
	SELECT * FROM tblMagiamgia
END
GO

-- lấy mã giảm giá theo id
CREATE PROC sp_GetMaGiamGiaTheoId
@id INT
AS
BEGIN
	SELECT * FROM tblMagiamgia WHERE iMagiamgiaid = @id
END
GO

-- tìm mã giảm giá theo mã giảm giá
CREATE PROC sp_GetMaGiamGiaTheoMa
@maGiamGia NVARCHAR(255)
AS
BEGIN
	SELECT * FROM tblMagiamgia WHERE sMagiamgia = @maGiamGia
END
GO

-- tìm mã giảm giá theo tên và id không giống
CREATE PROC sp_GetMaGiamGiaTheoMaVaId
@id INT, 
@maGiamGia NVARCHAR(255)
AS
BEGIN
	SELECT * FROM tblMagiamgia WHERE sMagiamgia = @maGiamGia AND iMagiamgiaid <> @id
END
GO
-- thêm mã giảm giá
CREATE PROC sp_ThemMaGiamGia
@maGiamGia NVARCHAR(255),
@iNguoitao INT,
@phanTramGiam FLOAT,
@dNgaybatdau DATETIME,
@dNgayketthuc DATETIME
AS
BEGIN
	INSERT INTO tblMagiamgia(sMagiamgia, iNguoitao, fPhantramgiam, dThoigianbatdau, dThoigianketthuc)
	VALUES (@maGiamGia, @iNguoitao, @phanTramGiam, @dNgaybatdau, @dNgayketthuc)
END
GO
-- sửa mã giảm giá
CREATE PROC sp_SuaMaGiamGia
@id INT, 
@maGiamGia NVARCHAR(255),
@phanTramGiam FLOAT,
@dNgaybatdau DATETIME,
@dNgayketthuc DATETIME
AS
BEGIN
	UPDATE tblMagiamgia
	SET sMagiamgia = @maGiamGia, fPhantramgiam = @phanTramGiam,
	dThoigianbatdau = @dNgaybatdau,  dThoigianketthuc = @dNgayketthuc
	WHERE iMagiamgiaid = @id
END
GO
-- các thủ tục liên quan tới bản hãng sản xuất
-- lấy toàn bộ hãng sản xuất
CREATE PROC sp_GetAllHangSanXuat
AS
BEGIN
	SELECT * FROM tblHangsanxuat
END
GO
-- lấy hãng sản xuất theo id
CREATE PROC sp_GetHangSanXuatTheoId
@id INT
AS
BEGIN
	SELECT * FROM tblHangsanxuat WHERE iHangsanxuatid = @id
END
GO
-- lấy hãng sản xuất theo tên hãng
CREATE PROC sp_GetHangSanXuatTheoTenHang
@tenHang NVARCHAR(255)
AS
BEGIN
	SELECT * FROM tblHangsanxuat WHERE sTenhang = @tenHang
END
GO
-- lấy hãng sản xuất theo tên hãng và id không giống
CREATE PROC sp_GetHangSanXuatTheoTenHangAndIdNot
@id INT,
@tenHang NVARCHAR(255)
AS
BEGIN
	SELECT * FROM tblHangsanxuat WHERE sTenhang = @tenHang AND iHangsanxuatid <> @id
END
GO
-- thêm mới hãng sản xuất
CREATE PROC sp_ThemHangSanXuat
@tenHang NVARCHAR(255),
@diaChi NVARCHAR(255),
@sdt NVARCHAR(10)
AS
BEGIN
	INSERT INTO tblHangsanxuat(sTenhang, sDiachi, sSdt)
	VALUES (@tenHang, @diaChi, @sdt)
END
GO
-- sửa hãng sản xuất
CREATE PROC sp_SuaHangSanXuat
@id INT,
@tenHang NVARCHAR(255),
@diaChi NVARCHAR(255),
@sdt NVARCHAR(10)
AS
BEGIN
	UPDATE tblHangsanxuat
	SET sTenhang = @tenHang, sDiachi = @diaChi, sSdt = @sdt
	WHERE iHangsanxuatid = @id
END
GO

-- proc liên quan tới sản phẩm
-- Lấy sản phẩm theo id
CREATE PROC sp_GetSanPhamTheoId
@id INT
AS
BEGIN
	SELECT * FROM tblSanpham WHERE iSanphamid = @id
END
GO
-- Lấy sản phẩm theo tên sản phẩm
CREATE PROC sp_GetSanPhamTheoTen
@tenSanPham NVARCHAR(255)
AS
BEGIN
	SELECT * FROM tblSanpham WHERE sTensanpham = @tenSanPham
END
GO
-- lấy sản phẩm thên sản phẩm và id không giống
CREATE PROC sp_GetSanPhamTheoTenAndIdNot
@id INT,
@tenSanPham NVARCHAR(255)
AS
BEGIN
	SELECT * FROM tblSanpham WHERE sTensanpham = @tenSanPham AND iSanphamid <> @id
END
GO
-- Tìm kiếm sản phẩm
CREATE PROC sp_TimKiemSanPham
@sTenSanPham NVARCHAR(255),
@iLimit INT
AS
BEGIN
IF (@iLimit = 0)
BEGIN
	SELECT * FROM tblSanpham sp, tblHangsanxuat hsx
	WHERE UPPER(sp.sTensanpham) LIKE '%' + @sTenSanPham + '%' AND sp.iHangSanphamid = hsx.iHangsanxuatid
END
ELSE
BEGIN
	SELECT TOP (@iLimit) * FROM tblSanpham sp, tblHangsanxuat hsx
	WHERE UPPER(sp.sTensanpham) LIKE '%' + @sTenSanPham + '%' AND sp.iHangSanphamid = hsx.iHangsanxuatid
END

END
GO

-- lịch sử mua hàng
-- thêm lịch sử mua hàng
CREATE PROC sp_ThemLichSuMuaHang
    @iNguoimuaid INT,
	@dNgaymua DATETIME,
	@fTongtien FLOAT,
    @NewId int OUTPUT
AS
BEGIN
    INSERT INTO tblMuahang(iNguoimuaid, dNgaymua, fTongtien)
    VALUES (@iNguoimuaid, @dNgaymua, @fTongtien)
    SELECT @NewId = SCOPE_IDENTITY()
END
GO
-- lấy lịch sử mua hàng theo id người mua
CREATE PROC sp_GetLichSuMuaHang
	@iNguoimuaid INT
AS
BEGIN
	SELECT * FROM tblMuahang WHERE iNguoimuaid = @iNguoimuaid
END
GO
-- thêm chi tiết mua hàng
CREATE PROC sp_ThemChiTietMuaHang
@iMuahangid INT,
@iSanphamid INT,
@iSoluongmua INT,
@mDongia MONEY
AS
BEGIN
	INSERT INTO tblChitietmuahang(iMuahangid, iSanphamid, iSoluongmua, mDongia)
	VALUES (@iMuahangid, @iSanphamid, @iSoluongmua, @mDongia)
END
GO
-- lấy chi tiết mua hàng theo id lịch sử mua hàng
CREATE PROC sp_GetChiTietMuaHang
@iMuahangid INT
AS
BEGIN
	SELECT * FROM tblChitietmuahang WHERE iMuahangid = @iMuahangid
END
GO
------------
drop proc sp_TimKiemtheogb
CREATE PROC sp_TimKiemtheogb
@mGiaban MONEY,
@tugia MONEY ,
@dengia MONEY,
@iLimit INT
AS
BEGIN
IF (@iLimit = 0)
BEGIN
	SELECT * FROM tblSanpham sp, tblLoaisanpham lsp
	where sp.iLoaisanphamid = lsp.iLoaisanphamid AND (@tugia <= mGiaban) AND (mGiaban <= @dengia)
END
ELSE
BEGIN
	SELECT TOP (@iLimit) * FROM tblSanpham sp, iLoaisanphamid lsp
	where sp.iLoaisanphamid = hsx.iLoaisanphamid AND (@tugia <= mGiaban) AND (mGiaban <= @dengia)
END

END