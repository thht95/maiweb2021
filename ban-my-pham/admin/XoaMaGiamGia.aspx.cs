using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class XoaMaGiamGia : System.Web.UI.Page
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
                    int ketqua = SanPhamDB.xoaMaGiamGia(id);
                    if (ketqua > 0)
                    {
                        Response.Write("<script>alert('Xóa thành công');" +
                            "location.href='/admin/DanhSachMaGiamGia.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Xóa thất bại');" +
                            "location.href='/admin/DanhSachMaGiamGia.aspx';</script>");
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