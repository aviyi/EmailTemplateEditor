using System.Web.Mvc;
using EmailTemplateteService;
using EmailTemplateWeb.Models;
using System.Collections.Generic;
using System.Linq;
using EmailTemplateWeb.Globals;

namespace EmailTemplateWeb.Controllers
{
    [Authorize]
    public class EmailTemplateController : Controller
    {

        EmailTemplateService _emailTemplateService;
        public EmailTemplateController()
        {
            _emailTemplateService = new EmailTemplateService(new DataAccess());
        }
        public ActionResult Index(string type)
        {

            ViewBag.type = type;

            var emailsTemplates = new List<EmailTemplateViewModel>();
            switch (type)
            {
                case Constant.Branch:
                    emailsTemplates = GetEmailsTemplateForBranches();
                    break;
                case Constant.Campaign:
                    emailsTemplates = GetEmailsTemplateForCampaigns();
                    break;
            }


            return View(emailsTemplates);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var templateInfo = GetEmailTemplateById(id);
            if (templateInfo == null)
                return HttpNotFound();
            return View(ToEmailTemplateViewModel(templateInfo));

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _emailTemplateService.DeleteTemplate(id);
            return RedirectToAction("Index", new { type = Request.QueryString["type"] });
        }


        [HttpGet]
        public ActionResult Create(string type)
        {

            ViewBag.isEditMode = false;
            switch (type)
            {
                case Constant.Branch:
                    ViewBag.listItemsDD = GetBranches();
                    break;
                case Constant.Campaign:
                    ViewBag.listItemsDD = GetCampaign();
                    break;
            }

            return View();

        }


        [HttpPost]
        [ActionName("Create")]
        [ValidateInput(false)]
        public ActionResult CreateOrUpdate(EmailTemplateViewModel emailTemplateViewModel)
        {

            var type = Request.QueryString["type"];
            CreateOrUpdateEmailTemplate(emailTemplateViewModel, type);
            return RedirectToAction("Index", new { type = type });

        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ViewBag.isEditMode = true;
            var emailTemplate = _emailTemplateService.GetById(Id);
            if (emailTemplate == null)
                return HttpNotFound();
            return View("Create", ToEmailTemplateViewModel(emailTemplate));
        }


        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmation(EmailTemplateViewModel emailTemplateViewModel)
        {
            if (ModelState.IsValid)
            {
                var type = Request.QueryString["type"];
                return RedirectToAction("Index", new { type = type });
            }
            else
            {
                return View(emailTemplateViewModel);
            }
        }

        #region Prviate Functions
        private static EmailTemplateViewModel ToEmailTemplateViewModel(EmailTemplateInfo templateInfo)
        {
            return new EmailTemplateViewModel
            {
                Id = templateInfo.Id,
                Body = templateInfo.Body,
                Subject = templateInfo.Subject,
                BranchName = templateInfo.BranchInfo != null ? templateInfo.BranchInfo.Name : "",
                CampaignName = templateInfo.CampaignInfo != null ? templateInfo.CampaignInfo.Name : ""
            };
        }

        private EmailTemplateInfo GetEmailTemplateById(int id)
        {
            return _emailTemplateService.GetById(id);
        }


        private IEnumerable<SelectListItem> GetBranches()
        {
            return _emailTemplateService.GetBranchesDoNotHaveTemplate().Select(b => new SelectListItem { Text = b.Name, Value = b.Id.ToString() });
        }
        private IEnumerable<SelectListItem> GetCampaign()
        {
            return _emailTemplateService.GetCampaignsDoNotHaveTemplate().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
        }
        private List<EmailTemplateViewModel> GetEmailsTemplateForBranches()
        {
            return _emailTemplateService.GetAllForBranches().Select(e => new EmailTemplateViewModel { Body = e.Body, BranchName = e.BranchInfo.Name, Subject = e.Subject, Id = e.Id }).ToList();

        }
        private List<EmailTemplateViewModel> GetEmailsTemplateForCampaigns()
        {
            return _emailTemplateService.GetlAllForCampaigns().Select(e => new EmailTemplateViewModel { Body = e.Body, CampaignName = e.CampaignInfo.Name, Subject = e.Subject, Id = e.Id }).ToList();

        }

        private void CreateOrUpdateEmailTemplate(EmailTemplateViewModel emailTemplateViewModel, string type)
        {

            if (emailTemplateViewModel.Id == 0)
                Create(emailTemplateViewModel, type);

            else
                Update(emailTemplateViewModel);

        }

        private void Update(EmailTemplateViewModel emailTemplateViewModel)
        {
            var emailTemplateInfo = _emailTemplateService.GetById(emailTemplateViewModel.Id);
            emailTemplateInfo.Subject = emailTemplateViewModel.Subject;
            emailTemplateInfo.Body = emailTemplateViewModel.Body;
            _emailTemplateService.Edit(emailTemplateInfo);
        }

        private string Create(EmailTemplateViewModel emailTemplateViewModel, string type)
        {
            string selectedValue;
            short? branchId = null;
            int? campaignId = null;

            selectedValue = Request.Form["listItemsDD"].ToString();
            if (type == Constant.Branch)
                branchId = short.Parse(selectedValue);
            else
            campaignId = int.Parse(selectedValue);
            _emailTemplateService.Create(campaignId, branchId,
            emailTemplateViewModel.Subject, emailTemplateViewModel.Body);
            return selectedValue;
        }

        #endregion
    }
}
