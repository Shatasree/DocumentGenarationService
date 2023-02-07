using DemoUsers.DAL;
using DemoUsers.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoUsers.BL
{
    public class HomeBL : IHomeBL
    {
        public List<UserDetails> Get_UserList()
        {
            List<UserDetails> list = new List<UserDetails>();
            try
            {
                UserDetailsDAL details = new UserDetailsDAL();
                DataSet ds = details.GetUserList();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    UserDetails obj = new UserDetails();
                    obj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    obj.userName = ds.Tables[0].Rows[i]["USERNAME"].ToString();
                    obj.password = ds.Tables[0].Rows[i]["PASSWORD"].ToString();
                    obj.phone = ds.Tables[0].Rows[i]["PHONE"].ToString();
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception e)
            {
                return list;
            }
        }
        public int Delete_User(int id)
        {
            UserDetailsDAL details = new UserDetailsDAL();
            var result = details.RemoveData(id);
            return result;
        }
   }
}