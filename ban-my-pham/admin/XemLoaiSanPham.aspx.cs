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
    public partial class XemLoaiSanPham : System.Web.UI.Page
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
                }
            }
            else
            {
                Response.Redirect("/admin/DanhSachLoaiSanPham.aspx");
            }

        }
    }
}