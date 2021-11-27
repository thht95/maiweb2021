document.addEventListener("DOMContentLoaded", function (event) {

    function OnFailed(error) { alert(error.get_message()) }

    var buttonAddToCart = document.getElementById("addToCart");
    var soLuongSanPhamTrongGioHang = document.getElementById("soLuongTrongGioHang");
    buttonAddToCart.addEventListener("click", function () {
        PageMethods.themVaoGio(document.querySelector('#addToCart').dataset.id, function (result) {
            soLuongSanPhamTrongGioHang.innerText = parseInt(soLuongSanPhamTrongGioHang.innerText) + 1;
            alert(result);
        }, OnFailed);
    })
});