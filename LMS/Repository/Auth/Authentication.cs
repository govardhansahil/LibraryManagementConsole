using DomainLayer;
using DomainLayer.Models;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Repository.Auth
{
    internal class Authentication : IAuthentication
    {
         string dbstring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        public int Authenticate(AuthModel obj)
        {
            int _checkStatus=0;
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                SqlCommand cmd = new SqlCommand("CheckUser", connection);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@password", obj.Password);
                    connection.Open();
                    _checkStatus = (int)cmd.ExecuteScalar();

                }
                catch
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
            return _checkStatus;
            /*if(StaticDatabase._usersList.Any(m => m.Email == obj.Email && m.Password == obj.Password && m.IsAdmin == true && m.IsActive == true))
            {
            return 1;
            }
            else if(StaticDatabase._usersList.Any(m => m.Email == obj.Email && m.Password == obj.Password && m.IsAdmin == false && m.IsActive == true ))
            {
            return 2;
            }
            return 3;*/
            
        }

        public string Register(UserModel obj)
        {
            using (SqlConnection connection=new SqlConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AddUser", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", obj.Name);
                    cmd.Parameters.AddWithValue("@usermail", obj.Email);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return StringLiterals.RegisteredMsg;

                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            /*StaticDatabase._usersList.Add(obj);
            return StringLiterals.RegisteredMsg;*/
        }
     }
}