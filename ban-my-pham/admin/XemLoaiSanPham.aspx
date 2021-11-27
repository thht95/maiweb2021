<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="XemLoaiSanPham.aspx.cs" Inherits="ban_my_pham.admin.XemLoaiSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Chi tiết loại sản phẩm</h2>
        <div class="form-group">
            <label for="tenLoaiSanPham" class="label">Tên loại sản phẩm</label>
            <input runat="server" class="form-control" type="text" id="tenLoaiSanPham" placeholder="Nhập tên loại sản phẩm" disabled="disabled" />
            
        </div>
        <div class="center-children">
            <a href="DanhSachLoaiSanPham.aspx" class="button">Quay lại</a>
        </div>
</asp:Content>
