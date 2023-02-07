using Document_Genaration.Controllers;
using Document_Genaration.DAL;
using Document_Genaration.Model;
using Moq;

namespace DocumentGenarationTest
{
    public class DocumentGenarationTest
    {
        [Fact]
        public void DocumenTest()
        {
            var ExpectedResult = "{\"StatusCode\":\"200\",\"Status\":\"True\",\"Message\":\"notification sent\"}";
           UserTemplate UserTemplate = new UserTemplate();
            var Irepo = new Mock<Irepo>();
            var IInterface = new Mock<IInterface>();
            DocumentController documentController = new DocumentController(IInterface.Object, Irepo.Object);
            UserTemplate.TemplateId = "102";
            UserTemplate.TemplateName = "Appraisal";
            UserTemplate.TemplatePath = "";
            UserTemplate.TemplateType = "pdf";
            UserTemplate.AllValueStore = "\"{\\r\\n\\t\\\"{{Name}}\\\": \\\"ShatasreeDas\\\",\\r\\n\\t\\\"{{Phone}}\\\": \\\"987654321\\\",\\r\\n\\t\\\"{{arrName}}\\\":\\\"[\\\\\\\"Pabitra bhunia\\\\\\\",\\\\\\\"ShatasreeDas\\\\\\\",\\\\\\\"Subha Samanta\\\\\\\"]\\\",\\r\\n\\t\\\"{{arrAddress}}\\\":\\\"[\\\\\\\"Ghatal\\\\\\\",\\\\\\\"Kolkata\\\\\\\",\\\\\\\"Midnapore\\\\\\\"]\\\"\\r\\n}\"\r\n\r\n ";
            var result = documentController.DocumentGenaration(UserTemplate);
            Assert.Equal(ExpectedResult, result);

        }
    }
}