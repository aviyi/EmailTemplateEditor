using EmailTemplateteService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTemplateteService
{
    public interface IDataAccess
    {
        List<branch> GetBranches();
        List<campain> GetCampaigns();

        List<EmailsTemplate> GetEmailTemplate();

        List<EmailsTemplate> GetEmailTemplateByCampaignId(int campaignId);
        List<EmailsTemplate> GetEmailTemplateByBranchId(int branchId);

        bool SaveEmailTemplate(TemplateParams templateParams);
        List<EmailsTemplate> GetlAlEmailTemplatesForBranches();
        List<EmailsTemplate> GetlAlEmailTemplatesForCampaigns();
        EmailsTemplate GetEmailTemplateById(int templateId);
        bool DeleteTemplate(int templateId);

        bool EditEmailTemplate(EmailsTemplate emailTemplate);

    }
}
