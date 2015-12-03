using System.Linq;
using System.Collections.Generic;
using System;
using EmailTemplateteService.Data;

namespace EmailTemplateteService
{
    public class EmailTemplateService : IEmailTemplate
    {
        private readonly IDataAccess _dataBase;
        public EmailTemplateService(IDataAccess dataBase)
        {
            _dataBase = dataBase;
        }

        public bool CreateEmailTemplate(int? campaignId, short? branchId, string subject, string body)
        {
            return _dataBase.SaveEmailTemplate(new TemplateParams()
            {
                CampaignId = campaignId,
                BranchId = branchId,
                Body = body,
                Subject = subject
            });
        }

      

        public List<BranchInfo> GetBranchesDoNotHaveTemplate()
        {

            return _dataBase.GetBranches().Where(b => b.EmailsTemplates.Count == 0 || b.EmailsTemplates.First().IsDeleted == true).Select(b => new BranchInfo
            {
                Id = b.branch_num,
                Name = b.name,
            }).ToList();

        }

        public List<CampaignInfo> GetCampaignsDoNotHaveTemplate()
        {

            return _dataBase.GetCampaigns().Where(b => b.EmailsTemplates.Count == 0 || b.EmailsTemplates.First().IsDeleted == true).Select(c => new CampaignInfo
            {
                Id = c.mis_campain,
                Name = c.teur_campain
            }).ToList();

        }

        public List<EmailTemplateInfo> GetlAlEmailTemplatesForBranches()
        {
            return _dataBase.GetlAlEmailTemplatesForBranches().Select(e => new EmailTemplateInfo
            {
                Id = e.Id,
                Body = e.Body,
                BranchInfo = new BranchInfo
                {
                    Id = e.branch.branch_num,
                    Name = e.branch.name
                },
                Subject = e.Subject
            }).ToList();
        }

        public List<EmailTemplateInfo> GetlAlEmailTemplatesForCampaigns()
        {

            return _dataBase.GetlAlEmailTemplatesForCampaigns().Select(e => new EmailTemplateInfo
            {
                Id = e.Id,
                Body = e.Body,
                CampaignInfo = new CampaignInfo
                {
                    Id = e.campain.mis_campain,
                    Name = e.campain.teur_campain
                },
                Subject = e.Subject
            }).ToList();
        }

        public EmailTemplateInfo GetEmailTemplateById(int templateId)
        {
            var template = _dataBase.GetEmailTemplateById(templateId);

            var emailTemplateInfo = new EmailTemplateInfo();


            emailTemplateInfo.Id = template.Id;
            emailTemplateInfo.Body = template.Body;
            emailTemplateInfo.Subject = template.Subject;
            if (template.branch != null)
            {
                emailTemplateInfo.BranchInfo = new BranchInfo
                {
                    Id = template.branch.branch_num,
                    Name = template.branch.name
                };
            }
            if (template.campain != null)
            {
                emailTemplateInfo.CampaignInfo = new CampaignInfo
                {
                    Id = template.campain.mis_campain,
                    Name = template.campain.teur_campain
                };
            }
            return emailTemplateInfo;
        }

        public bool DeleteTemplate(int templateId)
        {
            return _dataBase.DeleteTemplate(templateId);
        }

        public bool EditEmailTemplate(EmailTemplateInfo emailTemplateInfo)
        {
            return _dataBase.EditEmailTemplate(new EmailsTemplate { Id=emailTemplateInfo.Id, Body= emailTemplateInfo.Body,Subject= emailTemplateInfo.Subject});
        }
    }
}
