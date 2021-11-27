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
    public partial class DanhSachSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dtAllSanPham = SanPhamDB.getTatCaSanPham();
                DataTable dtCloned = dtAllSanPham.Clone();
                NumberFormatInfo nfi = new CultureInfo("vi-VN", false).NumberFormat;
                nfi.CurrencyDecimalDigits = 0;
                if (dtAllSanPham.Rows.Count > 0)
                {
                    dtCloned.Columns["mGiaban"].DataType = typeof(string);
                    foreach(DataRow row in dtAllSanPham.Rows) dtCloned.ImportRow(row);
                    
                    foreach (DataRow row in dtCloned.Rows) row["mGiaban"] = Convert.ToDouble(row["mGiaban"]).ToString("C", nfi);
                }
                lvSanPham.DataSource = dtCloned;
                lvSanPham.DataBind();
            }
        }
    }
}