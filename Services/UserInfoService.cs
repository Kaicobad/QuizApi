using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
using Interface;

namespace Services
{
    public class UserInfoService : DataBaseContext, IUserInfo
    {
        public string Insert(UserInfoModel userinfo)
        {
            CustomCommand = CustomCommandBuilder(@"INSERT INTO UserInfo (UserName,ImageUrl,
            PhoneNumber,Gender,DateOfBirth,CreatedDate,ModifiedDate) VALUES(@UserName, 
            @ImageUrl, @PhoneNumber, @Gender, @DateOfBirth,@CreatedDate, @ModifiedDate) ");

            //CustomCommand.Parameters.AddWithValue("@UserId", userinfo.UserId);
            CustomCommand.Parameters.AddWithValue("@UserName", userinfo.UserName);
            CustomCommand.Parameters.AddWithValue("@ImageUrl", userinfo.ImageUrl);
            CustomCommand.Parameters.AddWithValue("@PhoneNumber", userinfo.PhoneNumber);
            CustomCommand.Parameters.AddWithValue("@Gender", userinfo.Gender);
            CustomCommand.Parameters.AddWithValue("@DateOfBirth", userinfo.DateOfBirth);
            CustomCommand.Parameters.AddWithValue("@CreatedDate", userinfo.CreatedDate);
            CustomCommand.Parameters.AddWithValue("@ModifiedDate", userinfo.ModifiedDate);

            try
            {
                ExecuteNonQuery(CustomCommand);
                return "Success !";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string Update(UserInfoModel userinfo)
        {
            CustomCommand = CustomCommandBuilder(@"UPDATE UserInfo SET UserName = @UserName, 
            ImageUrl = @ImageUrl, PhoneNumber = @PhoneNumber, Gender = @Gender, DateOfBirth = @DateOfBirth,
            CreatedDate = @CreatedDate, ModifiedDate = @ModifiedDate WHERE UserId = @UserId");

            CustomCommand.Parameters.AddWithValue("@UserId", userinfo.UserId);
            CustomCommand.Parameters.AddWithValue("@UserName", userinfo.UserName);
            CustomCommand.Parameters.AddWithValue("@ImageUrl", userinfo.ImageUrl);
            CustomCommand.Parameters.AddWithValue("@PhoneNumber", userinfo.PhoneNumber);
            CustomCommand.Parameters.AddWithValue("@Gender", userinfo.Gender);
            CustomCommand.Parameters.AddWithValue("@DateOfBirth", userinfo.DateOfBirth);
            CustomCommand.Parameters.AddWithValue("@CreatedDate", userinfo.CreatedDate);
            CustomCommand.Parameters.AddWithValue("@ModifiedDate", userinfo.ModifiedDate);

            try
            {
                ExecuteNonQuery(CustomCommand);
                return "Success !";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string Delete(UserInfoModel userinfo)
        {
            CustomCommand = CustomCommandBuilder(@"delete from UserInfo where UserId = @UserId ");
            CustomCommand.Parameters.AddWithValue("@UserId", userinfo.UserId);
            try
            {
                ExecuteNonQuery(CustomCommand);
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


            //_DataBaseContext.DbConnection();

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

                um.UserId = Guid.Parse(dt.Rows[i]["UserId"].ToString());
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

        public List<UserInfoModel> GetByUserId(UserInfoModel userinfo)
        {
            List<UserInfoModel> list = new();

            CustomCommand = CustomCommandBuilder(@"select UserName, ImageUrl, PhoneNumber, Gender, DateOfBirth,
            CreatedDate, ModifiedDate from UserInfo WHERE UserId = @UserId");

            CustomCommand.Parameters.AddWithValue("@UserId", userinfo.UserId);

            CustomReader = CustomCommand.ExecuteReader();

            while (CustomReader.Read())
            {
                userinfo.UserId = Guid.Parse(CustomReader["UserId"].ToString());
                userinfo.UserName = CustomReader["UserName"].ToString();
                userinfo.ImageUrl = CustomReader["ImageUrl"].ToString();
                userinfo.PhoneNumber = CustomReader["PhoneNumber"].ToString();
                userinfo.Gender = CustomReader["Gender"].ToString();
                userinfo.DateOfBirth = (DateTime)(CustomReader["DateOfBirth"]);
                userinfo.CreatedDate = (DateTime)(CustomReader["CreatedDate"]);
                userinfo.ModifiedDate = (DateTime)(CustomReader["ModifiedDate"]);

                list.Add(userinfo);

                return list;
            }
            return null;
            
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
