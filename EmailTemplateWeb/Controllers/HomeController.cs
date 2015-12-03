using System.Web.Mvc;

namespace EmailTemplateWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
         
 
    }
}