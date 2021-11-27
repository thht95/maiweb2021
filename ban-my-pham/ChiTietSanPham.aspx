<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="ban_my_pham.ChiTietSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
    <link href="css/chi-tiet-san-pham.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="container">
        <div class="product-main">
            <img src="<%=((product.duongDanAnh != null && product.duongDanAnh.Trim().Length > 0)?product.duongDanAnh.Substring(1):"images/son.jpg") %>" class="product-image" />
            <div class="product-info">
                <h1 class="title-ten-sp"><%=product.tenSanPham %></h1>
                <p><%=product.moTaNgan %></p>
                <div class="price-wrapper">
                    <span class="discounted-price"><%= String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", product.giaBan*(1-product.phanTramGiamGia/100)) %></span>
                    <del class="price"><%= String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", product.giaBan) %></del>
                </div>
                
                <input id="addToCart" type="button" class="button" value="&#128722; Thêm vào giỏ" data-id="<%=product.maSanPham %>"/>
                <span style="margin-bottom: 1em; font-size: 11pt;">Thông tin chi tiết:</span>
                <div class="row-key-val">
                    <span class="col-key">Thương hiệu</span>
                    <span class="col-val"><%=product.tenHangSanXuat %></span>
                </div>
                <div class="row-key-val">
                    <span class="col-key">Tình trạng</span>
                    <span class="col-val"><%= (product.soLuong > 0 ? "Còn hàng" : "Tạm hết hàng")  %></span>
                </div>
                <div class="row-key-val">
                    <span class="col-key">Sản xuất tại</span>
                    <span class="col-val"><%=product.xuatXu %></span>
                </div>
                <p><%=product.moTaChiTiet %></p>
            </div>
        </div>
        <div class="category-header">
            <span class="left-text">Sản phẩm cùng loại</span>
            <div class="horizontal-line"></div>
        </div>
        <div class="products">
            <% foreach (ban_my_pham.Product sp in sanPhamCungLoai)
               { %>
            <a href="ChiTietSanPham.aspx?id=<%=sp.maSanPham %>" class="product-small">
                <img src="<%=((sp.duongDanAnh != null && sp.duongDanAnh.Trim().Length > 0)?sp.duongDanAnh.Substring(1):"images/son.jpg") %>" class="product-small-image" />
                <div class="product-small-details">
                    <h4 class="product-small-name"><%=sp.tenSanPham %></h4>
                    <span class="product-small-sdiscounted-price"><%= String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", sp.giaBan*(1-sp.phanTramGiamGia/100)) %></span>
                    <% if (sp.phanTramGiamGia > 0)
                       { %>
                    <del class="product-small-sprice"><%= String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", sp.giaBan) %></del>
                    <% } %>
                </div>
            </a>
            <% } %>
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script src="js/chi-tiet-san-pham.js"></script>
</asp:Content>
