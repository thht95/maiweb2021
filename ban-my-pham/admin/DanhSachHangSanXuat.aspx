<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="DanhSachHangSanXuat.aspx.cs" Inherits="ban_my_pham.admin.DanhSachHangSanXuat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Danh sách hãng sản xuất <a href="/admin/ThemHangSanXuat.aspx" class="button">+Thêm</a>
    </h2>
    <table>
        <thead>
            <th>ID</th>
            <th>Tên hãng sản xuất</th>
            <th>Địa chỉ</th>
            <th>Số điện thoại</th>
            <th>Thao tác</th>
        </thead>
        <asp:ListView ID="lvHangSanXuat" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("iHangsanxuatid") %>
                    </td>
                    <td>
                        <%# Eval("sTenhang") %>
                    </td>
                    <td>
                        <%# Eval("sDiachi") %>
                    </td>
                    <td>
                        <%# Eval("sSdt") %>
                    </td>
                    <td>
                        <span class="action view" onclick="xemChiTiet(<%# Eval("iHangsanxuatid") %>)">Xem chi tiết</span>
                        <span class="action edit" onclick="sua(<%# Eval("iHangsanxuatid") %>)">Sửa</span>
                        <span class="action delete" onclick="xoa(<%# Eval("iHangsanxuatid") %>)">Xóa</span>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>
  
    <script type="text/javascript" src="../js/admin/hang-san-xuat.js"></script>
</asp:Content>
