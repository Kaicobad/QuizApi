using System;
using System.Collections.Generic;
using System.Data;
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
           
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=LYCAN\\SQLEXPRESS;Database=GpQuizDB;uid=sa;password=1234;Trusted_Connection=True;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "delete from UserInfo where UserId = '" + userinfo.UserId + "' ";

            try
            {
                cmd.ExecuteNonQuery();
                return "Deleted !";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<UserInfoModel> GetAll()
        {
            List<UserInfoModel> list = new List<UserInfoModel>();

            DataTable dt = new DataTable();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=LYCAN\\SQLEXPRESS;Database=GpQuizDB;uid=sa;password=1234;Trusted_Connection=True;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from UserInfo";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserInfoModel um = new UserInfoModel();

                um.UserId =  Guid.Parse(dt.Rows[i]["UserId"].ToString());
                um.UserName = dt.Rows[i]["UserName"].ToString();
                um.ImageUrl = dt.Rows[i]["ImageUrl"].ToString();
                um.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
                um.Gender = dt.Rows[i]["Gender"].ToString();
                um.DateOfBirth = (DateTime)dt.Rows[i]["DateOfBirth"];
                um.CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                um.ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];

                list.Add(um);
            }
            return list;
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
