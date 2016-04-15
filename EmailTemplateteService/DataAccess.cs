using EmailTemplateteService.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmailTemplateteService
{
    public class DataAccess : IDataAccess, IDisposable
    {
        SOSDBEntities _ctx = new SOSDBEntities();
        public bool SaveEmailTemplate(TemplateParams templateParams)
        {

            bool isAdded = false;
            try
            {
                _ctx.EmailsTemplates.Add(new EmailsTemplate
                {
                    brabch_num = templateParams.BranchId,
                    mis_campaign = templateParams.CampaignId,
                    Subject = templateParams.Subject,
                    Body = templateParams.Body,
                });
                _ctx.SaveChanges();
                isAdded = true;

            }
            catch (Exception ex)
            {
                throw ex;

            }

            return isAdded;
        }


        public List<branch> GetBranches()
        {
            return _ctx.branches.Where(b => b.status == "פ").OrderBy(b => b.name).ToList();
        }

        public List<campain> GetCampaigns()
        {

            return _ctx.campains.Where(c => c.status == "פ").OrderBy(c => c.teur_campain).ToList();


        }

        public List<EmailsTemplate> GetEmailTemplate()
        {
            return _ctx.EmailsTemplates.Where(e => e.IsDeleted == false).ToList();
        }


        public List<EmailsTemplate> GetEmailTemplateByCampaignId(int campaignId)
        {

            return _ctx.EmailsTemplates.Where(e => e.mis_campaign == campaignId && e.IsDeleted == false).ToList();
        }

        public List<EmailsTemplate> GetEmailTemplateByBranchId(int branchId)
        {
            return _ctx.EmailsTemplates.Where(e => e.brabch_num == branchId).ToList();
        }

        public List<EmailsTemplate> GetlAlEmailTemplatesForBranches()
        {

            return _ctx.EmailsTemplates.Where(e => e.brabch_num != null && e.IsDeleted == false).ToList();
        }

        public List<EmailsTemplate> GetlAlEmailTemplatesForCampaigns()
        {
            return _ctx.EmailsTemplates.Where(e => e.mis_campaign != null && e.IsDeleted == false).ToList();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public EmailsTemplate GetEmailTemplateById(int templateId)
        {
            return _ctx.EmailsTemplates.First(e => e.Id == templateId);
        }

        public bool DeleteTemplate(int templateId)
        {
            bool isSuccess;
            try
            {
                var tempalte = _ctx.EmailsTemplates.First(e => e.Id == templateId);
                tempalte.IsDeleted = true;
                _ctx.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {

                throw;
            }
            return isSuccess;
        }

        public bool EditEmailTemplate(EmailsTemplate emailTemplate)
        {
            bool isSuccess;
            try
            {

                var original = _ctx.EmailsTemplates.First(e => e.Id == emailTemplate.Id);

                original.Subject = emailTemplate.Subject;
                original.Body = emailTemplate.Body;
                _ctx.SaveChanges();
                isSuccess = true;
            }
            catch (Exception)
            {
                throw;
            }
            return isSuccess;
        }
    }
}
