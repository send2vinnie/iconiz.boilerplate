using System.ComponentModel.DataAnnotations;

namespace Iconiz.Boilerplate.Web.Models.TokenAuth
{
    public class SendTwoFactorAuthCodeModel
    {
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

        [Required]
        public string Provider { get; set; }
    }
    
    public class SendTwoFactorValidateCodeModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Provider { get; set; }
    }
}