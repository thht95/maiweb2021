using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class ThemHangSanXuat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string tenHangSanXuat = txtTenHangSanXuat.Value.Trim();
                string diaChi = txtDiaChi.Value.Trim();
                string sdt = txtSdt.Value.Trim();
                if (SanPhamDB.tonTaiTenHangSanXuat(tenHangSanXuat))
                {
                    CustomValidator1.IsValid = false;
                    CustomValidator1.ErrorMessage = "Tên hãng sản xuất đã tồn tại";
                }
                else
                {
                    try
                    {
                        SanPhamDB.themHangSanXuat(tenHangSanXuat, diaChi, sdt);
                        Response.Write("<script>alert('Thêm hãng sản xuất thành công');" +
                            "location='/admin/DanhSachHangSanXuat.aspx';</script>");
                    }
                    catch
                    {
                        Response.Write("<script>alert('Thêm hãng sản xuất thất bại');</script>");
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/DanhSachHangSanXuat.aspx");
        }
    }
}