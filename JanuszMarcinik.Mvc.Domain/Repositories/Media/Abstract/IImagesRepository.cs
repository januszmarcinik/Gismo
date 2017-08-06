using JanuszMarcinik.Mvc.Domain.Models.Media;
using System.Web;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Media.Abstract
{
    public interface IImagesRepository
    {
        void Upload(Photo dbEntry, HttpPostedFileBase fileBase);
        void Remove(int id);
        void SaveChanges();
    }
}