using System;
using System.Collections.Generic;

namespace EmailTemplateteService.Entities
{
    public class EmailTemplateService : IEmailTemplate
    {

        public EmailTemplateService()
        {

        }
    
        public List<Branch> GetAllBranchesContaintWithBranchName(string term)
        {
            throw new NotImplementedException();
        }

        public List<CampaignInfo> GetCampaigns()
        {
            throw new NotImplementedException();
        }
    }
}
