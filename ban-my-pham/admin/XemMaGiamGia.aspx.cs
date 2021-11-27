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
    public partial class XemMaGiamGia : System.Web.UI.Page
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
                }
            }
            else
            {
                Response.Redirect("/admin/DanhSachMaGiamGia.aspx");
            }
        }
    }
}