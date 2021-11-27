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
    public partial class TimKiem : System.Web.UI.Page
    {
        public List<Product> products = new List<Product>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["q"] != null)
            {
                string timKiem = Request.QueryString["q"];
                products = SanPhamDB.TimKiemSanPham(timKiem.Trim().ToUpper(), 20);
            }
        }
    }
}