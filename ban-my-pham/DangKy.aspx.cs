using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                string username = tenDangNhap.Value;
                string password = matKhau.Value;
                string name = hoten.Value;
                string dob = ngaysinh.Value;
                string address = diachi.Value;
                string phone = sdt.Value;
                string mail = email.Value;
                Role userRole = RoleDB.GetRoleByRoleName("USER");
                if (UserDB.taiKhoanDaTonTai(username))
                {
                    CustomValidator1.IsValid = false;
                    CustomValidator1.ErrorMessage = "Tên đăng nhập đã tồn tại.";
                }
                else if (UserDB.emailDaTonTai(mail))
                {
                    CustomValidator1.IsValid = false;
                    CustomValidator1.ErrorMessage = "Email đã tồn tại.";
                }
                else
                {
                    User user = new User(0, userRole.id, name, DateTime.Parse(dob), address, phone, mail, username, password);
                    UserDB.addOrUpdateUser(user);
                    user = UserDB.getByUsername(tenDangNhap.Value);
                    Session["LoggedIn"] = true;
                    Session["User"] = user;
                    Response.Redirect("~/TrangChu.aspx");
                }
            }
        }
    }
}