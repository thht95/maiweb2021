using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ban_my_pham
{
    public class User
    {
        public int id { get; set; }
        public int role { get; set; }
        public string hoTen { get; set; }
        public DateTime ngaySinh { get; set; }
        public string diaChi { get; set; }
        public string soDienThoai { get; set; }
        public string email { get; set; }
        public string taiKhoan { get; set; }
        public string matKhau { get; set; }
        public User()
        {

        }

        public User(int id, int role, string hoTen, DateTime ngaySinh, string diaChi, string soDienThoai, string email, string taiKhoan, string matKhau)
        {
            this.id = id;
            this.role = role;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
            this.email = email;
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
        }

        public User(int role, string hoTen, DateTime ngaySinh, string diaChi, string soDienThoai, string email, string taiKhoan, string matKhau)
        {
            this.role = role;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
            this.email = email;
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
        }

    }
}
