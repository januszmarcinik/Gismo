using JanuszMarcinik.Mvc.DataSource;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents
{
    public class ExampleParentViewModel
    {
        public int Id { get; set; }

        [Grid(Order = 1)]
        [Display(Name = "Text")]
        public string Text { get; set; }

        [Grid(Order = 2)]
        [Display(Name = "Długi text")]
        public string LongText { get; set; }
    }
}