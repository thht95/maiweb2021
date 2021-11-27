<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ban_my_pham.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
    <link href="css/change-password.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 style="text-align: center">ĐỔI MẬT KHẨU</h2>
        <div class="info-box">
            <div class="form-group">
                <label class="label"></label>
                <div class="form-control">
                    <asp:ValidationSummary ValidationGroup="ServerError" HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary2" runat="server" />
                    <asp:CustomValidator ValidationGroup="ServerError" ID="CustomValidator1" runat="server" ValidateEmptyText="true" Display="None"></asp:CustomValidator>
                    <asp:ValidationSummary HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary1" runat="server" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Mật khẩu phải lớn hơn 3 ký tự" Display="None" ControlToValidate="matkhaumoi" ValidationExpression="^[\s\S]{3,}$"></asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="matkhaumoi" ControlToValidate="nhaplai" ErrorMessage="Mật khẩu nhập lại không khớp"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="matkhaucu" ErrorMessage="Mật khẩu cũ không được bỏ trống."></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="matkhaumoi" ErrorMessage="Mật khẩu mới không được bỏ trống."></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="nhaplai" ErrorMessage="Trường nhập lại mật khẩu không được bỏ trống."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="matkhaucu" class="label">Mật khẩu cũ</label>
                <input runat="server" class="form-control" type="text" id="matkhaucu" placeholder="Nhập mật khẩu cũ" />
            </div>
            <div class="form-group">
                <label for="matkhaumoi" class="label">Mật khẩu mới</label>
                <input runat="server" class="form-control" type="text" id="matkhaumoi" placeholder="Nhập mật khẩu mới" />
            </div>
            <div class="form-group">
                <label for="nhaplai" class="label">Nhập lại mật khẩu</label>
                <input runat="server" class="form-control" type="text" id="nhaplai" placeholder="Nhập lại mật khẩu mới" />
            </div>
            <div class="center-children">
                <asp:Button CssClass="button" ID="Button2" runat="server" Text="Đổi mật khẩu" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
