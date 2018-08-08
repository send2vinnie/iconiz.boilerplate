using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Iconiz.Boilerplate.IconizTeamMember.Dto;

namespace Iconiz.Boilerplate.IconizTeamMember
{
    public interface IIconizTeamMemberAppService : IApplicationService
    {
        Task<PagedResultDto<IconizTeamMemberListDto>> GetIconizTeamMembers(GetIconizTeamMembersInput input);

        Task<TeamMemberEditDto> GetIconizTeamMemberForEdit(NullableIdDto input);

        Task CreateOrUpdateIconizTeamMember(TeamMemberEditDto input);

        Task DeleteIconizTeamMember(EntityDto input);
    }
}