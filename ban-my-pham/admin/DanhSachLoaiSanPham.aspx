<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="DanhSachLoaiSanPham.aspx.cs" Inherits="ban_my_pham.admin.DanhSachLoaiSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Danh sách loại sản phẩm <a href="/admin/ThemLoaiSanPham.aspx" class="button">+Thêm</a>
    </h2>
    <table>
        <thead>
            <th>ID</th>
            <th>Tên loại sản phẩm</th>
            <th>Thao tác</th>
        </thead>
        <asp:ListView ID="lvLoaiSanPham" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("iLoaisanphamid") %>
                    </td>
                    <td>
                        <%# Eval("sTenloaisanpham") %>
                    </td>
                    <td>
                        <span class="action view" onclick="xemChiTiet(<%# Eval("iLoaisanphamid") %>)">Xem chi tiết</span>
                        <span class="action edit" onclick="sua(<%# Eval("iLoaisanphamid") %>)">Sửa</span>
                        <span class="action delete" onclick="xoa(<%# Eval("iLoaisanphamid") %>)">Xóa</span>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>

    <script type="text/javascript" src="../js/admin/loai-san-pham.js"></script>
</asp:Content>

