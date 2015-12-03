using EmailTemplateSite.ViewModels;
using EmailTemplateteService;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmailTemplateSite.Controllers
{

    public class EmailTemplateController : ApiController
    {

        EmailTemplateService _emailTemplateService;
        public EmailTemplateController()
        {

            _emailTemplateService = new EmailTemplateService(new DataAccess());
        }
        [HttpPost]
        public bool AddForBranch([FromBody]TemplateParamsViewModel templateParams)
        {
            return _emailTemplateService.SaveTemplateForBranch(templateParams.BranchId, templateParams.Subject, templateParams.Body);
        }

        [HttpPost]
        public bool AddForCampaign([FromBody]TemplateParamsViewModel templateParams)
        {
            return _emailTemplateService.SaveTemplateForCampaign(templateParams.CampaignId, templateParams.Subject, templateParams.Body);
        }

        [HttpGet]
        public List<BranchViewModel> GetBranches(string termBranch)
        {
            return _emailTemplateService.GetBranchesContainBranchName(termBranch).Select(b => new BranchViewModel
            {
                Id = b.Id,
                Name = b.Name, 
                EmailTemplateData =new EmailTemplateViewModel
                {
                    Subject=b.EmailTemplate.Subject,
                    Boddy=b.EmailTemplate.Body
                }
                
            }).ToList();
        }
         

    }
}
