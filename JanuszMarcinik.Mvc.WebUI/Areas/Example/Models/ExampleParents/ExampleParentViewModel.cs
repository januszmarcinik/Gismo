using JanuszMarcinik.Mvc.DataSource;
using JanuszMarcinik.Mvc.Domain.Models.Media;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents
{
    public class ExampleParentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Text")]
        [Grid(Order = 2, DataType = GridDataType.Text)]
        public string Text { get; set; }

        [Display(Name = "Długi text")]
        [Grid(Order = 3, DataType = GridDataType.Text)]
        public string LongText { get; set; }

        [Grid(Order = 1, DataType = GridDataType.PhotoPath, DisplayName = "")]
        public string ThumbnailPath
        {
            get
            {
                if (this.Photo != null)
                {
                    return this.Photo.ThumbnailPath;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        [Display(Name = "Zdjęcie")]
        public Photo Photo { get; set; }

        [Display(Name = "Usuń zdjęcie")]
        public bool RemovePhoto { get; set; }

        [Display(Name = "Dodaj zdjęcie")]
        public HttpPostedFileBase Upload { get; set; }
    }
}