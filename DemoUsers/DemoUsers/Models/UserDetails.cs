using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoUsers.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public DataTable dt { get; set; }
    }
}