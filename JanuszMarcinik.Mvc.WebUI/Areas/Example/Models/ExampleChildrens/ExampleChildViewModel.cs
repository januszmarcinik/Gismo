using JanuszMarcinik.Mvc.DataSource;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleChildrens
{
    public class ExampleChildViewModel
    {
        public int Id { get; set; }

        [Grid(Order = 1)]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        public int ParentId { get; set; }
    }
}