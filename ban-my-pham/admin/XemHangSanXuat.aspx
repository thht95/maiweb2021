<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="XemHangSanXuat.aspx.cs" Inherits="ban_my_pham.admin.XemHangSanXuat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Xem thông tin hãng sản xuất</h2>
    <div class="form-group">
        <label for="txtTenHangSanXuat" class="label">Tên hãng sản xuất</label>
        <input runat="server" class="form-control" type="text" id="txtTenHangSanXuat" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="txtDiaChi" class="label">Địa chỉ</label>
        <input runat="server" class="form-control" type="text" id="txtDiaChi" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="txtSdt" class="label">Số điện thoại</label>
        <input runat="server" class="form-control" type="text" id="txtSdt" disabled="disabled" />
    </div>
    <div class="center-children">
        <a href="/admin/DanhSachHangSanXuat.aspx" class="button-xanhduong">Quay lại</a>
    </div>
</asp:Content>
