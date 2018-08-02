using Iconiz.Boilerplate.Dto;

namespace Iconiz.Boilerplate.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}