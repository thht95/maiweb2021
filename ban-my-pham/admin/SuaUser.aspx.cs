using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class SuaUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                } catch
                {
                    Response.Redirect("/admin/DanhSachUser.aspx");
                }
                if (id <= 0) Response.Redirect("/admin/DanhSachUser.aspx");
                User user = null;
                try
                {
                    user = UserDB.getById(id);
                } catch
                {
                    Response.Redirect("/admin/DanhSachUser.aspx");
                }
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
                    if (UserDB.taiKhoanDaTonTai(user.id, username))
                    {
                        CustomValidator1.IsValid = false;
                        CustomValidator1.ErrorMessage = "Tên đăng nhập đã tồn tại.";
                    }
                    else if (UserDB.emailDaTonTai(user.id, mail))
                    {
                        CustomValidator1.IsValid = false;
                        CustomValidator1.ErrorMessage = "Email đã tồn tại.";
                    }
                    else
                    {
                        user.role = userRole.id;
                        user.hoTen = name;
                        user.ngaySinh = DateTime.Parse(dob);
                        user.diaChi = address;
                        user.soDienThoai = phone;
                        user.email = mail;
                        user.taiKhoan = username;
                        user.matKhau = password;
                        UserDB.addOrUpdateUser(user);
                        Response.Write("<script>alert('Sửa user thành công');" +
                            "location.href='/admin/DanhSachUser.aspx';</script>");

                    }
                }
                else
                {
                    if (user == null) Response.Redirect("/admin/DanhSachUser.aspx");
                    // load danh sach role
                    ddlRole.DataSource = RoleDB.getAllRoles();
                    ddlRole.DataTextField = "tenQuyen";
                    ddlRole.DataValueField = "tenQuyen";
                    ddlRole.DataBind();
                    // do du lieu ra form
                    tenDangNhap.Value = user.taiKhoan;
                    matKhau.Value = user.matKhau;
                    hoten.Value = user.hoTen;
                    ngaysinh.Value = user.ngaySinh.ToString("yyyy-MM-dd");
                    diachi.Value = user.diaChi;
                    sdt.Value = user.soDienThoai;
                    email.Value = user.email;
                    Role role = RoleDB.getRoleById(user.role);
                    if (role != null)  ddlRole.SelectedValue = role.tenQuyen;
                }
            }

        }
    }
}