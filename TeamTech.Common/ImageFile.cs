using System.IO;
namespace TeamTech.Common
{
    public class ImageFile
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public byte[] Data
        {
            get { return File.ReadAllBytes(this.FullPath); }

            set { File.WriteAllBytes(this.FullPath, value); }
        }

        public string Extension { get; set; }

        public string DirectoryPath { get; set; }

        public string FullPath
        {
            get
            {
                return Path.Combine(this.ApplicationPath, this.RelativePath);
            }
        }

        /// <summary>
        /// Gets the relative path.
        /// </summary>
        public string RelativePath
        {
            get { return string.Format("{0}{1}{2}.{3}", DirectoryPath, this.Name, this.Id.ToString(), this.Extension); }
        }

        public string ApplicationPath { get; set; }

        /// <summary>
        /// Deletes the corresponding file.
        /// </summary>
        internal void DeleteData()
        {
            File.Delete(this.FullPath);
        }
    }
}
