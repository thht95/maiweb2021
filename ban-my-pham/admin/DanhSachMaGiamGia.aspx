<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="DanhSachMaGiamGia.aspx.cs" Inherits="ban_my_pham.admin.DanhSachMaGiamGia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Danh sách mã giảm giá <a href="/admin/ThemMaGiamGia.aspx" class="button">+Thêm</a>
    </h2>
    <table>
        <thead>
            <th>ID</th>
            <th>Mã giảm giá</th>
            <th>Phần trăm giảm</th>
            <th>Thao tác</th>
        </thead>
        <asp:ListView ID="lvMaGiamGia" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("iMagiamgiaid") %>
                    </td>
                    <td>
                        <%# Eval("sMagiamgia") %>
                    </td>
                    <td>
                        <%# Eval("fPhantramgiam") %>
                    </td>
                    <td>
                        <span class="action view" onclick="xemChiTiet(<%# Eval("iMagiamgiaid") %>)">Xem chi tiết</span>
                        <span class="action edit" onclick="sua(<%# Eval("iMagiamgiaid") %>)">Sửa</span>
                        <span class="action delete" onclick="xoa(<%# Eval("iMagiamgiaid") %>)">Xóa</span>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>

    <script type="text/javascript" src="../js/admin/ma-giam-gia.js"></script>
</asp:Content>
