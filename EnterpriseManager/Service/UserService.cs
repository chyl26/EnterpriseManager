using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using EnterpriseManager.Repository;
using EnterpriseManager.Domain;

namespace EnterpriseManager.Service
{
    public class UserService
    {
        IRepository<User> repository = new MbRepository<User>();
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        public void Create(User user)
        {
            repository.Insert("InsertUser", user);
        }
        public void GetUserById(string userId)
        {
            User user = repository.GetByCondition("SelectUserByCondition", new User { UserId = userId });
        }
        public IList<User> GetUsers(int pageCount)
        {
            IList<User> userList = repository.GetList("SelectUserByCondition", new User { }, pageCount);
            return userList;
        }
        public int GetCount()
        {
            int count = repository.GetObject<int>("SelectUserCount", null);
            return count;
        }
        public void Update(User user)
        {
            repository.Update("UpdateUser", user);
        }
        public void Delete(string userId)
        {
            repository.Delete("DeleteUser", new User { UserId = userId });
        }
    }
}