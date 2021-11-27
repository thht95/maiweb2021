using ban_my_pham.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ban_my_pham.admin
{
    public partial class ThemMaGiamGia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string maGiamGia = txtMaGiamGia.Value.Trim();
                double phanTramGiam = Convert.ToDouble(txtPhanTramGiamGia.Value);
                DateTime ngayBatDau = Convert.ToDateTime(txtNgayBatDau.Value);
                DateTime ngayKetThuc = Convert.ToDateTime(txtNgayKetThuc.Value);
                if (SanPhamDB.tonTaiMaGiamGia(maGiamGia))
                {
                    CustomValidator1.IsValid = false;
                    CustomValidator1.ErrorMessage = "Mã giảm giá đã tồn tại";
                }
                else
                {
                    try
                    {
                        SanPhamDB.themMaGiamGia(maGiamGia, phanTramGiam, ngayBatDau, ngayKetThuc);
                        Response.Write("<script>alert('Thêm mã giảm giá thành công');" +
                            "location='/admin/DanhSachMaGiamGia.aspx';</script>");
                    }
                    catch
                    {
                        Response.Write("<script>alert('Thêm mã giảm giá thất bại');</script>");
                    }
                }
            }

        }
    }
}