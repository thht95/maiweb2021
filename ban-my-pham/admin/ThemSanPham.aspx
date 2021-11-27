<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="ThemSanPham.aspx.cs" Inherits="ban_my_pham.admin.ThemSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Thêm sản phẩm mới</h2>
    <div class="form-group">
        <label class="label"></label>
        <div class="form-control">
            <asp:ValidationSummary ValidationGroup="ServerError" HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary2" runat="server" />
            <asp:CustomValidator ValidationGroup="ServerError" ID="CustomValidator1" runat="server" ValidateEmptyText="true" Display="None"></asp:CustomValidator>

            <asp:ValidationSummary HeaderText="Có lỗi xảy ra:" CssClass="error-msg" ID="ValidationSummary1" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="None" ControlToValidate="txtTenSanPham" ErrorMessage="Tên sản phẩm không được bỏ trống."></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None" ControlToValidate="txtXuatXu" ErrorMessage="Xuất xứ không được bỏ trống."></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtGiaBan" ErrorMessage="Giá bán không được bỏ trống."></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="None" ControlToValidate="txtSoLuong" ErrorMessage="Số lượng không được bỏ trống."></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtMoTaNgan" ErrorMessage="Mô tả ngắn không được bỏ trống."></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtThongTinChiTiet" ErrorMessage="Thông tin chi tiết không được bỏ trống."></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="image" ErrorMessage="Vui lòng chọn ảnh sản phẩm"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="None" ControlToValidate="txtNgaySanXuat" ErrorMessage="Ngày sản xuất không được bỏ trống."></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label for="ddlThuongHieu" class="label">Thương hiệu</label>
        <asp:DropDownList class="form-control" ID="ddlThuongHieu" runat="server"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="ddlThuongHieu" class="label">Loại sản phẩm</label>
        <asp:DropDownList class="form-control" ID="ddlLoaiSanPham" runat="server"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="txtTenSanPham" class="label">Tên sản phẩm</label>
        <input runat="server" class="form-control" type="text" id="txtTenSanPham" placeholder="Nhập tên sản phẩm" />
    </div>
    <div class="form-group">
        <label for="txtXuatXu" class="label">Xuất xứ</label>
        <input runat="server" class="form-control" type="text" id="txtXuatXu" placeholder="Nhập xuất xứ của sản phẩm" />
    </div>
    <div class="form-group">
        <label for="txtNgaySanXuat" class="label">Ngày sản xuất</label>
        <input runat="server" class="form-control" type="date" id="txtNgaySanXuat" />
    </div>

    <div class="form-group">
        <label for="txtGiaBan" class="label">Giá bán</label>
        <input runat="server" class="form-control" type="number" step="any" id="txtGiaBan" value="1" min="0" />
    </div>
    <div class="form-group">
        <label for="txtSoLuong" class="label">Số lượng</label>
        <input runat="server" class="form-control" type="number" id="txtSoLuong" value="1" min="0" />
    </div>
    <div class="form-group">
        <label for="txtMoTaNgan" class="label">Mô tả ngắn</label>
        <input runat="server" class="form-control" type="text" id="txtMoTaNgan" placeholder="Nhập mô tả ngắn của sản phẩm" />
    </div>
    <div class="form-group">
        <label for="txtThongTinChiTiet" class="label">Thông tin chi tiết</label>
        <textarea rows="5" runat="server" id="txtThongTinChiTiet"></textarea>
    </div>
    <div class="form-group">
        <label class="label">Ảnh sản phẩm</label>
        <div class="form-control">
            <img runat="server" id="view_image" style="border: 1px solid #e5e6ec; width: 200px; height: 200px;" />
            <asp:FileUpload ID="image" runat="server" accept=".png,.jpg,.jpeg" onChange="view_image(event)" />
        </div>
    </div>
    <div class="center-children">
        <asp:Button CssClass="button" ID="Button1" runat="server" Text="Thêm" />
    <button class="button-xanhduong" style="margin-left: 5px;" onclick="return back();">Quay lại</button>
    </div>
    <script>
        function back() {
            location.href = '/admin/DanhSachSanPham.aspx';
            return false;
        }
    </script>
    <script type="text/javascript" src="../js/admin/san-pham.js"></script>
</asp:Content>
