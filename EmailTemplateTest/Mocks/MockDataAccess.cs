using System;
using System.Collections.Generic;
using EmailTemplateteService;
using EmailTemplateteService.Data;

namespace EmailTemplateTest.Mocks
{
    class MockDataAccess : IDataAccess
    {
        #region Private Members
         
        private readonly List<branch> _branches;

        private readonly List<campain> _campaigns;
        #endregion
        #region Ctor

        public MockDataAccess()
        {
            _branches = new List<branch>();
            _campaigns = new List<campain>();
        }

        public bool SaveEmailTemplate(TemplateParams templateParams)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Public Functions


        public void FillBranches(List<branch> branches)
        {
            _branches.AddRange(branches);
        }


        public void FillCampaigns(List<campain> campaigns)
        {
            _campaigns.AddRange(campaigns);
        }

        public List<branch> GetBranches()
        {

            return _branches;
        }

        public List<campain> GetCampaigns()
        {
            return _campaigns;

        }

        public List<EmailTemplateteService.Data.EmailsTemplate> GetEmailTemplate()
        {
            throw new NotImplementedException();
        }

        public List<EmailTemplateteService.Data.EmailsTemplate> GetEmailTemplateByBranchId(int branchId)
        {
            throw new NotImplementedException();
        }

        public List<EmailTemplateteService.Data.EmailsTemplate> GetEmailTemplateByCampaignId(int branchId)
        {
            throw new NotImplementedException();
        }

        public List<EmailTemplateteService.Data.EmailsTemplate> GetlAlEmailTemplatesForBranches()
        {
            throw new NotImplementedException();
        }

        public List<EmailTemplateteService.Data.EmailsTemplate> GetlAlEmailTemplatesForCampaigns()
        {
            throw new NotImplementedException();
        }

        public EmailTemplateteService.Data.EmailsTemplate GetEmailTemplateById(int templateId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTemplate(int templateId)
        {
            throw new NotImplementedException();
        }

        public bool EditEmailTemplate(EmailTemplateteService.Data.EmailsTemplate emailTemplate)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
