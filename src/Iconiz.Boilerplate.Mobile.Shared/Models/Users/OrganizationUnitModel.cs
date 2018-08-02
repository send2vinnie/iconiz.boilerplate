using Abp.AutoMapper;
using Iconiz.Boilerplate.Organizations.Dto;

namespace Iconiz.Boilerplate.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}