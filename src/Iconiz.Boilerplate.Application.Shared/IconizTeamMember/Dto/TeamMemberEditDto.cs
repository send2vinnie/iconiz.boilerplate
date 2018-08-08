using System;
using Abp.Domain.Entities;

namespace Iconiz.Boilerplate.IconizTeamMember.Dto
{
    public class TeamMemberEditDto : IPassivable
    {
        public int? Id { get; set; }

        public long? UserId { get; set; }

        public int Priority { get; set; }

        public string Name_Chn { get; set; }

        public string Name_Eng { get; set; }

        public string Title_Chn { get; set; }

        public string Title_Eng { get; set; }

        public string Description_Chn { get; set; }

        public string Description_Eng { get; set; }

        public string LinkedIn { get; set; }

        public virtual string ProfilePictureFileName { get; set; }

        public Guid? ProfilePictureId { get; set; }

        public bool IsActive { get; set; }
    }
}