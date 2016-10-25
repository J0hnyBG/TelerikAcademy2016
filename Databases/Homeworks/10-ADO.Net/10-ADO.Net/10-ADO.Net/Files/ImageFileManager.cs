namespace _10_ADO.Net.Files
{
    using System;
    using System.Drawing;
    using System.IO;

    public class ImageFileManager
    {
        private ImageConverter _imageConverter;

        public ImageFileManager()
        {
            this.ImageConverter = new ImageConverter();
        }

        private ImageConverter ImageConverter
        {
            get { return this._imageConverter; }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this._imageConverter = value;
            }
        }

        public void WriteToDisk(string path,
                                    byte[] fileContents)
        {
            var fileNameInfo = new FileInfo(path);
            var directoryExists = Directory.Exists(fileNameInfo.DirectoryName);
            if (!directoryExists)
            {
                Directory.CreateDirectory(fileNameInfo.DirectoryName);
            }

            var image = (Bitmap)this.ImageConverter.ConvertFrom(fileContents);
            image.Save(path);
        }
    }
}
