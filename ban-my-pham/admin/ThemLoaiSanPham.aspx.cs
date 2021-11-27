using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class ThemLoaiSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string ten = tenLoaiSanPham.Value.Trim();
                if (SanPhamDB.tonTaiTenLoaiSanPham(ten))
                {
                    CustomValidator1.IsValid = false;
                    CustomValidator1.ErrorMessage = "Tên loại sản phẩm đã tồn tại";
                } else
                {
                    try
                    {
                        SanPhamDB.addLoaiSanPham(ten);
                        Response.Write("<script>alert('Thêm lọai sản phẩm thành công');" +
                            "location='/admin/DanhSachLoaiSanPham.aspx';</script>");
                    } catch
                    {
                        Response.Write("<script>alert('Thêm loại sản phẩm thất bại');</script>");
                    }
                }
            }

        }
    }
}