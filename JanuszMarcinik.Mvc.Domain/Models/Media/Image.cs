using JanuszMarcinik.Mvc.Domain.Data;
using System.Data.Entity.ModelConfiguration;
using System.IO;

namespace JanuszMarcinik.Mvc.Domain.Models.Media
{
    public class Photo : Entity
    {
        public int ObjectId { get; set; }
        public string ObjectTypeName { get; set; }
        public string Title { get; set; }
        public string DirectoryPath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }

        public string ThumbnailPath
        {
            get { return System.IO.Path.Combine(this.DirectoryPath, $"{this.FileName}-thumb{this.FileExtension}").Replace("\\", "/"); }
        }

        public string Path
        {
            get { return System.IO.Path.Combine(this.DirectoryPath, $"{this.FileName}{this.FileExtension}").Replace("\\", "/"); }
        }
    }

    internal class PhotoMapping : EntityTypeConfiguration<Photo>
    {
        public PhotoMapping()
        {
            this.ToTable("Photos", DbSchemas.Media);
        }
    }
}