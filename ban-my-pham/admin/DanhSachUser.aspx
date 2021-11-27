<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="DanhSachUser.aspx.cs" Inherits="ban_my_pham.admin.DanhSachUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Danh sách loại sản phẩm <a href="/admin/ThemUser.aspx" class="button">+Thêm</a>
    </h2>
    <table>
        <thead>
            <th>ID</th>
            <th>Tài khoản</th>
            <th>Họ tên</th>
            <th>Email</th>
            <th>Thao tác</th>
        </thead>
        <asp:ListView ID="lvUser" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("id") %>
                    </td>
                    <td>
                        <%# Eval("taiKhoan ") %>
                    </td>
                    <td>
                        <%# Eval("hoTen") %>
                    </td>
                    <td>
                        <%# Eval("email") %>
                    </td>
                    <td>
                        <span class="action view" onclick="xemChiTiet(<%# Eval("id") %>)">Xem chi tiết</span>
                        <span class="action edit" onclick="sua(<%# Eval("id") %>)">Sửa</span>
                        <span class="action delete" onclick="xoa(<%# Eval("id") %>)">Xóa</span>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>

    <script type="text/javascript" src="../js/admin/user.js"></script>
</asp:Content>
