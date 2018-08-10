using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Configuration;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Notifications;
using Abp.Organizations;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Zero.Configuration;
using Microsoft.EntityFrameworkCore;
using Iconiz.Boilerplate.Authorization;
using Iconiz.Boilerplate.IconizTeamMember;
using Iconiz.Boilerplate.IconizTeamMember.Dto;
using Iconiz.Boilerplate.Storage;
using System.IO;
using Abp.IO;

namespace Iconiz.Boilerplate.IconizTeamMember
{
    [AbpAuthorize(AppPermissions.Pages_IconizTeamMember)]
    public class IconizTeamMemberAppService : BoilerplateAppServiceBase, IIconizTeamMemberAppService
    {
        private readonly IRepository<IconizTeamMember> _iconizTeamMemberRepository;
        private const int MaxProfilPictureBytes = 5000000; //1MB
        private readonly IAppFolders _appFolders;
        private readonly IBinaryObjectManager _binaryObjectManager;

        public IconizTeamMemberAppService(
            IAppFolders appFolders,
            IBinaryObjectManager binaryObjectManager,
            IRepository<IconizTeamMember> iconizTeamMemberepository)
        {
            _iconizTeamMemberRepository = iconizTeamMemberepository;
            _appFolders = appFolders;
            _binaryObjectManager = binaryObjectManager;
        }

        [AbpAllowAnonymous]
        public async Task<List<IconizTeamMember>> GetAll()
        {
            return await _iconizTeamMemberRepository.GetAll().Where(f => f.IsActive).OrderBy(f => f.Priority).ToListAsync();
        }

        public async Task<PagedResultDto<IconizTeamMemberListDto>> GetIconizTeamMembers(GetIconizTeamMembersInput input)
        {
            var query = _iconizTeamMemberRepository.GetAll()
                .WhereIf(!input.UserName.IsNullOrWhiteSpace(), item => item.Name_Chn.Contains(input.UserName)
                                                                    || item.Name_Eng.Contains(input.UserName));
            var resultCount = await query.CountAsync();
            var results = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var teamMembers = ObjectMapper.Map<List<IconizTeamMemberListDto>>(results);

            return new PagedResultDto<IconizTeamMemberListDto>(resultCount, teamMembers);
        }

        [AbpAuthorize(AppPermissions.Pages_IconizTeamMember_Create, AppPermissions.Pages_IconizTeamMember_Edit)]
        public async Task<TeamMemberEditDto> GetIconizTeamMemberForEdit(NullableIdDto input)
        {
            if (input.Id.HasValue)
            {
                var teamMember = _iconizTeamMemberRepository.Get(input.Id.Value);
                return ObjectMapper.Map<TeamMemberEditDto>(teamMember);
            }

            return null;
        }

        [AbpAuthorize(AppPermissions.Pages_IconizTeamMember_Create, AppPermissions.Pages_IconizTeamMember_Edit)]
        public async Task CreateOrUpdateIconizTeamMember(TeamMemberEditDto input)
        {
            if (!input.Id.HasValue || input.Id.Value == 0)
            {
                await CreateIconizTeamMemberAsync(input);
            }
            else
            {
                await UpdateIconizTeamMemberAsync(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_IconizTeamMember_Delete)]
        public async Task DeleteIconizTeamMember(EntityDto input)
        {
            var teamMember = await _iconizTeamMemberRepository.GetAsync(input.Id);
            await _iconizTeamMemberRepository.DeleteAsync(teamMember);
        }

        [AbpAuthorize(AppPermissions.Pages_IconizTeamMember_Create)]
        protected virtual async Task CreateIconizTeamMemberAsync(TeamMemberEditDto input)
        {
            var iconizTeamMember = ObjectMapper.Map<IconizTeamMember>(input);
            if (!string.IsNullOrEmpty(input.ProfilePictureFileName))
            {
                iconizTeamMember.ProfilePictureId = await StoreProfilePicture(input.ProfilePictureFileName);
            }
            await _iconizTeamMemberRepository.InsertAsync(iconizTeamMember);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_IconizTeamMember_Edit)]
        protected virtual async Task UpdateIconizTeamMemberAsync(TeamMemberEditDto input)
        {
            var iconizTeamMember = await _iconizTeamMemberRepository.GetAsync(input.Id.Value);

            if (!string.IsNullOrEmpty(input.ProfilePictureFileName))
            {
                if (iconizTeamMember.ProfilePictureId.HasValue)
                {
                    await _binaryObjectManager.DeleteAsync(iconizTeamMember.ProfilePictureId.Value);
                }
                input.ProfilePictureId = iconizTeamMember.ProfilePictureId = await StoreProfilePicture(input.ProfilePictureFileName);
            }

            ObjectMapper.Map(input, iconizTeamMember);
            await _iconizTeamMemberRepository.UpdateAsync(iconizTeamMember);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        private async Task<System.Guid> StoreProfilePicture(string filename)
        {
            var tempProfilePicturePath = Path.Combine(_appFolders.TempFileDownloadFolder, filename);

            byte[] byteArray = File.ReadAllBytes(tempProfilePicturePath);

            if (byteArray.Length > MaxProfilPictureBytes)
            {
                throw new UserFriendlyException(L("ResizedProfilePicture_Warn_SizeLimit", AppConsts.ResizedMaxProfilPictureBytesUserFriendlyValue));
            }

            var storedFile = new BinaryObject(AbpSession.TenantId, byteArray);

            await _binaryObjectManager.SaveAsync(storedFile);

            FileHelper.DeleteIfExists(tempProfilePicturePath);

            return storedFile.Id;
        }
    }
}