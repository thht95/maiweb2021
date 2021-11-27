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
    public partial class SuaHangSanXuat : System.Web.UI.Page
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
                    Response.Redirect("/admin/DanhSachHangSanXuat.aspx");
                }
                if (id <= 0)
                {
                    Response.Redirect("/admin/DanhSachHangSanXuat.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        DataTable hangSanxuat = SanPhamDB.getHangSanXuatById(id);
                        if (hangSanxuat.Rows.Count > 0)
                        {
                            txtTenHangSanXuat.Value = hangSanxuat.Rows[0]["sTenhang"].ToString();
                            txtDiaChi.Value = hangSanxuat.Rows[0]["sDiachi"].ToString();
                            txtSdt.Value = hangSanxuat.Rows[0]["sSdt"].ToString();
                        }
                        else
                        {
                            Response.Redirect("/admin/DanhSachHangSanXuat.aspx");
                        }
                    }
                    else
                    {
                        string tenHangSanXuat = txtTenHangSanXuat.Value.Trim();
                        string diaChi = txtDiaChi.Value.Trim();
                        string sdt = txtSdt.Value.Trim();
                        if (SanPhamDB.tonTaiTenHangSanXuat(id, tenHangSanXuat))
                        {
                            CustomValidator1.IsValid = false;
                            CustomValidator1.ErrorMessage = "Tên hãng sản xuất đã tồn tại";
                        }
                        else
                        {
                            try
                            {
                                int result = SanPhamDB.suaHangSanXuat(id, tenHangSanXuat, diaChi, sdt);
                                if (result > 0)
                                {
                                    Response.Write("<script>alert('Sửa hãng sản xuất thành công');" +
                                    "location='/admin/DanhSachHangSanXuat.aspx';</script>");
                                }
                                else
                                {
                                    Response.Write("<script>alert('Sửa hãng sản xuất thất bại');</script>");
                                }

                            }
                            catch
                            {
                                Response.Write("<script>alert('Sửa hãng sản xuất thất bại');</script>");
                            }
                        }

                    }
                }
            }
            else
            {
                Response.Redirect("/admin/DanhSachHangSanXuat.aspx");
            }
        }
    }
}