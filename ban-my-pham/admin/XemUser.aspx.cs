using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class XemUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                }
                catch
                {
                    Response.Redirect("/admin/DanhSachUser.aspx");
                }
                if (id <= 0) Response.Redirect("/admin/DanhSachUser.aspx");
                User user = null;
                try
                {
                    user = UserDB.getById(id);
                }
                catch
                {
                    Response.Redirect("/admin/DanhSachUser.aspx");
                }
                if (!IsPostBack)
                {
                    if (user == null) Response.Redirect("/admin/DanhSachUser.aspx");
                    // do du lieu ra form
                    tenDangNhap.Value = user.taiKhoan;
                    hoten.Value = user.hoTen;
                    ngaysinh.Value = user.ngaySinh.ToString("yyyy-MM-dd");
                    diachi.Value = user.diaChi;
                    sdt.Value = user.soDienThoai;
                    email.Value = user.email;
                    Role role = RoleDB.getRoleById(user.role);
                    if (role != null) txtRole.Value = role.tenQuyen;
                }
            }

        }
    }
}