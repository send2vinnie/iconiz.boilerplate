using System.ComponentModel.DataAnnotations;

namespace Iconiz.Boilerplate.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}