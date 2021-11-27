using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ban_my_pham
{
    public class Coupon
    {
        public int maCoupon { get; set; }
        public int nguoiTao { get; set; }
        public string maGiamGia { get; set; }
        public float phanTramGiamGia { get; set; }
        public DateTime ngayBatDau { get; set; }
        public DateTime ngayKetThuc { get; set; }
        public Coupon() { }
        public Coupon(int maCoupon, int nguoiTao, string maGiamGia, float phanTramGiamGia, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            this.maCoupon = maCoupon;
            this.nguoiTao = nguoiTao;
            this.maGiamGia = maGiamGia;
            this.phanTramGiamGia = phanTramGiamGia;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }
    }
}