﻿using System.Collections.Generic;

namespace EmailTemplateteService
{
    interface IEmailTemplate
    {
        List<CampaignInfo> GetCampaigns();
        List<Branch> GetAllBranchesContaintWithBranchName(string term);
    }
}
