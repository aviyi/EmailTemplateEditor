using System.Collections.Generic;

namespace EmailTemplateteService
{
    interface IEmailTemplate
    {
        List<CampaignInfo> GetCampaignsContainCampaignName(string term);
        List<BranchInfo> GetBranchesContainBranchName(string term);
    }
}
