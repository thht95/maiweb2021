<%@ Page Title="Đăng nhập" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="ban_my_pham.DangNhap" %>

<asp:Content ID="Content2" ContentPlaceHolderID="css" runat="server">
    <link href="css/dang-nhap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="container">
        <h2 style="text-align: center">ĐĂNG NHẬP</h2>
       <%-- <div class="form-group">
            <label class="label"></label>
            <div class="form-control">
                <asp:ValidationSummary ValidationGroup="ServerError" HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary2" runat="server" />
                <asp:CustomValidator ValidationGroup="ServerError" id="CustomValidator1" runat="server" Display="None" ValidateEmptyText="true"></asp:CustomValidator>
                
                <asp:ValidationSummary HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary1" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="tenDangNhap" ErrorMessage="Tên đăng nhập không được bỏ trống."></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="matKhau" ErrorMessage="Mật khẩu không được bỏ trống."></asp:RequiredFieldValidator>
            </div>
        </div>--%>
        
        <div class="form-group">
            <label for="tenDangNhap" class="label">Tên đăng nhập</label>
            <input class="form-control" type="text" id="tenDangNhap" placeholder="Nhập tên đăng nhập" />
            
        </div>
        <div class="form-group">
            <label for="matKhau" class="label">Mật khẩu</label>
            <input class="form-control" type="password" id="matKhau" placeholder="Nhập mật khẩu" />
        </div>
        <div class="center-children">
            <%--<asp:Button CssClass="button" ID="Button1" runat="server" Text="Đăng nhập" />--%>
            <input id="dangNhap" type="button" class="button" style="width: auto" value="Đăng nhập"/>
        </div>
        <div class="form-group">
            <div class="label"></div>
            <span class="form-control">Bạn chưa có tài khoản? <a href="~/DangKy.aspx" runat="server">Đăng ký</a></span>
        </div>
    </div>
    <script>
        document.addEventListener("DOMContentLoaded", function (event) {

            var buttonDangNhap = document.getElementById("dangNhap");
            var tenDangNhap = document.getElementById("tenDangNhap");
            var matKhau = document.getElementById("matKhau");

            buttonDangNhap.addEventListener("click", function () {
                PageMethods.kiemTraDangNhap(tenDangNhap.value, matKhau.value, function (result) {
                    if (result == true) {
                        alert("Đăng nhập thành công");
                        window.location.href = "TrangChu.aspx";
                    } else {
                        alert("Sai tên đăng nhập hoặc mật khẩu");
                    }
                });
            })
        });
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
