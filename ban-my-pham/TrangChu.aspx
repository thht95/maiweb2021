﻿<%@ Page Title="Trang chủ" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="ban_my_pham.TrangChu" %>

<asp:Content ID="Content2" ContentPlaceHolderID="css" runat="server">
    <link href="css/trang-chu.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="banner">
            <img src="images/banner.jpg" />
        </div>
        <div class="category-header">
            <span class="left-text">Sản phẩm mới</span>
            <div class="horizontal-line"></div>
          
        </div>
        <div class="products">
            <% foreach(ban_my_pham.Product sp in sanPhamMoi) { %>
                <a href="ChiTietSanpham.aspx?id=<%=sp.maSanPham %>" class="product">
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

        <div class="category-header">
            <span class="left-text">Đang khuyến mãi</span>
            <div class="horizontal-line"></div>
          
        </div>
        <div class="products">
            <% foreach(ban_my_pham.Product sp in sanPhamKhuyenMai) { %>
                <a href="ChiTietSanPham.aspx?id=<%=sp.maSanPham %>"  class="product">
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

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
