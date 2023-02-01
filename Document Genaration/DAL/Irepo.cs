using Document_Genaration.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Document_Genaration.DAL
{
    public interface Irepo
    {
        public string Service(UserTemplate userTemplate);
    }
}
