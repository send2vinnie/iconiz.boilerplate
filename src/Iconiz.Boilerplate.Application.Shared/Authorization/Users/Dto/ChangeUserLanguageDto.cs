using System.ComponentModel.DataAnnotations;

namespace Iconiz.Boilerplate.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
