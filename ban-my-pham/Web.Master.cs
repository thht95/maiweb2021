using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham
{
    public partial class Web : System.Web.UI.MasterPage
    {
        public List<ProductType> dsLoaiSanPham;
        protected void Page_Load(object sender, EventArgs e)
        {
            dsLoaiSanPham = SanPhamDB.getListLoaiSanPham();
            if (Convert.ToBoolean(Session["LoggedIn"]))
            {
                User user = (User)Session["User"];
                if (user != null)
                {
                    Role role = RoleDB.getRoleById(user.role);
                    if (role.tenQuyen == "ADMIN")
                    {
                        Session["ADMIN"] = true;
                    } else
                    {
                        Session["ADMIN"] = false;
                    }
                }               

            }
        }
    }
}