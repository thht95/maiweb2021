using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ban_my_pham
{
    public class ProductType
    {
        public int maLoaiSanPham { get; set; }
        public string tenLoaiSanPham { get; set; }

        public ProductType() { }

        public ProductType(int maLoaiSanPham, string tenLoaiSanPham)
        {
            this.maLoaiSanPham = maLoaiSanPham;
            this.tenLoaiSanPham = tenLoaiSanPham;
        }
    }
}