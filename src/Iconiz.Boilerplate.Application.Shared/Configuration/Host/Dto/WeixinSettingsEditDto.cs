namespace Iconiz.Boilerplate.Configuration.Host.Dto
{
    public class WeixinSettingsEditDto
    {
        public string AppKey { get; set; }

        public string AppSecret { get; set; }
    }
    
    public class JinseSettingsEditDto
    {
        public string AccessKey { get; set; }

        public string SecretKey { get; set; }
    }
    
    public class SMSSettingsEditDto
    {
        public string AppKey { get; set; }

        public string AppSecret { get; set; }
        
        public string SignName { get; set; }
        
        public string UserIdentityValidateTemplateCode { get; set; }
        
        public string UserLoginConfirmTemplateCode { get; set; }
        
        public string UserLoginErrorTemplateCode { get; set; }
        
        public string UserRegisterTemplateCode { get; set; }
        
        public string UserChangePasswordTemplateCode { get; set; }
        
        public string UserChangeInformationTemplateCode { get; set; }
    }
}