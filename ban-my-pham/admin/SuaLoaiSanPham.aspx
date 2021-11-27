<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="SuaLoaiSanPham.aspx.cs" Inherits="ban_my_pham.admin.SuaLoaiSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Sửa loại sản phẩm</h2>
        <div class="form-group">
            <label class="label"></label>
            <div class="form-control">
                <asp:ValidationSummary ValidationGroup="ServerError" HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary2" runat="server" />
                <asp:CustomValidator ValidationGroup="ServerError" id="CustomValidator1" runat="server" Display="None" ValidateEmptyText="true"></asp:CustomValidator>
                
                <asp:ValidationSummary HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary1" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="tenLoaiSanPham" ErrorMessage="Vui lòng nhập tên loại sản phẩm."></asp:RequiredFieldValidator>
            </div>
        </div>
        
        <div class="form-group">
            <label for="tenLoaiSanPham" class="label">Tên loại sản phẩm</label>
            <input runat="server" class="form-control" type="text" id="tenLoaiSanPham" placeholder="Nhập tên loại sản phẩm" />
            
        </div>
        <div class="center-children">
            <asp:Button CssClass="button" ID="btnThem" runat="server" Text="Sửa" />
            <button class="button-xanhduong" style="margin-left: 5px;" onclick="return back();">Quay lại</button>
    </div>
    <script>
        function back() {
            location.href = '/admin/DanhSachLoaiSanPham.aspx';
            return false;
        }
    </script>
</asp:Content>
