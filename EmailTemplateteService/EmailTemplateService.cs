using System;
using System.Linq;
using System.Collections.Generic;

namespace EmailTemplateteService.Entities
{
    public class EmailTemplateService : IEmailTemplate
    {
        private readonly IDataAccess _dataBase;
        public EmailTemplateService(IDataAccess dataBase)
        {
            _dataBase = dataBase;
        }

        public bool AddTemplateForBranch(short? branchId, string subject, string body)
        {
            return _dataBase.AddEmailTemplate(new TemplateParams()
            {
                BranchId = branchId,
                Body = body,
                Subject = subject
            });
        }

        public bool AddTemplateForCampaign(int campaignId, string subject, string body)
        {
            return _dataBase.AddEmailTemplate(new TemplateParams()
            {
                CampaignId= campaignId,
                Body = body,
                Subject = subject
            });
        }

        public List<BranchInfo> GetBranchesContainBranchName(string term)
        {

            return _dataBase.GetBranches().Where(b => b.name.Contains(term)).Select(b => new BranchInfo
            {
                Id = b.branch_num,
                Name = b.name
            }).ToList();

        }

        public List<CampaignInfo> GetCampaignsContainCampaignName(string term)
        {

            return _dataBase.GetCampaigns().Where(b => b.teur_campain.Contains(term)).Select(b => new CampaignInfo
            {
                Name = b.teur_campain
            }).ToList();
        }
    }
}
