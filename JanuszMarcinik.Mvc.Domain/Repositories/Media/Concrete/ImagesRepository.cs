using System;
using JanuszMarcinik.Mvc.Domain.Data;
using JanuszMarcinik.Mvc.Domain.Repositories.Media.Abstract;
using System.Web;
using System.IO;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Drawing;
using JanuszMarcinik.Mvc.Domain.Models.Media;
using System.Drawing.Imaging;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Media.Concrete
{
    public class ImagesRepository : IImagesRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private string _imagesPath = ConfigurationManager.AppSettings["ImagesPath"];

        #region Upload()
        public void Upload(Photo dbEntry, HttpPostedFileBase fileBase)
        {
            var fullDirectoryPath = Path.Combine(_imagesPath, dbEntry.DirectoryPath);
            if (!Directory.Exists(fullDirectoryPath))
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            dbEntry.FileExtension = Path.GetExtension(fileBase.FileName);

            var tempImagePath = Path.Combine(fullDirectoryPath, $"{dbEntry.FileName}-temp{dbEntry.FileExtension}");
            fileBase.SaveAs(tempImagePath);

            SaveResized(tempImagePath, Path.Combine(fullDirectoryPath, $"{dbEntry.FileName}{dbEntry.FileExtension}"), 800, 600);
            SaveResized(tempImagePath, Path.Combine(fullDirectoryPath, $"{dbEntry.FileName}-thumb{dbEntry.FileExtension}"), 150, 150);

            File.Delete(tempImagePath);

            this.context.Create(dbEntry);
        }
        #endregion

        #region Remove()
        public void Remove(int id)
        {
            var image = this.context.Get<Photo>(id);

            File.Delete(Path.Combine(_imagesPath, image.Path));
            File.Delete(Path.Combine(_imagesPath, image.ThumbnailPath));

            this.context.Delete(image);
        }
        #endregion

        #region SaveChanges()
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
        #endregion

        #region SaveResized()
        private void SaveResized(string sourcePath, string targetPath, int maxWidth, int maxHeight)
        {
            using (var image = Image.FromFile(sourcePath))
            {
                float ratioX = (float)maxWidth / (float)image.Width;
                float ratioY = (float)maxHeight / (float)image.Height;
                float ratio = Math.Min(ratioX, ratioY);

                int newWidth = (int)(image.Width * ratio);
                int newHeight = (int)(image.Height * ratio);

                var resizedImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

                using (Graphics graphics = Graphics.FromImage(resizedImage))
                {
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                }

                resizedImage.Save(targetPath);
            }
        }
        #endregion
    }
}