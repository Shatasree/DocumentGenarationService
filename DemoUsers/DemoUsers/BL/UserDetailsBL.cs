using DemoUsers.DAL;
using DemoUsers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoUsers.BL
{
    public class UserDetailsBL : IUserDetailsBL
    {
        UserDetailsDAL details = new UserDetailsDAL();
        public int Insert_User(UserDetails userDetails)
        {
            var result= details.insertData(userDetails);
            return result;
        }
        public int Update_User(UserDetails userDetails)
        {
            var result = details.UpdateData(userDetails);
            return result;
        }
        public DataSet Get_User(int id)
        {
            UserDetailsDAL details = new UserDetailsDAL();
            return details.GetUser(id);
        }
    }
}