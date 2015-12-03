using System.Collections.Generic;

namespace EmailTemplateteService
{
    interface IEmailTemplate
    {
        List<CampaignInfo> GetCampaignsDoNotHaveTemplate();
        List<BranchInfo> GetBranchesDoNotHaveTemplate();
        bool CreateEmailTemplate(int? campaignId,short? branchId ,string subject, string body);
         
        List<EmailTemplateInfo> GetlAlEmailTemplatesForBranches();


        List<EmailTemplateInfo> GetlAlEmailTemplatesForCampaigns();

        EmailTemplateInfo GetEmailTemplateById(int templateId);
        bool DeleteTemplate(int templateId);


        bool EditEmailTemplate(EmailTemplateInfo emailTemplateInfo);
    }
}
