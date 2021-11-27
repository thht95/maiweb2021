<%@ Page Title="Khuyến mãi - Giảm giá" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="KhuyenMai.aspx.cs" Inherits="ban_my_pham.KhuyenMai" %>
<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
    <link href="css/khuyen-mai.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <% int type = Convert.ToInt32(Request.QueryString["type"]); %>
        <div class="category-header">
            <span class="left-text"><%= (type == 1 ? "Sản phẩm khuyến mãi   " : "Mã giảm giá") %></span>
            <div class="horizontal-line"></div>
        </div>
        <% if (type == 1) { %>
            <div class="products">
                <% foreach(ban_my_pham.Product sp in products) { %>
                    <a href="ChiTietSanPham.aspx?id=<%=sp.maSanPham %>" class="product">
                        <% if (sp.phanTramGiamGia > 0) { %>
                        <div class="discount-percentage">
                            <span>-<%=sp.phanTramGiamGia %>%</span>
                        </div>
                        <% } %>
                        <img src="<%=((sp.duongDanAnh != null && sp.duongDanAnh.Trim().Length > 0)?sp.duongDanAnh.Substring(1):"images/son.jpg") %>" class="product-image" />
                        <div class="product-details">
                            <h4 class="product-name"><%=sp.tenSanPham %></h4>
                            <span class="discounted-price"><%= String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", sp.giaBan*(1-sp.phanTramGiamGia/100)) %></span>
                            <% if (sp.phanTramGiamGia > 0) { %>
                                <del class="price"><%= String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", sp.giaBan) %></del>
                            <% } %>
                        </div>
                    </a>
                <% } %>
            </div>
        <% } else { %>
            <div class="coupons">
                <% foreach(ban_my_pham.Coupon cp in coupons) { %>
                    <a href="#" class="coupon">
                        <img src="images/coupon.png" class="coupon-logo" />
                        <div class="discount-percentage">
                            <span>-<%=cp.phanTramGiamGia %>%</span>
                        </div>
                        <div class="coupon-details">
                            <h4 class="coupon-name">Mã giảm <%=cp.phanTramGiamGia %>% giá trị sản phẩm</h4>
                            <span class="coupon-code">Mã: <b><%=cp.maGiamGia %></b></span><br />
                            <span>Ngày kết thúc: <%=cp.ngayKetThuc.ToString("dd/MM/yyyy") %></span>
                        </div>
                    </a>
                <% } %>
            </div>
        <% } %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
