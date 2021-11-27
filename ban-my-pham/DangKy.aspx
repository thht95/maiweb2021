<%@ Page Title="Đăng ký" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="ban_my_pham.DangKy" %>

<asp:Content ID="Content2" ContentPlaceHolderID="css" runat="server">
    <link href="css/dang-ky.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 style="text-align: center">ĐĂNG KÝ</h2>
        <div class="form-group">
            <label class="label"></label>
            <div class="form-control">
                <asp:ValidationSummary ValidationGroup="ServerError" HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary2" runat="server" />
                <asp:CustomValidator ValidationGroup="ServerError" ID="CustomValidator1" runat="server" ValidateEmptyText="true" Display="None"></asp:CustomValidator>

                <asp:ValidationSummary HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary1" runat="server" />
                <asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ErrorMessage="Số điện thoại chỉ được là số" Display="None" ControlToValidate="sdt" ValidationExpression = "^[0-9]*$"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Mật khẩu phải lớn hơn 3 ký tự" Display="None" ControlToValidate="matkhau" ValidationExpression = "^[\s\S]{3,}$"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ValidationExpression="\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*" Display="None" ErrorMessage="Email không đúng định dạng" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="None" ControlToValidate="email" ErrorMessage="Email không được bỏ trống."></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None" ControlToValidate="sdt" ErrorMessage="Số điện thoại không được bỏ trống."></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="diachi" ErrorMessage="Địa chỉ không được bỏ trống."></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="None" ControlToValidate="ngaysinh" ErrorMessage="Ngày sinh không được bỏ trống."></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="hoten" ErrorMessage="Họ tên không được bỏ trống."></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="tenDangNhap" ErrorMessage="Tên đăng nhập không được bỏ trống."></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="matKhau" ErrorMessage="Mật khẩu không được bỏ trống."></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <label for="tenDangNhap" class="label">Tên đăng nhập</label>
            <input runat="server" class="form-control" type="text" id="tenDangNhap" placeholder="Nhập tên đăng nhập" />
        </div>
        <div class="form-group">
            <label for="matKhau" class="label">Mật khẩu</label>
            <input runat="server" class="form-control" type="password" id="matKhau" placeholder="Nhập mật khẩu" />
        </div>
        <div class="form-group">
            <label for="hoten" class="label">Họ tên</label>
            <input runat="server" class="form-control" type="text" id="hoten" placeholder="Nhập họ tên" />
        </div>
        <div class="form-group">
            <label for="ngaysinh" class="label">Ngày sinh</label>
            <input runat="server" class="form-control" type="date" id="ngaysinh" />
        </div>
        <div class="form-group">
            <label for="diachi" class="label">Địa chỉ</label>
            <input runat="server" class="form-control" type="text" id="diachi" placeholder="Nhập địa chỉ" />
        </div>
        <div class="form-group">
            <label for="sdt" class="label">Số điện thoại</label>
            <input runat="server" class="form-control" type="text" id="sdt" placeholder="Nhập số điện thoại" />
        </div>
        <div class="form-group">
            <label for="email" class="label">Email</label>
            <input runat="server" class="form-control" type="text" id="email" placeholder="Nhập email" />
        </div>
        <div class="center-children">
            <asp:Button CssClass="button" ID="Button1" runat="server" Text="Đăng ký 2" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
