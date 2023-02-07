using Document_Genaration.Model;

using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text.Json;

namespace Document_Genaration.DAL
{
   
         public class Databasecon : IInterface
    {
        private readonly string Conn;
        public Databasecon(IConfiguration configuration)
        {
            Conn = configuration.GetConnectionString("DefaultConnection");
        }


       

        public string insert(UserTemplate template)
        {
            DataSet ds = new DataSet();
            var con = new OracleConnection(Conn);
            con.Open();
            OracleCommand cmd = new OracleCommand("INSERT into DOCUMENTTEMPLATE(ID,NAME,TYPE,PATH,BODYPLACEHOLDER,AllValue,WATERMARKIMG,WATERMARKTEXT,OPACITY,PASSWORD)values('" + template.TemplateId + "','" + template.TemplateName + "','" +  template.TemplateType + "','" +template.TemplatePath +"','" + template.BodyPlaceholder+ "','"+template.AllValueStore + "','" +template.WatermarkImage +"','"+template.Watermarktext+ "','"+template.WatermarkOpacity+ "','"+template.Password+"')", con);
                   //odp for retriving and saving data
            var i=cmd.ExecuteNonQuery();     
            con.Close();
            return "Template";
            
        }
             
}
            


        }
    
