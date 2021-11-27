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
    public partial class Profile : System.Web.UI.Page
    {
        public DataTable lichSuMuaHang = new DataTable();
        public User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["LoggedIn"]))
            {
                user = (User)Session["User"];
                lichSuMuaHang = SanPhamDB.GetLichSuMuaHang(user.id);
                if (lichSuMuaHang.Rows.Count > 0)
                {

                }
                if (IsPostBack)
                {
                    string name = hoten.Value;
                    string dob = ngaysinh.Value;
                    string address = diachi.Value;
                    string phone = sdt.Value;
                    string mail = email.Value;
                    User currentUser = (User)Session["User"];
                    User user1 = new User(currentUser.id, currentUser.role, name, DateTime.Parse(dob), address, phone, mail, currentUser.taiKhoan, currentUser.matKhau);
                    UserDB.addOrUpdateUser(user1);
                    Session["User"] = user1;
                    Response.Redirect("~/Profile.aspx");
                }
                else
                {
                    bool editing = (Request.QueryString["edit"] != null);
                    user = (User)Session["User"];
                    hoten.Value = user.hoTen;
                    ngaysinh.Value = user.ngaySinh.ToString("yyyy-MM-dd");
                    diachi.Value = user.diaChi;
                    sdt.Value = user.soDienThoai;
                    email.Value = user.email;
                    if (!editing)
                    {
                        hoten.Disabled = true;
                        ngaysinh.Disabled = true;
                        diachi.Disabled = true;
                        sdt.Disabled = true;
                        email.Disabled = true;
                    }
                    taikhoan.Value = user.taiKhoan;
                }
                
            }
            else
            {
                Response.Redirect("~/DangNhap.aspx");
            }
            
        }
    }
}