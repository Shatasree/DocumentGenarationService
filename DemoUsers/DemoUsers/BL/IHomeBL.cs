using DemoUsers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUsers.BL
{
    public interface IHomeBL
    {
        List<UserDetails> Get_UserList();
        int Delete_User(int id);
    }
}
