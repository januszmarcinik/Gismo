using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Identity.Models.Manage
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}