using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham
{
    public partial class ApDungMaGiamGia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ma"] != null)
            {
                string ma = Request.QueryString["ma"].ToString();
                DataTable maGiamGia = SanPhamDB.getMaGiamGiaTheoMa(ma);
                if (maGiamGia.Rows.Count > 0)
                {
                    
                    if (Convert.ToDateTime(maGiamGia.Rows[0]["dThoigianketthuc"]) < DateTime.Now.Date)
                    {
                        Session["MaGiamGia"] = null;
                        Session["PhanTramGiam"] = 0.0;
                        Response.Write("<script>alert('Mã giảm giá này đã hết hạn');" +
                        "location.href='/ThanhToan.aspx';</script>");
                    } else
                    {
                        Session["MaGiamGia"] = ma;
                        Session["PhanTramGiam"] = Convert.ToDouble(maGiamGia.Rows[0]["fPhantramgiam"]);
                        Response.Write("<script>alert('Áp dụng mã giảm giá thành công');" +
                        "location.href='/ThanhToan.aspx';</script>");
                    }
                    
                } else
                {
                    Session["MaGiamGia"] = null;
                    Session["PhanTramGiam"] = 0.0;
                    Response.Write("<script>alert('Mã giảm giá này không tồn tại');" +
                        "location.href='/ThanhToan.aspx';</script>");
                }
            }
        }
    }
}