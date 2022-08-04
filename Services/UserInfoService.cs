using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Interface;

namespace Services
{
    public class UserInfoService : IUserInfo
    {
        //public UserInfoService(IConfiguration)
        //{

        //}
        public string Insert(UserInfoModel userinfo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=LYCAN\\SQLEXPRESS;Database=GpQuizDB;uid=sa;password=1234;Trusted_Connection=True;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText ="INSERT INTO UserInfo (UserId,UserName,ImageUrl,PhoneNumber,Gender,DateOfBirth,CreatedDate,ModifiedDate)"
                            + "VALUES('" + userinfo.UserId + "', '" + userinfo.UserName + "', '" + userinfo.ImageUrl + "',"
                            + "'" + userinfo.PhoneNumber + "', '" + userinfo.Gender + "', '" + userinfo.DateOfBirth + "'," +
                            "'" + userinfo.CreatedDate + "', '" + userinfo.ModifiedDate + "') ";
            
            try
            {
                cmd.ExecuteNonQuery();
                return "Success !";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string Update(UserInfoModel userinfo)
        {
            throw new NotImplementedException();
        }

        public string Delete(UserInfoModel userinfo)
        {
            throw new NotImplementedException();
        }

        public List<UserInfoModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<UserInfoModel> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public int GetCountByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
