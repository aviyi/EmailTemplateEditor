using EmailTemplateSite.ViewModels;
using EmailTemplateteService;
using System.Collections.Generic;
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
        public bool AddedForBranch([FromBody]TemplateParamsViewModel templateParams)
        {
            return _emailTemplateService.AddTemplateForBranch(templateParams.BranchId, templateParams.Subject, templateParams.Body);
        }

        [HttpGet]
        public List<BranchViewModel>GetBranches(string termBranch)
        {
            return null;
        //    return _emailTemplateService.GetBranchesContainBranchName(termBranch).ToDescriptor();
        }


    }
}
