using System.ComponentModel.DataAnnotations;

namespace Iconiz.Boilerplate.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}