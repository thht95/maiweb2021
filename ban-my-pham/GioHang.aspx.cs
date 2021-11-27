using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham
{
    public partial class GioHang : System.Web.UI.Page
    {
        public List<SanPhamGioHang> sanPhamTrongGioHang;
        public float tongTien = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GioHang"] == null)
            {
                Session["GioHang"] = new List<SanPhamGioHang>();
            }
            sanPhamTrongGioHang = (List<SanPhamGioHang>)Session["GioHang"];
            foreach (SanPhamGioHang product in sanPhamTrongGioHang)
            {
                tongTien += product.soLuong * product.sanPham.giaBan * (1 - product.sanPham.phanTramGiamGia / 100);
                Session["TongTien"] = tongTien;
            }
        }
       
    }
}