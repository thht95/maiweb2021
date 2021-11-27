<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="XemSanPham.aspx.cs" Inherits="ban_my_pham.admin.XemSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Xem thông tin chi tiết sản phẩm</h2>
    <div class="form-group">
        <label for="txtThuongHieu" class="label">Thương hiệu</label>
         <input runat="server" class="form-control" type="text" id="txtThuongHieu" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="txtLoaiSanPham" class="label">Loại sản phẩm</label>
        <input runat="server" class="form-control" type="text" id="txtLoaiSanPham" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="txtTenSanPham" class="label">Tên sản phẩm</label>
        <input runat="server" class="form-control" type="text" id="txtTenSanPham" disabled="disabled" />
    </div>

    <div class="form-group">
        <label for="txtXuatXu" class="label">Xuất xứ</label>
        <input runat="server" class="form-control" type="text" id="txtXuatXu" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="txtNgaySanXuat" class="label">Ngày sản xuất</label>
        <input runat="server" class="form-control" type="date" id="txtNgaySanXuat" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="txtGiaBan" class="label">Giá bán</label>
        <input runat="server" class="form-control" type="text" id="txtGiaBan" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="txtPhanTramGiamGia" class="label">Phần trăm giảm giá</label>
        <input runat="server" class="form-control" type="number" step="any" id="txtPhanTramGiamGia" value="1" min="0" max="100" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="txtSoLuong" class="label">Số lượng</label>
        <input runat="server" class="form-control" type="number" id="txtSoLuong" value="1" min="0" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="txtMoTaNgan" class="label">Mô tả ngắn</label>
        <input runat="server" class="form-control" type="text" id="txtMoTaNgan" placeholder="Nhập mô tả ngắn của sản phẩm" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="txtThongTinChiTiet" class="label">Thông tin chi tiết</label>
        <textarea rows="5" runat="server" id="txtThongTinChiTiet" disabled="disabled"></textarea>
    </div>
    <div class="form-group">
        <label class="label">Ảnh sản phẩm</label>
        <div class="form-control">
            <img runat="server" id="view_image" style="border: 1px solid #e5e6ec; width: 200px; height: 200px;" />
        </div>
    </div>
    <div class="center-children">
        <a href="/admin/DanhSachSanPham.aspx" class="button-xanhduong">Quay lại</a>
    </div>
    <script type="text/javascript" src="../js/admin/san-pham.js"></script>
</asp:Content>
