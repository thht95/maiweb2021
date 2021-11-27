<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="ban_my_pham.GioHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
    <link href="css/gio-hang.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Giỏ hàng</h1>
        <% if (sanPhamTrongGioHang.Count == 0)
           { %>
        <p>Không có sản phẩm nào trong giỏ!</p>
        <% }
           else
           { %>
        <table>
            <thead>
                <tr>
                    <th>STT</th>
                    <th>Tên sản phẩm</th>
                    <th>Giá bán</th>
                    <th>Chiết khấu</th>
                    <th>Giá sau chiết khấu</th>
                    <th>Số lượng mua</th>
                </tr>
            </thead>
            <tbody>
                <% int i = 0; %>
                <% foreach (ban_my_pham.SanPhamGioHang sp in sanPhamTrongGioHang)
                   { %>
                <% i++; %>
                <tr>
                    <td style="text-align: center"><%=i %></td>
                    <td><a href="ChiTietSanPham.aspx?id=<%=sp.sanPham.maSanPham %>"><%=sp.sanPham.tenSanPham %></a></td>
                    <td style="text-align: center"><%= String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", sp.sanPham.giaBan) %></td>
                    <td style="text-align: center"><%=sp.sanPham.phanTramGiamGia %>%</td>
                    <td style="text-align: center"><%=String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", sp.sanPham.giaBan*(1-sp.sanPham.phanTramGiamGia/100)) %></td>
                    <td style="text-align: center"><%=sp.soLuong %></td>
                </tr>
                <% } %>
            </tbody>
        </table>
        <p style="text-align: right">
            <b>Tổng tiền: <span style="color: red;"><%=String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", tongTien) %></span></b>
        </p>
        <div class="pay-wrapper">
            <% if (Session["LoggedIn"] != null)
               { %>
            <a href="/ThanhToan.aspx" class="button">Thanh toán</a>
            <% }
               else
               { %>
            <p>Vui lòng <a href="DangNhap.aspx">Đăng nhập</a> để thanh toán</p>
            <% } %>
        </div>
        <% } %>
        

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
