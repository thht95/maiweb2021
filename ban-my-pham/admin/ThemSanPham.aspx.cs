using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class ThemSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlThuongHieu.DataSource = SanPhamDB.getAllHangSanXuat();
                ddlThuongHieu.DataTextField = "sTenhang";
                ddlThuongHieu.DataValueField = "iHangsanxuatid";
                ddlThuongHieu.DataBind();
                ddlLoaiSanPham.DataSource = SanPhamDB.getAllLoaiSanPham();
                ddlLoaiSanPham.DataTextField = "sTenloaisanpham";
                ddlLoaiSanPham.DataValueField = "iLoaisanphamid";
                ddlLoaiSanPham.DataBind();
            } else
            {
                DateTime ngaySanXuat = DateTime.Parse(txtNgaySanXuat.Value);
                int hangSanXuat = Convert.ToInt32(ddlThuongHieu.SelectedValue);
                int loaiSanPham = Convert.ToInt32(ddlLoaiSanPham.SelectedValue);
                string tenSanPham = txtTenSanPham.Value.Trim();
                string xuatXu = txtXuatXu.Value.Trim();
                double giaBan = Convert.ToDouble(txtGiaBan.Value);
                int soLuong = Convert.ToInt32(txtSoLuong.Value);
                string motaNgan = txtMoTaNgan.Value;
                string thongTinChiTiet = txtThongTinChiTiet.Value;
                string imagePath = "";
                if (SanPhamDB.tonTaiTenSanPham(tenSanPham))
                {
                    CustomValidator1.IsValid = false;
                    CustomValidator1.ErrorMessage = "Tên sản phẩm đã tồn tại";
                }
                else
                {
                    if (image.HasFile)
                    {
                        string imageName = tenSanPham + image.FileName;
                        image.PostedFile.SaveAs(Server.MapPath("~/images/sanpham/" + imageName));
                        imagePath = "~/images/sanpham/" + imageName;
                    }
                    try
                    {
                        SanPhamDB.themSanPham(
                            1,
                            ngaySanXuat,
                            hangSanXuat,
                            loaiSanPham,
                            tenSanPham,
                            xuatXu,
                            imagePath,
                            giaBan,
                            soLuong,
                            motaNgan,
                            thongTinChiTiet);
                        Response.Write("<script>alert('Thêm sản phẩm thành công');" +
                            "location='/admin/DanhSachSanPham.aspx';</script>");
                    }
                    catch
                    {
                        Response.Write("<script>alert('Thêm sản phẩm thất bại');</script>");
                    }
                }
            }
        }
    }
}