USE BanMyPham
--Quyen
EXEC AddRole @sTenQuyen = N'ADMIN'
EXEC AddRole @sTenQuyen = N'USER'

--User
EXEC AddUser @iQuyenid = 1, @sHoten = N'Annie Shop', @dNgaySinh = '2001-09-11', @sDiachi = N'Hà Nội', @sSdt = '0434343434', @sEmail=N'admin@annieshop.com', @sTaiKhoan=N'admin', @sMatKhau=N'admin'
EXEC AddUser @iQuyenid = 2, @sHoten = N'Nguyễn Thị Mai Anh', @dNgaySinh = '1999-08-24', @sDiachi = N'Phú Thọ', @sSdt = '0364324543', @sEmail=N'maianh24081999@gmail.com', @sTaiKhoan=N'maianh', @sMatKhau=N'maianh'
EXEC AddUser @iQuyenid = 2, @sHoten = N'Đinh Công Sơn', @dNgaySinh = '1999-01-01', @sDiachi = N'Hà Nội', @sSdt = '0345671324', @sEmail=N'annie@gmail.com', @sTaiKhoan=N'sondc', @sMatKhau=N'sondc'
EXEC AddUser @iQuyenid = 2, @sHoten = N'Nguyễn Đức Thắng', @dNgaySinh = '1999-01-02', @sDiachi = N'Hà Nội', @sSdt = '0343332324', @sEmail=N'thangnd@gmail.com', @sTaiKhoan=N'thangnd', @sMatKhau=N'thangnd'

--Loai san pham
EXEC sp_ThemLoaiSanPham N'Son môi'
EXEC sp_ThemLoaiSanPham N'Cọ trang điểm'
EXEC sp_ThemLoaiSanPham N'Sữa tắm'
EXEC sp_ThemLoaiSanPham N'Dưỡng da'
EXEC sp_ThemLoaiSanPham N'Bộ trang điểm mắt'

--Hãng sản xuất
EXEC sp_ThemHangSanXuat @tenhang=N'Hãng 1', @DiaChi=N'Việt Nam', @Sdt='0123456780'
EXEC sp_ThemHangSanXuat @tenhang=N'Hãng 2', @DiaChi=N'Trung Quốc', @Sdt='0987654211'

--Sản phẩm
EXEC ThemSanPham @iNguoitao=1, @iHangsanphamid=1, @iLoaisanphamid=1, @fPhantramgiamgia=10, @dNgaysanxuat='2019-10-11', @sTensanpham=N'Son Ba Màu Maybelline Bitten 3.9g', @sXuatxu=N'Việt Nam', @sImageurl='', @mGiaban=1000000, @iSoluong=10, @sMotangan=N'Son môi', @sThongtinchitiet=N'Son Ba Màu Maybelline Bitten 3.9g'
EXEC ThemSanPham @iNguoitao=1, @iHangsanphamid=2, @iLoaisanphamid=2, @fPhantramgiamgia=15, @dNgaysanxuat='2020-10-11', @sTensanpham=N'Cọ má hồng Etude House My Beauty Tool Brush', @sXuatxu=N'Việt Nam', @sImageurl='', @mGiaban=1000000, @iSoluong=10, @sMotangan=N'Cọ má hồng', @sThongtinchitiet=N'ọ má hồng Etude House My Beauty Tool Brush'
EXEC ThemSanPham @iNguoitao=1, @iHangsanphamid=2, @iLoaisanphamid=3, @fPhantramgiamgia=12, @dNgaysanxuat='2019-12-11', @sTensanpham=N'Sữa tắm dạng kem Victoria’s Secret', @sXuatxu=N'Việt Nam', @sImageurl='', @mGiaban=1000000, @iSoluong=10, @sMotangan=N'Sữa tắm', @sThongtinchitiet=N'Sữa tắm dạng kem Victoria’s Secret'
EXEC ThemSanPham @iNguoitao=1, @iHangsanphamid=1, @iLoaisanphamid=4, @fPhantramgiamgia=5, @dNgaysanxuat='2020-05-11', @sTensanpham=N'Dầu dưỡng da Phytoceuticals Argan', @sXuatxu=N'Việt Nam', @sImageurl='', @mGiaban=1000000, @iSoluong=10, @sMotangan=N'Dầu dưỡng da', @sThongtinchitiet=N'Dầu dưỡng da Phytoceuticals Argan'
EXEC ThemSanPham @iNguoitao=1, @iHangsanphamid=1, @iLoaisanphamid=5, @fPhantramgiamgia=10, @dNgaysanxuat='2019-01-11', @sTensanpham=N'Mascara Benefit They are Real', @sXuatxu=N'Việt Nam', @sImageurl='', @mGiaban=1000000, @iSoluong=10, @sMotangan=N'Mascara', @sThongtinchitiet=N'Mascara Benefit They are Real'
EXEC ThemSanPham @iNguoitao=1, @iHangsanphamid=2, @iLoaisanphamid=1, @fPhantramgiamgia=5, @dNgaysanxuat='2019-09-11', @sTensanpham=N'Son Christian Louboutin Diva', @sXuatxu=N'Việt Nam', @sImageurl='', @mGiaban=1000000, @iSoluong=10, @sMotangan=N'Son môi', @sThongtinchitiet=N'Son Christian Louboutin Diva'
EXEC ThemSanPham @iNguoitao=1, @iHangsanphamid=1, @iLoaisanphamid=1, @fPhantramgiamgia=10, @dNgaysanxuat='2019-12-11', @sTensanpham=N'Son dưỡng Tonymoly Mini Cherry', @sXuatxu=N'Việt Nam', @sImageurl='', @mGiaban=1000000, @iSoluong=10, @sMotangan=N'Son dưỡng', @sThongtinchitiet=N'Son dưỡng Tonymoly Mini Cherry'


--Mã giảm giá
EXEC sp_ThemMaGiamGia @iNguoitaoid= 1, @maGiamGia='CODE1', @phanTramGiam=25, @dNgaybatdau='2020-10-11', @dNgayketthuc='2020-11-11'
EXEC sp_ThemMaGiamGia @iNguoitaoid= 1,@maGiamGia='CODE2', @phanTramGiam=30, @dNgaybatdau='2020-10-11', @dNgayketthuc='2020-11-11'
EXEC sp_ThemMaGiamGia @iNguoitaoid= 1,@maGiamGia='CODE3', @phanTramGiam=50, @dNgaybatdau='2020-10-11', @dNgayketthuc='2020-11-11'
EXEC sp_ThemMaGiamGia @iNguoitaoid= 1,@maGiamGia='CODE4', @phanTramGiam=80, @dNgaybatdau='2020-10-11', @dNgayketthuc='2020-11-11'
