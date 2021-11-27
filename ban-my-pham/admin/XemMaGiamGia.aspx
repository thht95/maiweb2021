<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="XemMaGiamGia.aspx.cs" Inherits="ban_my_pham.admin.XemMaGiamGia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Chi tiết mã giảm giá</h2>
    <div class="form-group">
        <label for="maGiamGia" class="label">Mã giảm giá</label>
        <input runat="server" class="form-control" type="text" id="txtMaGiamGia" disabled="disabled" />
    </div>

    <div class="form-group">
        <label for="phanTramGiamGia" class="label">Phần trăm giảm giá</label>
        <input runat="server" class="form-control" type="number" step="any" id="txtPhanTramGiamGia" value="1" disabled="disabled" />
    </div>
        <div class="form-group">
        <label for="txtNgayBatDau" class="label">Ngày bắt đầu</label>
        <input runat="server" class="form-control" type="date" id="txtNgayBatDau" />
    </div>

    <div class="form-group">
        <label for="txtNgayKetThuc" class="label">Ngày kết thúc</label>
        <input runat="server" class="form-control" type="date" id="txtNgayKetThuc" />
    </div>
    <div class="center-children">
        <a href="/admin/DanhSachMaGiamGia.aspx" class="button-xanhduong">Quay lại</a>
    </div>
</asp:Content>
