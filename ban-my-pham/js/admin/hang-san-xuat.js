function xemChiTiet(hangSanXuatId) {
    location.href = '/admin/XemHangSanXuat.aspx?id=' + hangSanXuatId;
}

function sua(hangSanXuatId) {
    location.href = '/admin/SuaHangSanXuat.aspx?id=' + hangSanXuatId;
}

function xoa(hangSanXuatId) {
    if (confirm("Bạn có chắc chắn muốn xóa?")) {
        location.href = '/admin/XoaHangSanXuat.aspx?id=' + hangSanXuatId;
    }
}