<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="SuaMaGiamGia.aspx.cs" Inherits="ban_my_pham.admin.SuaMaGiamGia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Sửa mã giảm giá</h2>
    <div class="form-group">
        <label class="label"></label>
        <div class="form-control">
            <asp:ValidationSummary ValidationGroup="ServerError" HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary2" runat="server" />
            <asp:CustomValidator ValidationGroup="ServerError" ID="CustomValidator1" runat="server" Display="None" ValidateEmptyText="true"></asp:CustomValidator>

            <asp:ValidationSummary HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary1" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtMaGiamGia" ErrorMessage="Vui lòng nhập tên loại sản phẩm."></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtPhanTramGiamGia" ErrorMessage="Vui lòng nhập phần trăm giảm giá."></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtNgayBatDau" ErrorMessage="Vui lòng nhập ngày bắt đầu."></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtNgayKetThuc" ErrorMessage="Vui lòng nhập ngày kết thúc."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None" ErrorMessage="Ngày bắt đầu không được sau ngày kết thúc" Operator="LessThanEqual" Type="Date" ControlToCompare="txtNgayKetThuc" ControlToValidate="txtNgayBatDau"></asp:CompareValidator>
            <asp:RangeValidator ID="RangeValidator1" Display="None" runat="server" ControlToValidate="txtPhanTramGiamGia" ErrorMessage="Phần trăm giảm phải từ 0 tới 100%" MaximumValue="100" MinimumValue="0" Type="Double"></asp:RangeValidator>
        </div>
    </div>

    <div class="form-group">
        <label for="maGiamGia" class="label">Mã giảm giá</label>
        <input runat="server" class="form-control" type="text" id="txtMaGiamGia" placeholder="Nhập mã giảm giá" />
    </div>

    <div class="form-group">
        <label for="txtPhanTramGiamGia" class="label">Phần trăm giảm giá</label>
        <input runat="server" class="form-control" type="number" step="any" id="txtPhanTramGiamGia" />
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
        <asp:Button CssClass="button" ID="btnSua" runat="server" Text="Sửa" />
        <button class="button-xanhduong" style="margin-left: 5px;" onclick="return back();">Quay lại</button>
    </div>
    <script>
        function back() {
            location.href = '/admin/DanhSachMaGiamGia.aspx';
            return false;
        }
    </script>
</asp:Content>
