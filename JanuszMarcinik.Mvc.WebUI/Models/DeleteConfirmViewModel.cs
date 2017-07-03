using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Models
{
    public class DeleteConfirmViewModel
    {
        public int Id { get; set; }
        public ActionResult ActionOnDelete { get; set; }
        public string ConfirmationText { get; set; }
    }
}