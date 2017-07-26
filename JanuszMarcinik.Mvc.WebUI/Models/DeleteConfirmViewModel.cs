using JanuszMarcinik.Mvc.SiteMap;

namespace JanuszMarcinik.Mvc.WebUI
{
    public class DeleteConfirmViewModel
    {
        public int Id { get; set; }
        public ActionMap ActionOnDelete { get; set; }
        public string ConfirmationText { get; set; }
    }
}