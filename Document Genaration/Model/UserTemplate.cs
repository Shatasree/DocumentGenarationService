using System.Data;

namespace Document_Genaration.Model
{
    public class UserTemplate
    {
        public string TemplateId { get; set; }
        public string TemplateName { get; set; }
        public  string TemplateType{get; set;}
        public string TemplatePath { get; set; }
        public string BodyPlaceholder { get; set; }
        public string AllValueStore { get; set; }
       
       
 
        public bool IsWatermark { get; set; }
        
        public string WatermarkImage { get; set; }
        public string Watermarktext { get; set; }
       public float WatermarkOpacity { get; set; }
        public bool IsPassword { get; set; }
        public string Password { get; set; }

       
    }
}
