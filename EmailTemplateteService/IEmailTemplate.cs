using System.Collections.Generic;

namespace EmailTemplateteService
{
    interface IEmailTemplate
    {
        List<CampaignInfo> GetCampaignsDoNotHaveTemplate();
        List<BranchInfo> GetBranchesDoNotHaveTemplate();
        bool Create(int? campaignId,short? branchId ,string subject, string body);
         
        List<EmailTemplateInfo> GetAllForBranches();


        List<EmailTemplateInfo> GetlAllForCampaigns();

        EmailTemplateInfo GetById(int templateId);
        bool DeleteTemplate(int templateId);


        bool Edit(EmailTemplateInfo emailTemplateInfo);
    }
}
