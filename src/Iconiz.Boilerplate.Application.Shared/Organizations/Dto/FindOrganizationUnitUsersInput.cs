using Iconiz.Boilerplate.Dto;

namespace Iconiz.Boilerplate.Organizations.Dto
{
    public class FindOrganizationUnitUsersInput : PagedAndFilteredInputDto
    {
        public long OrganizationUnitId { get; set; }
    }
}
