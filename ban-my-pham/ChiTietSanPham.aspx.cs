using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham
{
    public partial class ChiTietSanPham : System.Web.UI.Page
    {
        public Product product;
        public List<Product> sanPhamCungLoai;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                product = SanPhamDB.GetSanPhamById(id);
                sanPhamCungLoai = SanPhamDB.GetSanPhamByLoai(product.maLoaiSanPham, 8);
            }
            else
            {
                Response.Redirect("~/TrangChu.aspx");
            }
        }
        
        [System.Web.Services.WebMethod(EnableSession=true)]
        public static string themVaoGio(int idSanPham)
        {
            Product sp = SanPhamDB.GetSanPhamById(idSanPham);
            if (HttpContext.Current.Session["GioHang"] == null)
            {
                HttpContext.Current.Session["GioHang"] = new List<SanPhamGioHang>();
            }
            if (HttpContext.Current.Session["SoLuongSanPhamTrongGio"] == null)
            {
                HttpContext.Current.Session["SoLuongSanPhamTrongGio"] = 0;
            }
            List<SanPhamGioHang> sanPhamTrongGio = (List<SanPhamGioHang>)HttpContext.Current.Session["GioHang"];
            // tìm xem sản phẩm đã có trong giỏ chưa, nếu đã có thì thêm số lượng
            int idx = -1;
            for (int i = 0; i < sanPhamTrongGio.Count; ++i)
            {
                if (sanPhamTrongGio[i].sanPham.maSanPham == idSanPham)
                {
                    idx = i;
                    break;
                }
            }
            if (idx != -1)
            {
                sanPhamTrongGio[idx].soLuong++;
            } else
            {
                sanPhamTrongGio.Add(new SanPhamGioHang(1, sp));
            }
            HttpContext.Current.Session["GioHang"] = sanPhamTrongGio;
            int soLuong = (int) HttpContext.Current.Session["SoLuongSanPhamTrongGio"];
            soLuong++;
            HttpContext.Current.Session["SoLuongSanPhamTrongGio"] = soLuong;
            return "Đã thêm sản phẩm vào giỏ" + Environment.NewLine + "Tên sản phẩm: " + sp.tenSanPham;
        }
    }
}