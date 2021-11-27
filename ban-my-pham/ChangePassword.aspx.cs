using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["LoggedIn"]))
            {
                if (IsPostBack)
                {
                    User currentUser = (User)Session["User"];
                    string oldPassword = matkhaucu.Value;
                    if (!UserDB.authenticate(currentUser.taiKhoan, oldPassword))
                    {
                        CustomValidator1.IsValid = false;
                        CustomValidator1.ErrorMessage = "Mật khẩu cũ không chính xác.";
                    }
                    string newPassword = matkhaumoi.Value;
                    UserDB.doiMatKhau(currentUser.taiKhoan, newPassword);
                    Response.Redirect("~/TrangChu.aspx");
                }

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
            
        }
    }
}