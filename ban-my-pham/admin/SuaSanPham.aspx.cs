using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class SuaSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["id"] != null)
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                }
                catch
                {
                    Response.Redirect("/admin/DanhSachSanPham.aspx");
                }
                if (id <= 0)
                {
                    Response.Redirect("/admin/DanhSachSanPham.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        DataTable sanPham = SanPhamDB.GetSanPhamTheoId(id); 
                        if (sanPham.Rows.Count > 0)
                        {
                            ddlThuongHieu.DataSource = SanPhamDB.getAllHangSanXuat();
                            ddlThuongHieu.DataTextField = "sTenhang";
                            ddlThuongHieu.DataValueField = "iHangsanxuatid";
                            ddlThuongHieu.DataBind();
                            ddlLoaiSanPham.DataSource = SanPhamDB.getAllLoaiSanPham();
                            ddlLoaiSanPham.DataTextField = "sTenloaisanpham";
                            ddlLoaiSanPham.DataValueField = "iLoaisanphamid";
                            ddlLoaiSanPham.DataBind();
                            ddlThuongHieu.SelectedValue = sanPham.Rows[0]["iHangsanphamid"].ToString();
                            ddlLoaiSanPham.SelectedValue = sanPham.Rows[0]["iLoaisanphamid"].ToString();
                            txtNgaySanXuat.Value = Convert.ToDateTime(sanPham.Rows[0]["dNgaysanxuat"]).ToString("yyyy-MM-dd");
                            txtTenSanPham.Value = sanPham.Rows[0]["sTensanpham"].ToString();
                            txtXuatXu.Value = sanPham.Rows[0]["sXuatxu"].ToString();
                            txtGiaBan.Value = sanPham.Rows[0]["mGiaban"].ToString();
                            txtSoLuong.Value = sanPham.Rows[0]["iSoluong"].ToString();
                            txtMoTaNgan.Value = sanPham.Rows[0]["sMotangan"].ToString();
                            txtThongTinChiTiet.Value = sanPham.Rows[0]["sThongtinchitiet"].ToString();
                            view_image.Src = sanPham.Rows[0]["sImageurl"].ToString();
                            ViewState["imagePath"] = sanPham.Rows[0]["sImageurl"].ToString();
                        }
                        else
                        {
                            Response.Redirect("/admin/DanhSachSanPham.aspx");
                        }
                    }
                    else
                    {
                        DateTime ngaySanXuat = DateTime.Parse(txtNgaySanXuat.Value);
                        double phanTramGiamGia = Convert.ToDouble(txtPhanTramGiamGia.Value);
                        int hangSanXuat = Convert.ToInt32(ddlThuongHieu.SelectedValue);
                        int loaiSanPham = Convert.ToInt32(ddlLoaiSanPham.SelectedValue);
                        string tenSanPham = txtTenSanPham.Value.Trim();
                        string xuatXu = txtXuatXu.Value.Trim();
                        double giaBan = Convert.ToDouble(txtGiaBan.Value);
                        int soLuong = Convert.ToInt32(txtSoLuong.Value);
                        string motaNgan = txtMoTaNgan.Value;
                        string thongTinChiTiet = txtThongTinChiTiet.Value;
                        string imagePath = "";
                        if (SanPhamDB.tonTaiTenSanPham(id, tenSanPham))
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
                            } else
                            {
                                imagePath = ViewState["imagePath"].ToString();
                            }
                            try
                            {

                                SanPhamDB.suaSanPham(
                                    id,
                                    ngaySanXuat,
                                    phanTramGiamGia,
                                    hangSanXuat,
                                    loaiSanPham,
                                    tenSanPham,
                                    xuatXu,
                                    imagePath,
                                    giaBan,
                                    soLuong,
                                    motaNgan,
                                    thongTinChiTiet);
                                Response.Write("<script>alert('Sửa sản phẩm thành công');" +
                                    "location='/admin/DanhSachSanPham.aspx';</script>");
                            }
                            catch
                            {
                                Response.Write("<script>alert('Sửa sản phẩm thất bại');</script>");
                            }
                        }

                    }
                }
            }
            else
            {
                Response.Redirect("/admin/DanhSachLoaiSanPham.aspx");
            }
        }
    }
}