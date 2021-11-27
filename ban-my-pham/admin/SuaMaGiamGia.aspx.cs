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
    public partial class SuaMaGiamGia : System.Web.UI.Page
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
                    Response.Redirect("/admin/DanhSachMaGiamGia.aspx");
                }
                if (id <= 0)
                {
                    Response.Redirect("/admin/DanhSachMaGiamGia.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        DataTable maGiamGia = SanPhamDB.getMaGiamGiaById(id);
                        if (maGiamGia.Rows.Count > 0)
                        {
                            txtMaGiamGia.Value = maGiamGia.Rows[0]["sMagiamgia"].ToString();
                            txtPhanTramGiamGia.Value = maGiamGia.Rows[0]["fPhantramgiam"].ToString();
                            txtNgayBatDau.Value = Convert.ToDateTime(maGiamGia.Rows[0]["dThoigianbatdau"]).ToString("yyyy-MM-dd");
                            txtNgayKetThuc.Value = Convert.ToDateTime(maGiamGia.Rows[0]["dThoigianketthuc"]).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            Response.Redirect("/admin/DanhSachMaGiamGia.aspx");
                        }
                    }
                    else
                    {
                        string maGiamGia = txtMaGiamGia.Value.Trim();
                        double phanTramGiam = Convert.ToDouble(txtPhanTramGiamGia.Value);
                        DateTime ngayBatDau = Convert.ToDateTime(txtNgayBatDau.Value);
                        DateTime ngayKetThuc = Convert.ToDateTime(txtNgayKetThuc.Value);
                        if (SanPhamDB.tonTaiMaGiamGia(id, maGiamGia))
                        {
                            CustomValidator1.IsValid = false;
                            CustomValidator1.ErrorMessage = "Mã giảm giá đã tồn tại";
                        }
                        else
                        {
                            try
                            {
                                int result = SanPhamDB.suaMaGiamGia(id, maGiamGia, phanTramGiam, ngayBatDau, ngayKetThuc);
                                if (result > 0)
                                {
                                    Response.Write("<script>alert('Sửa mã giảm giá thành công');" +
                                    "location='/admin/DanhSachMaGiamGia.aspx';</script>");
                                }
                                else
                                {
                                    Response.Write("<script>alert('Sửa mã giảm giá thất bại');</script>");
                                }

                            }
                            catch
                            {
                                Response.Write("<script>alert('Sửa mã giảm giá thất bại');</script>");
                            }
                        }

                    }
                }
            }
            else
            {
                Response.Redirect("/admin/DanhSachMaGiamGia.aspx");
            }
        }
    }
}