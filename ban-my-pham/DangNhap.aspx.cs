using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
            //    if (UserDB.authenticate(tenDangNhap.Value, matKhau.Value))
            //    {
            //        User user = UserDB.getByUsername(tenDangNhap.Value);
            //        Session["LoggedIn"] = true;
            //        Session["User"] = user;
            //        Response.Redirect("~/TrangChu.aspx");
            //    }
            //    else
            //    {
            //        CustomValidator1.IsValid = false;
            //        CustomValidator1.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không chính xác.";
            //    }
            //}
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public static bool kiemTraDangNhap(string tenDangNhap, string matKhau)
        {
         
            
            if (UserDB.authenticate(tenDangNhap, matKhau))
            {
             
                User user = UserDB.getByUsername(tenDangNhap);
                HttpContext.Current.Session["LoggedIn"] = true;
                HttpContext.Current.Session["User"] = user;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}