using System.Web.Mvc;
using EmailTemplateteService;
using EmailTemplateWeb.Models;
using System.Collections.Generic;
using System.Linq;
using EmailTemplateWeb.Globals;
using System.Web;
using System;
using CKSource.FileSystem;

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
        public ActionResult Index(string type = null, int sug_lid = 0, int? branchId     = -1)
        {

            ViewBag.type = type;

            var emailsTemplates = new List<EmailTemplateViewModel>();
            var branches = new List<BranchViewModel>();
            switch (type)
            {
                case Constant.Branch:
                    emailsTemplates = GetEmailsTemplateForBranches();
                    break;
                case Constant.Campaign:
                    emailsTemplates = GetEmailsTemplateForCampaigns();
                    break;

                    

                case Constant.Event:

                    branches = GetBranches().ToList();
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
                    ViewBag.listItemsDD = GetBranchesDoNotHaveTemplate();
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


        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string url; // url to return
            string message; // message to display (optional)

            // here logic to upload image
            // and get file path of the image

           
            // will create http://localhost:1457/Content/Images/my_uploaded_image.jpg
            url = Request.Url.GetLeftPart(UriPartial.Authority) + "/Content/Images/CKEditpr/" +upload.FileName;



             var path = Path.Combine(Server.MapPath("~/")+ "Content/Images/CKEditpr");

            var a = Path.Combine(path, upload.FileName);
            upload.SaveAs(Path.Combine(path, upload.FileName)); ;

            // passing message success/failure
            message = "Image was saved correctly";

            // since it is an ajax request it requires this string
            string output = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\", \"" + message + "\");</script></body></html>";
            return Content(output);
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

        private List<BranchViewModel> GetBranches()
        {

            return _emailTemplateService.GetBranches().Select(b => new BranchViewModel
            {
                Id = b.branch_num,
                Name = b.name
            }).ToList();
        }

        private EmailTemplateInfo GetEmailTemplateById(int id)
        {
            return _emailTemplateService.GetById(id);
        }


        private IEnumerable<SelectListItem> GetBranchesDoNotHaveTemplate()
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
