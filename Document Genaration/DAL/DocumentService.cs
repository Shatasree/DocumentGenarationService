using Document_Genaration.Model;
using Microsoft.Extensions.Hosting.Internal;
//using OpenXmlPowerTools;
using System.Data;
using System.Text.Json;
using IronPdf;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Microsoft.AspNetCore.Components.RenderTree;


namespace Document_Genaration.DAL;

public class DocumentService : Irepo
{
    private readonly IInterface a;
    public DocumentService(IInterface @interface)
    {
        a = @interface;
    }



    public string Service(UserTemplate userTemplate)
    {
        var databasecon = a.insert(userTemplate);
        // return databasecon;
        string path = File.ReadAllText(userTemplate.TemplatePath);
        var placeHoldersAndValues = JsonSerializer.Deserialize<Dictionary<string, object>>(userTemplate.AllValueStore);
        foreach (KeyValuePair<string, object> item in placeHoldersAndValues)
        {
            path = path.Replace(item.Key, item.Value.ToString());
        }
        //var pdf =PdfDocument.FromFile("practice.html");
        var Renderer = new ChromePdfRenderer(); // Instantiates Chrome Renderer
        Renderer.RenderingOptions.HtmlFooter = new HtmlHeaderFooter()
        {
            MaxHeight = 15, //millimeters
            HtmlFragment = "<center><i>{page} of {total-pages}<i></center>",
            DrawDividerLine = true
        };
        Renderer.RenderingOptions.MarginBottom = 25; //mm
        Renderer.RenderingOptions.HtmlHeader = new HtmlHeaderFooter()
        {
            MaxHeight = 20, //millimeters
            HtmlFragment = "<img src='logo.png'>",
            BaseUrl = new Uri(@"C:\assets\images\").AbsoluteUri
        };
        Renderer.RenderingOptions.MarginLeft = 25;



        var pdf = Renderer.RenderHtmlAsPdf(path);
        //var pdf = PdfDocument.FromFile("userTemplate.TemplatePath", "password");
        pdf.ApplyWatermark("<h2 style='color:red'>WATERMARK</h2>", 80, 30, IronPdf.Editing.VerticalAlignment.Middle, IronPdf.Editing.HorizontalAlignment.Center);
        pdf.MetaData.Author = "Shatasree";
        pdf.MetaData.Keywords = "SEO, Friendly";
        pdf.MetaData.ModifiedDate = System.DateTime.Now;
        pdf.SecuritySettings.RemovePasswordsAndEncryption();
        pdf.SecuritySettings.MakePdfDocumentReadOnly("Secret key");
        pdf.SecuritySettings.AllowUserAnnotations = false;
        pdf.SecuritySettings.AllowUserCopyPasteContent = false;
        pdf.SecuritySettings.AllowUserPrinting =
        IronPdf.Security.PdfPrintSecurity.FullPrintRights;
        pdf.SecuritySettings.OwnerPassword = "abc";
        pdf.SecuritySettings.UserPassword = "xyz";
        pdf.SaveAs("D:\\Document Genaration\\Document Genaration\\pro\\practice3.pdf");

        return "0";


    }
   

}





