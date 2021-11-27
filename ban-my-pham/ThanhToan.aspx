<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="ThanhToan.aspx.cs" Inherits="ban_my_pham.ThanhToan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 style="text-align: center">Thông tin thanh toán</h2>
        <div class="form-group">
            <label class="label"></label>
            <div class="form-control">
                <asp:ValidationSummary ValidationGroup="ServerError" HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary2" runat="server" />
                <asp:CustomValidator ValidationGroup="ServerError" ID="CustomValidator1" runat="server" ValidateEmptyText="true" Display="None"></asp:CustomValidator>
                <asp:ValidationSummary HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary1" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Số điện thoại chỉ được là số" Display="None" ControlToValidate="txtSdt" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None" ControlToValidate="txtSdt" ErrorMessage="Số điện thoại không được bỏ trống."></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtDiaChiGiaoHang" ErrorMessage="Địa chỉ không được bỏ trống."></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtHoTen" ErrorMessage="Họ tên không được bỏ trống."></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <label for="hoten" class="label">Họ tên</label>
            <input runat="server" class="form-control" type="text" id="txtHoTen" placeholder="Nhập họ tên" />
        </div>
        <div class="form-group">
            <label for="diachi" class="label">Địa chỉ nhận hàng</label>
            <input runat="server" class="form-control" type="text" id="txtDiaChiGiaoHang" placeholder="Nhập địa chỉ nhận hàng" />
        </div>
        <div class="form-group">
            <label for="sdt" class="label">Số điện thoại</label>
            <input runat="server" class="form-control" type="text" id="txtSdt" placeholder="Nhập số điện thoại" />
        </div>
        <div class="form-group">
            <label for="email" class="label">Hình thức thanh toán</label>
            <div class="form-control">
                <asp:RadioButton ID="rdTienMat" GroupName="rdHinhThucThanhToan" runat="server" Checked="true" />
                Tiền mặt
                <asp:RadioButton ID="rdChuyenKhoan" GroupName="rdHinhThucThanhToan" runat="server" />
                Chuyển khoản
            </div>
        </div>
        <div class="form-group">
            <label for="txtMaGiamGia" class="label">Mã giảm giá</label>
            <div class="form-control"><input runat="server" class="form-control" type="text" id="txtMaGiamGia" placeholder="Nhập mã giảm giá" />
                <asp:Button CssClass="button" ID="Button2" runat="server" Text="Áp dụng" />
            </div>
            
        </div>
        <p style="text-align: right">
            <b>Tổng tiền: <span style="color: red;"><%=String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", tongTien) %></span>
                <%if (giamGia > 0) Response.Write("(Đã giảm " + Math.Round(giamGia, 0) + "%)"); %></b>
        </p>
        <div class="center-children">
            <asp:Button CssClass="button" ID="Button1" runat="server" Name="btnThanhToan" Text="Thanh toán" />
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
