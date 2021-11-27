<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="XemUser.aspx.cs" Inherits="ban_my_pham.admin.XemUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Thông tin user</h2>
    <div class="form-group">
        <label for="tenDangNhap" class="label">Tên đăng nhập</label>
        <input runat="server" class="form-control" type="text" id="tenDangNhap"  disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="hoten" class="label">Họ tên</label>
        <input runat="server" class="form-control" type="text" id="hoten" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="ngaysinh" class="label">Ngày sinh</label>
        <input runat="server" class="form-control" type="date" id="ngaysinh" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="diachi" class="label">Địa chỉ</label>
        <input runat="server" class="form-control" type="text" id="diachi" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="sdt" class="label">Số điện thoại</label>
        <input runat="server" class="form-control" type="text" id="sdt" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="email" class="label">Email</label>
        <input runat="server" class="form-control" type="text" id="email" disabled="disabled" />
    </div>
    <div class="form-group">
        <label for="ddlRole" class="label">Role</label>
         <input runat="server" class="form-control" type="text" id="txtRole" disabled="disabled" />
    </div>
    <div class="center-children">
        <a class="button-xanhduong" href="/admin/DanhSachUser.aspx" >Quay lại</a>
    </div>
    </div>
</asp:Content>
