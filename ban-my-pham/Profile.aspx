<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ban_my_pham.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
    <link href="css/profile.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="info-header"><span>Thông tin cá nhân</span></h3>
        <div class="info-box">
            <div class="form-group">
                <label class="label"></label>
                <div class="form-control">
                    <asp:ValidationSummary ValidationGroup="ServerError" HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary2" runat="server" />
                    <asp:CustomValidator ValidationGroup="ServerError" ID="CustomValidator1" runat="server" ValidateEmptyText="true" Display="None"></asp:CustomValidator>

                    <asp:ValidationSummary HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary1" runat="server" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Số điện thoại chỉ được là số" Display="None" ControlToValidate="sdt" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ValidationExpression="\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*" Display="None" ErrorMessage="Email không đúng định dạng" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="None" ControlToValidate="email" ErrorMessage="Email không được bỏ trống."></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None" ControlToValidate="sdt" ErrorMessage="Số điện thoại không được bỏ trống."></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="diachi" ErrorMessage="Địa chỉ không được bỏ trống."></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="None" ControlToValidate="ngaysinh" ErrorMessage="Ngày sinh không được bỏ trống."></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="hoten" ErrorMessage="Họ tên không được bỏ trống."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="hoten" class="label">Họ tên</label>
                <input runat="server" class="form-control" type="text" id="hoten" placeholder="Nhập họ tên" />
            </div>
            <div class="form-group">
                <label for="ngaysinh" class="label">Ngày sinh</label>
                <input runat="server" class="form-control" type="date" id="ngaysinh" />
            </div>
            <div class="form-group">
                <label for="diachi" class="label">Địa chỉ</label>
                <input runat="server" class="form-control" type="text" id="diachi" placeholder="Nhập địa chỉ" />
            </div>
            <div class="form-group">
                <label for="sdt" class="label">Số điện thoại</label>
                <input runat="server" class="form-control" type="text" id="sdt" placeholder="Nhập số điện thoại" />
            </div>
            <div class="form-group">
                <label for="email" class="label">Email</label>
                <input runat="server" class="form-control" type="text" id="email" placeholder="Nhập email" />
            </div>
            <div class="center-children">
                <% if (Request.QueryString["edit"] != null)
                    { %>
                <asp:Button CssClass="button" ID="Button1" runat="server" Text="Hoàn tất" />
                <a href="Profile.aspx" class="button cancel-button">Hủy bỏ</a>
                <% }
                else
                { %>
                <a href="Profile.aspx?edit=1" class="button">Chỉnh sửa</a>
                <% } %>
            </div>
        </div>

        <h3 class="info-header"><span>Thông tin tài khoản</span></h3>
        <div class="account-box">
            <div class="form-group">
                <label for="taikhoan" class="label">Tài khoản</label>
                <input runat="server" class="form-control" disabled type="text" id="taikhoan" />
            </div>
            <div class="form-group">
                <label for="matkhau" class="label">Mật khẩu</label>
                <input runat="server" class="form-control" type="text" disabled id="matkhau" value="●●●●●●●●●●" />
            </div>
            <div class="center-children">
                <a href="ChangePassword.aspx" class="button">Đổi mật khẩu</a>
            </div>
        </div>
        <h3 class="info-header"><span>Lịch sử mua hàng</span></h3>
        <%if (lichSuMuaHang.Rows.Count > 0)
            { %>
        <table>
            <thead>
                <tr>
                    <th>STT</th>
                    <th>Ngày mua</th>
                    <th>Tổng tiền thanh toán</th>
                </tr>
            </thead>
            <tbody>
                <% int i = 0; %>
                <% foreach (System.Data.DataRow row in lichSuMuaHang.Rows)
                    { %>
                <% i++; %>
                <tr>
                    <td style="text-align: center"><%=i %></td>
                    <td> <%= Convert.ToDateTime(row["dNgaymua"]).ToString("dd/MM/yyyy") %></td>
                    <td style="text-align: center"><%= String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", row["fTongtien"]) %></td>
                </tr>
                <% } %>
            </tbody>
        </table>
        <%}
            else { Response.Write("Bạn chưa mua sản phẩm nào"); } %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
