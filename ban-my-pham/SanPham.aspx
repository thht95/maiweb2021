﻿<%@ Page Title="Sản phẩm" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="ban_my_pham.SanPham" %>
<asp:Content ID="Content2" ContentPlaceHolderID="css" runat="server">
    <link href="css/san-pham.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 151px;
        }
        .auto-style2 {
            width: 306px;
        }
        .auto-style3 {
            width: 127px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="category-header">
            <span class="left-text"><%=productType.tenLoaiSanPham %></span>
            <div class="horizontal-line"></div>
        </div>
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
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
