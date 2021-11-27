function xemChiTiet(maGiamGiaId) {
    location.href = '/admin/XemMaGiamGia.aspx?id=' + maGiamGiaId;
}

function sua(maGiamGiaId) {
    location.href = '/admin/SuaMaGiamGia.aspx?id=' + maGiamGiaId;
}

function xoa(maGiamGiaId) {
    if (confirm("Bạn có chắc chắn muốn xóa?")) {
        location.href = '/admin/XoaMaGiamGia.aspx?id=' + maGiamGiaId;
    }
}