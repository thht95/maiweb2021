function view_image(event) {
    var reader = new FileReader();
    reader.onload = function () {
        document.getElementById('ContentPlaceHolder1_view_image').src = reader.result;
    }
    reader.readAsDataURL(event.target.files[0]);
}

function xemChiTiet(sanPhamId) {
    location.href = '/admin/XemSanPham.aspx?id=' + sanPhamId;
}

function sua(sanPhamId) {
    location.href = '/admin/SuaSanPham.aspx?id=' + sanPhamId;
}

function xoa(sanPhamId) {
    if (confirm("Bạn có chắc chắn muốn xóa?")) {
        location.href = '/admin/XoaSanPham.aspx?id=' + sanPhamId;
    }
}