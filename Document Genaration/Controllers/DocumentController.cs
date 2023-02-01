//using Document_Genaration.DAL;
using Document_Genaration.DAL;
using Document_Genaration.Model;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using System.Data;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Document_Genaration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : Controller

    {
    //private readonly IInterface _interface;
    //    public DocumentController(IInterface _interface)
    //    {
    //        this._interface = _interface;
    //    }




        private readonly IInterface @interface;
        private readonly Irepo _irepo;
        public DocumentController(IInterface @interface, Irepo irepo)
        {
            this.@interface=@interface;
            _irepo=irepo;
        }
        [HttpPost]
        [Route("SaveTemplate")]
        public DataSet Savatemplate(UserTemplate template)
        {
            var dataresult =@interface.insert(template);
            return dataresult;
        }
        [HttpPost]
        [Route("DocumentGenaration")]

        public ActionResult DocumentGenaration(UserTemplate  template)

        {
            var documentservice =_irepo.Service;
            return Ok(documentservice);


            //  "{\"Name\":\"Shatasree\", \"phno\":\"9366064267\"}"

            // "{\"Name\",\"phno\"}"


        }



       






    }
}

