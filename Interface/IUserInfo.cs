using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Interface
{
    public interface IUserInfo
    {
        public string Insert(UserInfoModel userinfo);
        public string Update(UserInfoModel userinfo);
        public string Delete(UserInfoModel userinfo);
        public List<UserInfoModel> GetAll();
        public List<UserInfoModel> GetByUserId(int userId);
        public int GetCount();
        public int GetCountByUserId(int userId);
    }
}
