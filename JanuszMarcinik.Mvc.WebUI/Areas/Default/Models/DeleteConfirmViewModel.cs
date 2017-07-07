using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Default.Models
{
    public class DeleteConfirmViewModel
    {
        public int Id { get; set; }
        public ActionResult ActionOnDelete { get; set; }
        public string ConfirmationText { get; set; }
    }
}