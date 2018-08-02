using System.Collections.Generic;
using Iconiz.Boilerplate.Authorization.Users.Dto;
using Iconiz.Boilerplate.Dto;

namespace Iconiz.Boilerplate.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}