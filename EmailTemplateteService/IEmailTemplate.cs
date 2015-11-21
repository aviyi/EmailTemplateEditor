using System.Collections.Generic;

namespace EmailTemplateteService
{
    interface IEmailTemplate
    {
        List<CampaignInfo> GetCampaignsContainCampaignName(string term);
        List<BranchInfo> GetBranchesContainBranchName(string term);
        bool AddTemplateForBranch(short? branchId ,string subject, string body);

        bool AddTemplateForCampaign(int campaignId, string subject, string body);


    }
}
