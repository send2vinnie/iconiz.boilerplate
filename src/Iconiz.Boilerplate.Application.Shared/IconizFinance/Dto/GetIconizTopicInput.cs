using Abp.Runtime.Validation;
using Iconiz.Boilerplate.Dto;

namespace Iconiz.Boilerplate.IconizFinance.Dto
{
    public class GetIconizTopicInput : PagedAndSortedInputDto, IShouldNormalize
    {       
        public string Keyword { get; set; }
        
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}