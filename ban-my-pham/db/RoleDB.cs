using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ban_my_pham
{
    public class RoleDB
    {
        private static string cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static SqlConnection cnn = new SqlConnection(cnnString);

        public static Role GetRoleByRoleName(string roleName)
        {
            Role role = null;
            SqlCommand cmd = new SqlCommand("GetRoleByName", cnn);
            cmd.Parameters.Add(new SqlParameter("@sTenQuyen", roleName));
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    role = new Role(Convert.ToInt32(reader[0]), reader[1].ToString());
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
            return role;
        }

        public static Role getRoleById(int id)
        {
            Role role = null;
            SqlCommand cmd = new SqlCommand("sp_getRoleById", cnn);
            cmd.Parameters.Add(new SqlParameter("@roleId", id));
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    role = new Role(Convert.ToInt32(reader[0]), reader[1].ToString());
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
            return role;
        }

        public static List<Role> getAllRoles()
        {
            List<Role> roles = new List<Role>();
            SqlCommand cmd = new SqlCommand("GetAllRole", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(new Role(Convert.ToInt32(reader[0]), reader[1].ToString()));
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
            return roles;
        }
    }
}