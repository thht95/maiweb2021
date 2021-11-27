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
    public partial class ThanhToan : System.Web.UI.Page
    {
        public double tongTien = 0;
        public double giamGia = 0;
        public User user = null;
        public List<SanPhamGioHang> sanPhamTrongGioHang;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["LoggedIn"]))
            {
                Response.Write("<script>alert('Bạn cần đăng nhập để thanh toán');" +
                    "location.href='/DangNhap.aspx';</script>");
            }
            else
            {
                user = (User)Session["User"];
                if (user == null)
                {
                    Response.Write("<script>alert('Đã có lỗi xảy ra!');" +
                    "location.href='/TrangChu.aspx';</script>");
                }
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
            if (Page.IsPostBack)
            {
                if (Session["TongTien"] != null)
                {
                    tongTien = Convert.ToDouble(Session["TongTien"]);
                }
                if (Request.Form["ctl00$ContentPlaceHolder1$Button2"] != null)
                {
                    // áp dụng mã giảm giá
                    string ma = txtMaGiamGia.Value;
                    if (ma == null || ma.Trim().Length < 1)
                    {
                        CustomValidator1.IsValid = false;
                        CustomValidator1.ErrorMessage = "Vui lòng nhập mã giảm giá để áp dụng";
                    } else
                    {
                        DataTable maGiamGia = SanPhamDB.getMaGiamGiaTheoMa(ma);
                        if (maGiamGia.Rows.Count > 0)
                        {

                            if (Convert.ToDateTime(maGiamGia.Rows[0]["dThoigianketthuc"]) < DateTime.Now.Date)
                            {
                                CustomValidator1.IsValid = false;
                                CustomValidator1.ErrorMessage = "Mã giảm giá này đã hết hạn";
                            }
                            else
                            {
                                if (Session["TongTien"] != null)
                                {
                                    tongTien = Convert.ToDouble(Session["TongTien"]);
                                }
                                giamGia = Convert.ToDouble(maGiamGia.Rows[0]["fPhantramgiam"]);
                                Session["giamGia"] = giamGia;
                                tongTien = tongTien * (1 - giamGia / 100.0);
                            }

                        }
                        else
                        {
                            CustomValidator1.IsValid = false;
                            CustomValidator1.ErrorMessage = "Mã giảm giá này không tồn tại";
                        }
                    }
                    
                }
                if (Request.Form["ctl00$ContentPlaceHolder1$Button1"] != null)
                {
                    giamGia = Convert.ToDouble(Session["giamGia"]);
                    if (giamGia > 0)
                    {
                        tongTien = tongTien * (1 - giamGia/100.0);
                    }
                    int muaHangId = SanPhamDB.themLichSuMuaHang(user.id, DateTime.Now, tongTien);
                    if (muaHangId < 1)
                    {
                        Response.Write("<script>alert('Thanh toán thất bại');</script>");
                    }
                    foreach(SanPhamGioHang sp in sanPhamTrongGioHang)
                    {
                        SanPhamDB.themChiTietMuaHang(muaHangId, sp.sanPham.maSanPham, sp.soLuong, sp.sanPham.giaBan * (1 - sp.sanPham.phanTramGiamGia / 100));
                    }
                    Session["GioHang"] = new List<SanPhamGioHang>();
                    Session["SoLuongSanPhamTrongGio"] = 0;
                    Response.Write("<script>alert('Thanh toán thành công');" +
                        "location.href='/TrangChu.aspx';</script>");
                }
                
            } else
            {
                if (user != null)
                {
                    txtHoTen.Value = user.hoTen;
                    txtDiaChiGiaoHang.Value = user.diaChi;
                    txtSdt.Value = user.soDienThoai;
                }
                if (Session["TongTien"] != null)
                {
                    tongTien = Convert.ToDouble(Session["TongTien"]);
                }
            }
            
        }
    }
}