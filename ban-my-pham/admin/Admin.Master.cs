using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["LoggedIn"]))
            {
                Response.Write("<script>alert('Bạn cần đăng nhập để vào trang quản trị');" +
                    "location.href='/DangNhap.aspx';</script>");
            }
            else
            {
                User user = (User)Session["User"];
                if (user != null)
                {
                    Role role = RoleDB.getRoleById(user.role);
                    if (role.tenQuyen != "ADMIN")
                    {
                        Response.Write("<script>alert('Bạn cần quyền ADMIN để vào trang quản trị');" +
                    "location.href='/TrangChu.aspx';</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Bạn cần quyền ADMIN để vào trang quản trị');" +
                    "location.href='/TrangChu.aspx';</script>");
                }

            }
        }
    }
}