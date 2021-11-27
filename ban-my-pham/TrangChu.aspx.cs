using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham
{
    public partial class TrangChu : System.Web.UI.Page
    {
        public List<Product> sanPhamMoi;
        public List<Product> sanPhamKhuyenMai;
        protected void Page_Load(object sender, EventArgs e)
        {
            sanPhamMoi = SanPhamDB.GetSanPhamMoi(5);
            sanPhamKhuyenMai = SanPhamDB.GetSanPhamKhuyenMai(5);
        }
    }
}