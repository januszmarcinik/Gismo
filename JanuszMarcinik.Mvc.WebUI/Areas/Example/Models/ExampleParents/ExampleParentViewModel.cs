using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using System;
using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents
{
    public class ExampleParentViewModel
    {
        [PrimaryKey]
        public int Id { get; set; }

        [DataSourceList(Order = 1)]
        [Display(Name = "Text")]
        public string Text { get; set; }

        [DataSourceList(Order = 2)]
        [Display(Name = "Długi text")]
        public string LongText { get; set; }
    }
}