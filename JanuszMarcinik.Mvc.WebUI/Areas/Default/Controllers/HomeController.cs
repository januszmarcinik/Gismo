using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Default.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View(MVC.Default.Home.Views.Index);
        }
    }
}