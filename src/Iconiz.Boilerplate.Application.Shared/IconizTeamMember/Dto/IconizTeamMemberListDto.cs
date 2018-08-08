using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace Iconiz.Boilerplate.IconizTeamMember.Dto
{
    public class IconizTeamMemberListDto : EntityDto
    {
        public string Name_Chn { get; set; }

        public string Name_Eng { get; set; }
        
        public  int Priority{ get; set; }

        public bool IsActive { get; set; }
    }
}