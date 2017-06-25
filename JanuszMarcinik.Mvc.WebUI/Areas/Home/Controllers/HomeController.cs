using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Home.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View(MVC.Home.Home.Views.Index);
        }
    }
}