using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class ThemUser : System.Web.UI.Page
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
                Role userRole = RoleDB.GetRoleByRoleName(ddlRole.SelectedValue);
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
                    Response.Write("<script>alert('Thêm user thành công');" +
                        "location.href='/admin/DanhSachUser.aspx';</script>");

                }
            } else
            {
                // load danh sach role
                ddlRole.DataSource = RoleDB.getAllRoles();
                ddlRole.DataTextField = "tenQuyen";
                ddlRole.DataValueField = "tenQuyen";
                ddlRole.DataBind();
            }
        }
    }
}