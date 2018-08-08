using Abp.Runtime.Validation;
using Iconiz.Boilerplate.Dto;

namespace Iconiz.Boilerplate.IconizTeamMember.Dto
{
    public class GetIconizTeamMembersInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string UserName { get; set; }
        
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}