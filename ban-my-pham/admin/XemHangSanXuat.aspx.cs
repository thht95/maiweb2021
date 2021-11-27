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
    public partial class XemHangSanXuat : System.Web.UI.Page
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
                    Response.Redirect("/admin/DanhSachHangSanXuat.aspx");
                }
                if (id <= 0)
                {
                    Response.Redirect("/admin/DanhSachHangSanXuat.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        DataTable hangSanxuat = SanPhamDB.getHangSanXuatById(id);
                        if (hangSanxuat.Rows.Count > 0)
                        {
                            txtTenHangSanXuat.Value = hangSanxuat.Rows[0]["sTenhang"].ToString();
                            txtDiaChi.Value = hangSanxuat.Rows[0]["sDiachi"].ToString();
                            txtSdt.Value = hangSanxuat.Rows[0]["sSdt"].ToString();
                        }
                        else
                        {
                            Response.Redirect("/admin/DanhSachHangSanXuat.aspx");
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("/admin/DanhSachHangSanXuat.aspx");
            }
        }
    }
}