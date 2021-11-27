using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ban_my_pham.db
{
    public class SanPhamDB
    {
        private static string cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static SqlConnection cnn = new SqlConnection(cnnString);

        #region Loại sản phẩm
        public static DataTable getLoaiSanPhamTheoId(int id)
        {
            DataTable result = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetLoaiSanPhamTheoId", cnn);
            cmd.Parameters.AddWithValue("@iLoaisanphamid", id);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static DataTable getAllLoaiSanPham()
        {
            DataTable result = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetAllLoaiSanPham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static bool tonTaiTenLoaiSanPham(string tenLoaiSanPham)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand("sp_checkTenLoaiSanPham", cnn);
            cmd.Parameters.Add(new SqlParameter("@sTenloaisanpham", tenLoaiSanPham));
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                DataTable dt = new DataTable();
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0) result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;

        }

        public static bool tonTaiTenLoaiSanPham(int id, string tenLoaiSanPham)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand("sp_checkTenLoaiSanPhamVoiId", cnn);
            cmd.Parameters.Add(new SqlParameter("@iLoaisanphamid", id));
            cmd.Parameters.Add(new SqlParameter("@sTenloaisanpham", tenLoaiSanPham));
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                DataTable dt = new DataTable();
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0) result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;

        }

        public static void addLoaiSanPham(string tenLoaiSanPham)
        {
            SqlCommand cmd = new SqlCommand("sp_ThemLoaiSanPham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sTenloaisanpham", tenLoaiSanPham);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
        }

        public static int suaLoaiSanPham(int id, string tenLoaiSanPham)
        {
            SqlCommand cmd = new SqlCommand("sp_SuaLoaiSanPham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iLoaisanphamid", id);
            cmd.Parameters.AddWithValue("@sTenloaisanpham", tenLoaiSanPham);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }
        #endregion

        #region mã giảm giá
        public static DataTable getMaGiamGiaById(int id)
        {
            DataTable result = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetMaGiamGiaTheoId", cnn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static DataTable getAllMaGiamGia()
        {
            DataTable result = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetALLMaGiamGia", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static DataTable getMaGiamGiaTheoMa(string maGiamGia)
        {
            DataTable result = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetMaGiamGiaTheoMa", cnn);
            cmd.Parameters.AddWithValue("@maGiamGia", maGiamGia);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static bool tonTaiMaGiamGia(string maGiamGia)
        {
            return getMaGiamGiaTheoMa(maGiamGia).Rows.Count > 0;
        }

        public static bool tonTaiMaGiamGia(int id, string maGiamGia)
        {
            DataTable result = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetMaGiamGiaTheoMaVaId", cnn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@maGiamGia", maGiamGia);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result.Rows.Count > 0;

        }

        public static int themMaGiamGia(string maGiamGia, double phanTramGiam, DateTime dNgaybatdau, DateTime dNgayketthuc)
        {
            SqlCommand cmd = new SqlCommand("sp_ThemMaGiamGia", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maGiamGia", maGiamGia);
            cmd.Parameters.AddWithValue("@phanTramGiam", phanTramGiam);
            cmd.Parameters.AddWithValue("@dNgaybatdau", dNgaybatdau);
            cmd.Parameters.AddWithValue("@dNgayketthuc", dNgayketthuc);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static int suaMaGiamGia(int id, string maGiamGia, double phanTramGiam, DateTime dNgaybatdau, DateTime dNgayketthuc)
        {
            SqlCommand cmd = new SqlCommand("sp_SuaMaGiamGia", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@maGiamGia", maGiamGia);
            cmd.Parameters.AddWithValue("@phanTramGiam", phanTramGiam);
            cmd.Parameters.AddWithValue("@dNgaybatdau", dNgaybatdau);
            cmd.Parameters.AddWithValue("@dNgayketthuc", dNgayketthuc);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }
        #endregion

        #region Hãng sản xuất
        public static DataTable getHangSanXuatById(int id)
        {
            DataTable result = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetHangSanXuatTheoId", cnn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static DataTable getAllHangSanXuat()
        {
            DataTable result = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetAllHangSanXuat", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static bool tonTaiTenHangSanXuat(string tenHangSanXuat)
        {
            DataTable result = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetHangSanXuatTheoTenHang", cnn);
            cmd.Parameters.AddWithValue("@tenHang", tenHangSanXuat);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result.Rows.Count > 0;
        }

        public static bool tonTaiTenHangSanXuat(int id, string tenHangSanXuat)
        {
            DataTable result = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_GetHangSanXuatTheoTenHangAndIdNot", cnn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@tenHang", tenHangSanXuat);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result.Rows.Count > 0;

        }

        public static int themHangSanXuat(string tenHangSanXuat, string diaChi, string sdt)
        {
            SqlCommand cmd = new SqlCommand("sp_ThemHangSanXuat", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tenHang", tenHangSanXuat);
            cmd.Parameters.AddWithValue("@diaChi", diaChi);
            cmd.Parameters.AddWithValue("@sdt", sdt);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static int suaHangSanXuat(int id, string tenHangSanXuat, string diaChi, string sdt)
        {
            SqlCommand cmd = new SqlCommand("sp_SuaHangSanXuat", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@tenHang", tenHangSanXuat);
            cmd.Parameters.AddWithValue("@diaChi", diaChi);
            cmd.Parameters.AddWithValue("@sdt", sdt);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }
        #endregion


        public static DataTable getTatCaSanPham()
        {
            SqlCommand cmd = new SqlCommand("GetAllSanPham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable result = new DataTable();
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static List<Product> getAllSanPham()
        {
            List<Product> products = new List<Product>();
            SqlCommand cmd = new SqlCommand("GetAllSanPham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int maSanpham = (int)reader[0];
                    int maNguoiTao = (int)reader[1];
                    DateTime ngaySanXuat = Convert.ToDateTime(reader[2]);
                    int hangSanXuat = (int)reader[3];
                    int loaiSanPham = (int)reader[4];
                    string tenSanPham = reader[5].ToString();
                    string xuatXu = reader[6].ToString();
                    string duongDanAnh = reader[7].ToString();
                    float giaBan = float.Parse(reader[8].ToString());
                    float phanTramGiamGia = float.Parse(reader[9].ToString());
                    int soLuong = (int)reader[10];
                    string moTaNgan = reader[11].ToString();
                    string moTaChiTiet = reader[12].ToString();
                    string tenHangSanxuat = reader[14].ToString();
                    products.Add(new Product(maSanpham, maNguoiTao, hangSanXuat, loaiSanPham, tenSanPham, ngaySanXuat, xuatXu, duongDanAnh, giaBan, phanTramGiamGia, soLuong, moTaNgan, moTaChiTiet, tenHangSanxuat));
                }
            }
            catch (Exception e) 
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return products;
        }

        public static List<Product> GetSanPhamByLoai(int maLoai, int limit = 0)
        {
            SqlCommand cmd = new SqlCommand("GetSanphamByLoai", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iLoaisanphamid", maLoai);
            cmd.Parameters.AddWithValue("@iLimit", limit);
            List<Product> products = new List<Product>();
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int maSanpham = (int)reader[0];
                    int maNguoiTao = (int)reader[1];
                    DateTime ngaySanXuat = Convert.ToDateTime(reader[2]);
                    int hangSanXuat = (int)reader[3];
                    int loaiSanPham = (int)reader[4];
                    string tenSanPham = reader[5].ToString();
                    string xuatXu = reader[6].ToString();
                    string duongDanAnh = reader[7].ToString();
                    float giaBan = float.Parse(reader[8].ToString());
                    float phanTramGiamGia = float.Parse(reader[9].ToString());
                    int soLuong = (int)reader[10];
                    string moTaNgan = reader[11].ToString();
                    string moTaChiTiet = reader[12].ToString();
                    string tenHangSanxuat = reader[14].ToString();
                    products.Add(new Product(maSanpham, maNguoiTao, hangSanXuat, loaiSanPham, tenSanPham, ngaySanXuat, xuatXu, duongDanAnh, giaBan, phanTramGiamGia, soLuong, moTaNgan, moTaChiTiet, tenHangSanxuat));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return products;
        }

        public static Product GetSanPhamById(int id)
        {
            SqlCommand cmd = new SqlCommand("GetSanPhamById", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iSanphamid", id);
            Product product = null;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int maSanpham = (int)reader[0];
                    int maNguoiTao = (int)reader[1];
                    DateTime ngaySanXuat = Convert.ToDateTime(reader[2]);
                    int hangSanXuat = (int)reader[3];
                    int loaiSanPham = (int)reader[4];
                    string tenSanPham = reader[5].ToString();
                    string xuatXu = reader[6].ToString();
                    string duongDanAnh = reader[7].ToString();
                    float giaBan = float.Parse(reader[8].ToString());
                    float phanTramGiamGia = float.Parse(reader[9].ToString());
                    int soLuong = (int)reader[10];
                    string moTaNgan = reader[11].ToString();
                    string moTaChiTiet = reader[12].ToString();
                        string tenHangSanxuat = reader[14].ToString();
                    product = new Product(maSanpham, maNguoiTao, hangSanXuat, loaiSanPham, tenSanPham, ngaySanXuat, xuatXu, duongDanAnh, giaBan, phanTramGiamGia, soLuong, moTaNgan, moTaChiTiet, tenHangSanxuat);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return product;
        }

        public static List<Product> GetSanPhamMoi(int limit)
        {
            SqlCommand cmd = new SqlCommand("GetSanPhamMoi", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iLimit", limit);
            List<Product> products = new List<Product>();
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int maSanpham = (int)reader[0];
                    int maNguoiTao = (int)reader[1];
                    DateTime ngaySanXuat = Convert.ToDateTime(reader[2]);
                    int hangSanXuat = (int)reader[3];
                    int loaiSanPham = (int)reader[4];
                    string tenSanPham = reader[5].ToString();
                    string xuatXu = reader[6].ToString();
                    string duongDanAnh = reader[7].ToString();
                    float giaBan = float.Parse(reader[8].ToString());
                    float phanTramGiamGia = float.Parse(reader[9].ToString());
                    int soLuong = (int)reader[10];
                    string moTaNgan = reader[11].ToString();
                    string moTaChiTiet = reader[12].ToString();
                    string tenHangSanxuat = reader[14].ToString();
                    products.Add(new Product(maSanpham, maNguoiTao, hangSanXuat, loaiSanPham, tenSanPham, ngaySanXuat, xuatXu, duongDanAnh, giaBan, phanTramGiamGia, soLuong, moTaNgan, moTaChiTiet, tenHangSanxuat));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return products;
        }

        public static List<Product> GetSanPhamKhuyenMai(int limit)
        {
            SqlCommand cmd = new SqlCommand("GetSanPhamKhuyenMai", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iLimit", limit);
            List<Product> products = new List<Product>();
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int maSanpham = (int)reader[0];
                    int maNguoiTao = (int)reader[1];
                    DateTime ngaySanXuat = Convert.ToDateTime(reader[2]);
                    int hangSanXuat = (int)reader[3];
                    int loaiSanPham = (int)reader[4];
                    string tenSanPham = reader[5].ToString();
                    string xuatXu = reader[6].ToString();
                    string duongDanAnh = reader[7].ToString();
                    float giaBan = float.Parse(reader[8].ToString());
                    float phanTramGiamGia = float.Parse(reader[9].ToString());
                    int soLuong = (int)reader[10];
                    string moTaNgan = reader[11].ToString();
                    string moTaChiTiet = reader[12].ToString();
                    string tenHangSanxuat = reader[14].ToString();
                    products.Add(new Product(maSanpham, maNguoiTao, hangSanXuat, loaiSanPham, tenSanPham, ngaySanXuat, xuatXu, duongDanAnh, giaBan, phanTramGiamGia, soLuong, moTaNgan, moTaChiTiet, tenHangSanxuat));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return products;
        }

        public static List<ProductType> getListLoaiSanPham()
        {
            List<ProductType> productTypes = new List<ProductType>();
            SqlCommand cmd = new SqlCommand("sp_GetAllLoaiSanPham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int maLoaiSanPham = (int)reader[0];
                    string tenLoaiSanPham = reader[1].ToString();
                    productTypes.Add(new ProductType(maLoaiSanPham, tenLoaiSanPham));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return productTypes;
        }

        public static DataTable GetSanPhamTheoId(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_GetSanPhamTheoId", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            DataTable result = new DataTable();
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static ProductType getLoaiSanPham(int id)
        {
            ProductType productType = null;
            SqlCommand cmd = new SqlCommand("sp_GetLoaiSanPhamTheoId", cnn);
            cmd.Parameters.AddWithValue("@iLoaisanphamid", id);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int maLoaiSanPham = (int)reader[0];
                    string tenLoaiSanPham = reader[1].ToString();
                    productType = new ProductType(maLoaiSanPham, tenLoaiSanPham);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return productType;
        }

        public static List<Product> TimKiemSanPham(string timKiem, int limit)
        {
            SqlCommand cmd = new SqlCommand("sp_TimKiemSanPham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sTensanpham", timKiem);
            cmd.Parameters.AddWithValue("@iLimit", limit);
            List<Product> products = new List<Product>();
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int maSanpham = (int)reader[0];
                    int maNguoiTao = (int)reader[1];
                    DateTime ngaySanXuat = Convert.ToDateTime(reader[2]);
                    int hangSanXuat = (int)reader[3];
                    int loaiSanPham = (int)reader[4];
                    string tenSanPham = reader[5].ToString();
                    string xuatXu = reader[6].ToString();
                    string duongDanAnh = reader[7].ToString();
                    float giaBan = float.Parse(reader[8].ToString());
                    float phanTramGiamGia = float.Parse(reader[9].ToString());
                    int soLuong = (int)reader[10];
                    string moTaNgan = reader[11].ToString();
                    string moTaChiTiet = reader[12].ToString();
                    string tenHangSanxuat = reader[14].ToString();
                    products.Add(new Product(maSanpham, maNguoiTao, hangSanXuat, loaiSanPham, tenSanPham, ngaySanXuat, xuatXu, duongDanAnh, giaBan, phanTramGiamGia, soLuong, moTaNgan, moTaChiTiet, tenHangSanxuat));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return products;
        }

        public static DataTable TimKiemSanPhamTheoTen(string tenSanPham)
        {
            SqlCommand cmd = new SqlCommand("sp_TimKiemSanPham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sTenSanPham", tenSanPham);
            DataTable result = new DataTable();
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static bool tonTaiTenSanPham(string tenSanPham)
        {
            SqlCommand cmd = new SqlCommand("sp_GetSanPhamTheoTen", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tenSanPham", tenSanPham);
            DataTable result = new DataTable();
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result.Rows.Count > 0;
        }

        public static List<Coupon> getListMaGiamGia()
        {
            List<Coupon> coupons = new List<Coupon>();
            SqlCommand cmd = new SqlCommand("sp_GetALLMaGiamGia", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int maCoupon = (int)reader[0];
                    int nguoiTaoId = (int)reader[1];
                    string maGiamGia = reader[2].ToString();
                    float phanTramGiam = float.Parse(reader[3].ToString());
                    DateTime ngayBatDau = Convert.ToDateTime(reader[4]);
                    DateTime ngayKetThuc = Convert.ToDateTime(reader[5]);
                    DateTime now = DateTime.Now;
                    if (now.CompareTo(ngayBatDau) > 0 && now.CompareTo(ngayKetThuc) < 0)
                    {
                        coupons.Add(new Coupon(maCoupon, nguoiTaoId, maGiamGia, phanTramGiam, ngayBatDau, ngayKetThuc));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return coupons;
        }

        public static bool tonTaiTenSanPham(int id, string tenSanPham)
        {
            SqlCommand cmd = new SqlCommand("sp_GetSanPhamTheoTenAndIdNot", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@tenSanPham", tenSanPham);
            DataTable result = new DataTable();
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result.Rows.Count > 0;
        }

        public static int themSanPham(
            int nguoiTaoId,
            DateTime ngaySanXuat,
            int hangSanPhamId,
            int iLoaiSanPhamId,
            string tenSanPham,
            string xuatXu,
            string imageUrl,
            double giaBan,
            int soLuong,
            string moTaNgan,
            string thongTinChiTiet)
        {
            SqlCommand cmd = new SqlCommand("ThemSanPham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iNguoiTao", nguoiTaoId);
            cmd.Parameters.AddWithValue("@dNgaysanxuat", ngaySanXuat);
            cmd.Parameters.AddWithValue("@fPhantramgiamgia", 0); // tạo sản phẩm thì mặc định không giảm giá
            cmd.Parameters.AddWithValue("@iHangsanphamid", hangSanPhamId);
            cmd.Parameters.AddWithValue("@iLoaisanphamid", iLoaiSanPhamId);
            cmd.Parameters.AddWithValue("@sTensanpham", tenSanPham);
            cmd.Parameters.AddWithValue("@sXuatxu", xuatXu);
            cmd.Parameters.AddWithValue("@sImageurl", imageUrl);
            cmd.Parameters.AddWithValue("@mGiaban", giaBan);
            cmd.Parameters.AddWithValue("@iSoluong", soLuong);
            cmd.Parameters.AddWithValue("@sMotangan", moTaNgan);
            cmd.Parameters.AddWithValue("@sThongtinchitiet", thongTinChiTiet);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static int suaSanPham(
            int sanPhamId,
            DateTime ngaySanXuat,
            double phanTramGiamGia,
            int hangSanPhamId,
            int iLoaiSanPhamId,
            string tenSanPham,
            string xuatXu,
            string imageUrl,
            double giaBan,
            int soLuong,
            string moTaNgan,
            string thongTinChiTiet)
        {
            SqlCommand cmd = new SqlCommand("SuaSanPham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iSanphamid", sanPhamId);
            cmd.Parameters.AddWithValue("@dNgaysanxuat", ngaySanXuat);
            cmd.Parameters.AddWithValue("@fPhantramgiamgia", phanTramGiamGia);
            cmd.Parameters.AddWithValue("@iHangsanphamid", hangSanPhamId);
            cmd.Parameters.AddWithValue("@iLoaisanphamid", iLoaiSanPhamId);
            cmd.Parameters.AddWithValue("@sTensanpham", tenSanPham);
            cmd.Parameters.AddWithValue("@sXuatxu", xuatXu);
            cmd.Parameters.AddWithValue("@sImageurl", imageUrl);
            cmd.Parameters.AddWithValue("@mGiaban", giaBan);
            cmd.Parameters.AddWithValue("@iSoluong", soLuong);
            cmd.Parameters.AddWithValue("@sMotangan", moTaNgan);
            cmd.Parameters.AddWithValue("@sThongtinchitiet", thongTinChiTiet);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static int xoaHangSanXuat(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_xoaHangSanXuatTheoId", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = 0;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static int xoaLoaiSanPham(int id)
        {
            SqlCommand cmd = new SqlCommand("xoasp", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = 0;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static int xoaSanPham(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_xoaSanPhamTheoId", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = 0;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static int xoaMaGiamGia(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_xoaMaGiamTheoId", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = 0;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        public static int xoaUser(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_xoaUserTheoId", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = 0;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        // them lich su mua hang
        public static int themLichSuMuaHang(int userId, DateTime ngayMua, double tongTien)
        {
            SqlCommand cmd = new SqlCommand("sp_ThemLichSuMuaHang", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iNguoimuaid", userId);
            cmd.Parameters.AddWithValue("@dNgaymua", ngayMua);
            cmd.Parameters.AddWithValue("@fTongtien", tongTien);
            cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            int result = 0;
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@NewId"].Value);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        // get lich su mua hang
        public static DataTable GetLichSuMuaHang(int userId)
        {
            SqlCommand cmd = new SqlCommand("sp_GetLichSuMuaHang", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iNguoimuaid", userId);
            DataTable result = new DataTable();
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        // them chi tiet mua hang
        public static int themChiTietMuaHang(int muaHangId, int sanPhamId, int soLuong, double donGia)
        {
            SqlCommand cmd = new SqlCommand("sp_ThemChiTietMuaHang", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iMuahangid", muaHangId);
            cmd.Parameters.AddWithValue("@iSanphamid", sanPhamId);
            cmd.Parameters.AddWithValue("@iSoluongmua", soLuong);
            cmd.Parameters.AddWithValue("@mDongia", donGia);
            int result = 0;
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = 0;
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

    }
}