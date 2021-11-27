using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class DanhSachLoaiSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable lstLoaiSanPham = new DataTable();
                try
                {
                    lstLoaiSanPham = SanPhamDB.getAllLoaiSanPham();
                } catch
                {
                    Response.Write("<script>alert('Không thể lấy danh sách loại sản phẩm');</script>");
                }
                lvLoaiSanPham.DataSource = lstLoaiSanPham;
                lvLoaiSanPham.DataBind();
            }
        }
    }
}