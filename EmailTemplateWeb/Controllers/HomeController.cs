using EmailTemplateteService;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EmailTemplateWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private EmailTemplateService _emailTemplateService;

        public HomeController()
        {
            _emailTemplateService = new EmailTemplateService(new DataAccess());
        }
        public ActionResult Index()
        {
            ViewBag.branchesDD = GetBranches();


            return View();
        }

        private IEnumerable<SelectListItem> GetBranches()
        {
            return _emailTemplateService.GetBranches().Select(b => new SelectListItem
            {
                Text = b.name,
                Value = b.branch_num.ToString()
            });
        }

    }
}