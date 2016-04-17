using System.Linq;
using System.Collections.Generic;
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

        #region Public
        public bool Create(int? campaignId, short? branchId, string subject, string body)
        {
            return _dataBase.SaveEmailTemplate(new TemplateParams()
            {
                CampaignId = campaignId,
                BranchId = branchId,
                Body = body,
                Subject = subject
            });
        }

        public bool Edit(EmailTemplateInfo emailTemplateInfo)
        {
            return _dataBase.EditEmailTemplate(new EmailsTemplate { Id = emailTemplateInfo.Id, Body = emailTemplateInfo.Body, Subject = emailTemplateInfo.Subject });
        }


        public bool DeleteTemplate(int templateId)
        {
            return _dataBase.DeleteTemplate(templateId);
        }

        public EmailTemplateInfo GetById(int id)
        {
            var template = _dataBase.GetEmailTemplateById(id);
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


        public List<BranchInfo> GetBranchesDoNotHaveTemplate()
        {
            return _dataBase.GetBranches().Where(b => b.EmailsTemplates.Count == 0 || !HasTemplate(b.EmailsTemplates)).Select(b => new BranchInfo
            {
                Id = b.branch_num,
                Name = b.name,
            }).ToList();

        }

        public List<CampaignInfo> GetCampaignsDoNotHaveTemplate()
        {
            return _dataBase.GetCampaigns().Where(b => b.EmailsTemplates.Count == 0 || !HasTemplate(b.EmailsTemplates)).Select(c => new CampaignInfo
            {
                Id = c.mis_campain,
                Name = c.teur_campain
            }).ToList();

        }

        public List<EmailTemplateInfo> GetAllForBranches()
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

        public List<EmailTemplateInfo> GetlAllForCampaigns()
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

        #endregion
        
        #region Private 

        private bool HasTemplate(ICollection<EmailsTemplate> templates)
        {
            var hasTemplate = false;
            foreach (var item in templates)
            {
                if (!item.IsDeleted)
                    hasTemplate = true;
            }
            return hasTemplate;
        }

        #endregion
    }
}
