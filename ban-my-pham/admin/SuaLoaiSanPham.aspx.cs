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
    public partial class SuaLoaiSanPham : System.Web.UI.Page
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
                    Response.Redirect("/admin/DanhSachLoaiSanPham.aspx");
                }
                if (id <= 0)
                {
                    Response.Redirect("/admin/DanhSachLoaiSanPham.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        DataTable loaiSanPham = SanPhamDB.getLoaiSanPhamTheoId(id);
                        if (loaiSanPham.Rows.Count > 0)
                        {
                            tenLoaiSanPham.Value = loaiSanPham.Rows[0]["sTenloaisanpham"].ToString();
                        }
                        else
                        {
                            Response.Redirect("/admin/DanhSachLoaiSanPham.aspx");
                        }
                    }
                    else
                    {
                        string ten = tenLoaiSanPham.Value.Trim();
                        if (SanPhamDB.tonTaiTenLoaiSanPham(id, ten))
                        {
                            CustomValidator1.IsValid = false;
                            CustomValidator1.ErrorMessage = "Tên loại sản phẩm đã tồn tại";
                        }
                        else
                        {
                            try
                            {
                                int result = SanPhamDB.suaLoaiSanPham(id, ten);
                                if (result > 0)
                                {
                                    Response.Write("<script>alert('Sửa lọai sản phẩm thành công');" +
                                    "location='/admin/DanhSachLoaiSanPham.aspx';</script>");
                                }
                                else
                                {
                                    Response.Write("<script>alert('Sửa loại sản phẩm thất bại');</script>");
                                }

                            }
                            catch
                            {
                                Response.Write("<script>alert('Sửa loại sản phẩm thất bại');</script>");
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