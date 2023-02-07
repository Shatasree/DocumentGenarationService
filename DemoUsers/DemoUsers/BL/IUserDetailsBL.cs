using DemoUsers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUsers.BL
{
    public interface IUserDetailsBL
    {
        int Insert_User(UserDetails userDetails);
        int Update_User(UserDetails userDetails);
        DataSet Get_User(int id);
    }
}
