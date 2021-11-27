function xemChiTiet(userId) {
    location.href = '/admin/XemUser.aspx?id=' + userId;
}

function sua(userId) {
    location.href = '/admin/SuaUser.aspx?id=' + userId;
}

function xoa(userId) {
    if (confirm("Bạn có chắc chắn muốn xóa?")) {
        location.href = '/admin/XoaUser.aspx?id=' + userId;
    }
}