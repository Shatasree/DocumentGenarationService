//using Document_Genaration.DAL;
using Aspose.Words.XAttr;
using Document_Genaration.DAL;
using Document_Genaration.Model;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using System.Data;
using System.Reflection.Metadata;
using System.Text.Json;
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
        public string Savatemplate(UserTemplate template)
        {
            var dataresult =@interface.insert(template);
            
            if (template != null)
            {
                MailResponse mailResponse = new MailResponse();
                mailResponse.Status = "True";
                mailResponse.StatusCode = "200";
                mailResponse.Message = "notification sent";
                string strjson = JsonSerializer.Serialize<MailResponse>(mailResponse);//to change the dot net object to  JSon object

                return strjson;


            }
            else
            {
                MailResponse mailResponse = new MailResponse();
                mailResponse.StatusCode = "400";
                mailResponse.Status = "false";
                mailResponse.Message = "Mail not Sent";
                string strjson = JsonSerializer.Serialize<MailResponse>(mailResponse);
                return strjson.ToString();


            }
        }
        [HttpPost]
        [Route("DocumentGenaration")]

        public string DocumentGenaration(UserTemplate template)

        {
            var documentservice = _irepo.Service(template);
            // return Ok(documentservice);
           if (template != null)
            {
                MailResponse mailResponse = new MailResponse();
                mailResponse.Status = "True";
                mailResponse.StatusCode = "200";
                mailResponse.Message = "notification sent";
                string strjson = JsonSerializer.Serialize<MailResponse>(mailResponse);//to change the dot net object to  JSon object

                return strjson;


            }
            else
            {
                MailResponse mailResponse = new MailResponse();
                mailResponse.StatusCode = "400";
                mailResponse.Status = "false";
                mailResponse.Message = "Mail not Sent";
                string strjson = JsonSerializer.Serialize<MailResponse>(mailResponse);
                return strjson.ToString();


            }
        }


    }



            // "{\"Name\":\"ShatasreeDas\"}", \"phno\":\"9366064267\"}"

            // "{\"Name\",\"phno\"}"
            //"{\"Name\":\"ShatasreeDas\"}"
            // "{\"Name\":\"ShatasreeDas\}",{"Name\":\"ShatasDas\",\"Age\":\"23\",\"Dept\":\"IT\"}";
            // "\"{{Name}}\":\"ShatasreeDas\",{\"Name\":\"ShatasDas\",\"Age\":\"23\",\"Dept\":\"IT\",\"Name\":\"Twinklr\",\"Age\":\"25\",\"Dept\":\"IT\"}"


       // {\r\n\t\"{{Name}}\": \"ShatasreeDas\",\r\n\t\"{{Age}}\": \"23\",\r\n\t\"{{Dept}}\": \"IT\"\r\n}










    }


