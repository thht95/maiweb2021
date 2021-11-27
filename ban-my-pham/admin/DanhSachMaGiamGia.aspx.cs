using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class DanhSachMaGiamGia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lvMaGiamGia.DataSource = SanPhamDB.getAllMaGiamGia();
                lvMaGiamGia.DataBind(); 
            }
        }
    }
}