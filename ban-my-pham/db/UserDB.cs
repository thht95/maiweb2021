using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ban_my_pham
{
    public class UserDB
    {
        private static string cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static SqlConnection cnn = new SqlConnection(cnnString);

        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            SqlCommand cmd = new SqlCommand("GetAllUsers", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]),
                        reader[2].ToString(), Convert.ToDateTime(reader[3]),
                        reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString()));
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
            return users;
        }

        public static void addOrUpdateUser(User user)
        {
            bool isCreate = (user.id == 0);
            SqlCommand cmd;
            if (isCreate)
            {
                cmd = new SqlCommand("AddUser", cnn);
                cmd.Parameters.Add(new SqlParameter("@sTaiKhoan", user.taiKhoan));
                cmd.Parameters.Add(new SqlParameter("@sMatKhau", user.matKhau));
            }
            else
            {
                cmd = new SqlCommand("UpdateUser", cnn);
                cmd.Parameters.Add(new SqlParameter("@iUserid", user.id));
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@iQuyenid", user.role));
            cmd.Parameters.Add(new SqlParameter("@sHoten", user.hoTen));
            cmd.Parameters.Add(new SqlParameter("@dNgaySinh", user.ngaySinh));
            cmd.Parameters.Add(new SqlParameter("@sDiachi", user.diaChi));
            cmd.Parameters.Add(new SqlParameter("@sSdt", user.soDienThoai));
            cmd.Parameters.Add(new SqlParameter("@sEmail", user.email));
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

        public static bool authenticate(string taiKhoan, string matKhau)
        {
            bool result = false;
            List<User> users = new List<User>();
            SqlCommand cmd = new SqlCommand("GetByTaiKhoanAndMatKhau", cnn);
            cmd.Parameters.Add(new SqlParameter("@sTaiKhoan", taiKhoan));
            cmd.Parameters.Add(new SqlParameter("@sMatKhau", matKhau));
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result = true;
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
            return result;
        }

        public static User getById(int id)
        {
            User user = null;
            SqlCommand cmd = new SqlCommand("sp_GetUserById", cnn);
            cmd.Parameters.Add(new SqlParameter("@userId", id));
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user = new User(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]),
                        reader[2].ToString(), Convert.ToDateTime(reader[3]),
                        reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString());
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
            return user;
        }


        public static User getByUsername(string taiKhoan)
        {
            User user = null;
            SqlCommand cmd = new SqlCommand("GetByTaiKhoan", cnn);
            cmd.Parameters.Add(new SqlParameter("@sTaiKhoan", taiKhoan));
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user = new User(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]),
                        reader[2].ToString(), Convert.ToDateTime(reader[3]),
                        reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString());
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
            return user;
        }

        public static bool taiKhoanDaTonTai(string taiKhoan)
        {
            return (getByUsername(taiKhoan) != null);
        }

        public static bool taiKhoanDaTonTai(int id, string taiKhoan)
        {
            User user = null;
            SqlCommand cmd = new SqlCommand("sp_getUserByTaiKhoanAndIdNot", cnn);
            cmd.Parameters.Add(new SqlParameter("@sTaiKhoan", taiKhoan));
            cmd.Parameters.Add(new SqlParameter("@userId", id));
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user = new User(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]),
                        reader[2].ToString(), Convert.ToDateTime(reader[3]),
                        reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString());
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
            return user != null;
        }

        public static User getByEmail(string email)
        {
            User user = null;
            SqlCommand cmd = new SqlCommand("GetByEmail", cnn);
            cmd.Parameters.Add(new SqlParameter("@sEmail", email));
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user = new User(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]),
                        reader[2].ToString(), Convert.ToDateTime(reader[3]),
                        reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString());
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
            return user;
        }
        public static bool emailDaTonTai(string email)
        {
            return (getByEmail(email) != null);
        }

        public static bool emailDaTonTai(int id, string email)
        {
            User user = null;
            SqlCommand cmd = new SqlCommand("sp_getByEmailAndIdNot", cnn);
            cmd.Parameters.Add(new SqlParameter("@sEmail", email));
            cmd.Parameters.Add(new SqlParameter("@userId", id));
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user = new User(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]),
                        reader[2].ToString(), Convert.ToDateTime(reader[3]),
                        reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString());
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
            return user != null;
        }

        public static void doiMatKhau(string taiKhoan, string matKhau)
        {
            SqlCommand cmd = new SqlCommand("ChangePassword", cnn);
            cmd.Parameters.Add(new SqlParameter("@sTaikhoan", taiKhoan));
            cmd.Parameters.Add(new SqlParameter("@sMatkhau", matKhau));
            cmd.CommandType = CommandType.StoredProcedure;
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
    }
}