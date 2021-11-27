function searchSanPham() {
    var value = document.getElementById("txtSearch").value;
    if (value != null && value.trim().length > 0) {
        location.href = '/TimKiem.aspx?q=' + value.trim();
    }
}