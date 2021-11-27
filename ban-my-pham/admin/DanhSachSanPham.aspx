<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="DanhSachSanPham.aspx.cs" Inherits="ban_my_pham.admin.DanhSachSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Danh sách sản phẩm <a href="/admin/ThemSanPham.aspx" class="button">+Thêm</a>
    </h2>
    <table>
        <thead>
            <th>ID</th>
            <th>Tên sản phẩm</th>
            <th>Xuất xứ</th>
            <th>Giá bán</th>
            <th>Số lượng</th>
            <th>Thao tác</th>
        </thead>
        <asp:ListView ID="lvSanPham" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("iSanphamid") %>
                    </td>
                     <td>
                        <%# Eval("sTensanpham") %>
                    </td>
                     <td>
                        <%# Eval("sXuatxu") %>
                    </td>
                     <td>
                        <%# Eval("mGiaban") %>
                    </td>
                     <td>
                        <%# Eval("iSoluong") %>
                    </td>
                    <td>
                        <span class="action view" onclick="xemChiTiet(<%# Eval("iSanphamid") %>)">Xem chi tiết</span>
                        <span class="action edit" onclick="sua(<%# Eval("iSanphamid") %>)">Sửa</span>
                        <span class="action delete" onclick="xoa(<%# Eval("iSanphamid") %>)">Xóa</span>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>
    
    <script type="text/javascript" src="../js/admin/san-pham.js"></script>
</asp:Content>
