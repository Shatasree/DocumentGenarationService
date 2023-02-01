using Document_Genaration.Model;
using System.Data;

namespace Document_Genaration.DAL
{
    public interface IInterface
    {
       // string DbConnection();
        public DataSet insert(UserTemplate template);
    }
}
