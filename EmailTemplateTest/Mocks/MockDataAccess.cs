using System;
using System.Collections.Generic;
using EmailTemplateteService;
using EmailTemplateteService.Data;

namespace EmailTemplateTest.Mocks
{
    class MockDataAccess : IDataAccess
    {
        #region Private Members
         
        private readonly List<branches> _branches;

        private readonly List<campains> _campaigns;
        #endregion
        #region Ctor

        public MockDataAccess()
        {
            _branches = new List<branches>();
            _campaigns = new List<campains>();
        }

        public bool AddEmailTemplate(TemplateParams templateParams)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Public Functions


        public void FillBranches(List<branches> branches)
        {
            _branches.AddRange(branches);
        }


        public void FillCampaigns(List<campains> campaigns)
        {
            _campaigns.AddRange(campaigns);
        }

        public List<branches> GetBranches()
        {

            return _branches;
        }

        public List<campains> GetCampaigns()
        {
            return _campaigns;

        }

        List<EmailTemplateteService.Data.branches> IDataAccess.GetBranches()
        {
            throw new NotImplementedException();
        }

        List<EmailTemplateteService.Data.campains> IDataAccess.GetCampaigns()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
