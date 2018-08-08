using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace Iconiz.Boilerplate.IconizTeamMember
{
    public class IconizTeamMember : Entity, IHasCreationTime, IPassivable
    {
        public long? UserId { get; set; }

        public int Priority { get; set; }

        public string Name_Chn { get; set; }

        public string Name_Eng { get; set; }

        public string Title_Chn { get; set; }

        public string Title_Eng { get; set; }

        public string Description_Chn { get; set; }

        public string Description_Eng { get; set; }

        public string LinkedIn { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid? ProfilePictureId { get; set; }

        public bool IsActive { get; set; }

        protected IconizTeamMember()
        {
        }
    }
}