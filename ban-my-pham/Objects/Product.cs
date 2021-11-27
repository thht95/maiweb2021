using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ban_my_pham
{
    public class Product
    {
        public int maSanPham { get; set; }
        public int maNguoiTao { get; set; }
        public int maHangSanXuat { get; set; }
        public int maLoaiSanPham { get; set; }
        public string tenSanPham { get; set; }
        public DateTime ngaySanXuat { get; set; }
        public string xuatXu { get; set; }
        public string duongDanAnh { get; set; }
        public float giaBan { get; set; }
        public float phanTramGiamGia { get; set; }
        public int soLuong { get; set; }
        public string moTaNgan { get; set; }
        public string moTaChiTiet { get; set; }
        public string tenHangSanXuat { get; set; }
        public Product() { }

        public Product(int maSanPham, int maNguoiTao, int maHangSanXuat, int maLoaiSanPham, string tenSanPham, DateTime ngaySanXuat, string xuatXu, string duongDanAnh, float giaBan, float phanTramGiamGia, int soLuong, string moTaNgan, string moTaChiTiet, string tenHangSanXuat)
        {
            this.maSanPham = maSanPham;
            this.maNguoiTao = maNguoiTao;
            this.maHangSanXuat = maHangSanXuat;
            this.maLoaiSanPham = maLoaiSanPham;
            this.tenSanPham = tenSanPham;
            this.ngaySanXuat = ngaySanXuat;
            this.xuatXu = xuatXu;
            this.duongDanAnh = duongDanAnh;
            this.giaBan = giaBan;
            this.phanTramGiamGia = phanTramGiamGia;
            this.soLuong = soLuong;
            this.moTaChiTiet = moTaChiTiet;
            this.moTaNgan = moTaNgan;
            this.tenHangSanXuat = tenHangSanXuat;
        }

    }

    public class SanPhamGioHang
    {
        public Product sanPham { get; set; }
        public int soLuong { get; set; }

        public SanPhamGioHang() { }

        public SanPhamGioHang(int soLuong, Product sanPham)
        {
            this.soLuong = soLuong;
            this.sanPham = sanPham;
        }
    }
}