﻿using System.Collections.Generic;

namespace Iconiz.Boilerplate.Tenants.Dashboard.Dto
{
    public class GetMemberActivityOutput
    {
        public GetMemberActivityOutput(List<MemberActivity> memberActivities)
        {
            MemberActivities = memberActivities;
        }

        public List<MemberActivity> MemberActivities { get; set; }


    }
}