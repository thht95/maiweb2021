using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class XemSanPham : System.Web.UI.Page
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
                    Response.Redirect("/admin/DanhSachSanPham.aspx");
                }
                if (id <= 0)
                {
                    Response.Redirect("/admin/DanhSachSanPham.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        DataTable sanPham = SanPhamDB.GetSanPhamTheoId(id);
                        if (sanPham.Rows.Count > 0)
                        {
                            DataTable thuongHieu = SanPhamDB.getHangSanXuatById(Convert.ToInt32(sanPham.Rows[0]["iHangsanphamid"]));
                            DataTable loaiSanPham = SanPhamDB.getLoaiSanPhamTheoId(Convert.ToInt32(sanPham.Rows[0]["iLoaisanphamid"]));
                            if (thuongHieu != null && thuongHieu.Rows.Count > 0)
                            {
                                txtThuongHieu.Value = thuongHieu.Rows[0]["sTenhang"].ToString();
                            }
                            if (loaiSanPham != null && loaiSanPham.Rows.Count > 0)
                            {
                                txtLoaiSanPham.Value = loaiSanPham.Rows[0]["sTenloaisanpham"].ToString();
                            }
                            txtNgaySanXuat.Value = Convert.ToDateTime(sanPham.Rows[0]["dNgaysanxuat"]).ToString("yyyy-MM-dd");
                            txtTenSanPham.Value = sanPham.Rows[0]["sTensanpham"].ToString();
                            txtXuatXu.Value = sanPham.Rows[0]["sXuatxu"].ToString();
                            NumberFormatInfo nfi = new CultureInfo("vi-VN", false).NumberFormat;
                            nfi.CurrencyDecimalDigits = 0;
                            txtGiaBan.Value = Convert.ToDouble(sanPham.Rows[0]["mGiaban"]).ToString("C", nfi);
                            txtSoLuong.Value = sanPham.Rows[0]["iSoluong"].ToString();
                            txtMoTaNgan.Value = sanPham.Rows[0]["sMotangan"].ToString();
                            txtThongTinChiTiet.Value = sanPham.Rows[0]["sThongtinchitiet"].ToString();
                            view_image.Src = sanPham.Rows[0]["sImageurl"].ToString();
                        }
                        else
                        {
                            Response.Redirect("/admin/DanhSachSanPham.aspx");
                        }
                    }
                }
            }
            else
            {

                Response.Redirect("/admin/DanhSachLoaiSanPham.aspx");
            }
        }
    }
}