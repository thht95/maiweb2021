function xemChiTiet(loaiSanPhamId) {
    location.href = '/admin/XemLoaiSanPham.aspx?id=' + loaiSanPhamId;
}

function sua(loaiSanPhamId) {
    location.href = '/admin/SuaLoaiSanPham.aspx?id=' + loaiSanPhamId;
}

function xoa(loaiSanPhamId) {
    if (confirm("Bạn có chắc chắn muốn xóa?")) {
        location.href = '/admin/XoaLoaiSanPham.aspx?id=' + loaiSanPhamId;
    }
}