using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham
{
    public partial class KhuyenMai : System.Web.UI.Page
    {
        public List<Product> products;
        public List<Coupon> coupons;
        public int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Convert.ToInt32(Request.QueryString["type"]);
            if (type == 1)
            {
                products = SanPhamDB.GetSanPhamKhuyenMai(0);
            }
            else if (type == 2)
            {
                coupons = SanPhamDB.getListMaGiamGia();
            }
            else
            {
                Response.Redirect("~/TrangChu.aspx");
            }
        }
    }
}