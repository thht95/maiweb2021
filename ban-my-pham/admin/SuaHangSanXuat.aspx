<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="SuaHangSanXuat.aspx.cs" Inherits="ban_my_pham.admin.SuaHangSanXuat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Sửa thông tin hãng sản xuất</h2>
    <div class="form-group">
        <label class="label"></label>
        <div class="form-control">
            <asp:ValidationSummary ValidationGroup="ServerError" HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary2" runat="server" />
            <asp:CustomValidator ValidationGroup="ServerError" ID="CustomValidator1" runat="server" ValidateEmptyText="true" Display="None"></asp:CustomValidator>
            <asp:ValidationSummary HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary1" runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Số điện thoại chỉ được là số" Display="None" ControlToValidate="txtSdt" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtTenHangSanXuat" ErrorMessage="Tên hãng không được để trống"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None" ControlToValidate="txtSdt" ErrorMessage="Số điện thoại không được bỏ trống."></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtDiaChi" ErrorMessage="Địa chỉ không được bỏ trống."></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label for="txtTenHangSanXuat" class="label">Tên hãng sản xuất</label>
        <input runat="server" class="form-control" type="text" id="txtTenHangSanXuat" placeholder="Nhập tên hãng sản xuất" />
    </div>
    <div class="form-group">
        <label for="txtDiaChi" class="label">Địa chỉ</label>
        <input runat="server" class="form-control" type="text" id="txtDiaChi" placeholder="Nhập địa chỉ" />
    </div>
    <div class="form-group">
        <label for="txtSdt" class="label">Số điện thoại</label>
        <input runat="server" class="form-control" type="text" id="txtSdt" placeholder="Nhập số điện thoại" />
    </div>
    <div class="center-children">
        <asp:Button CssClass="button" ID="Button1" runat="server" Text="Sửa" />
        <button class="button-xanhduong" style="margin-left: 5px;" onclick="return back();">Quay lại</button>
    </div>
    <script>
        function back() {
            location.href = '/admin/DanhSachHangSanXuat.aspx';
            return false;
        }
    </script>
</asp:Content>
