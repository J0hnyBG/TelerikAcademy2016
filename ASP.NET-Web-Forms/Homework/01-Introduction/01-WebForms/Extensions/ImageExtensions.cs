using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace _01_WebForms.Extensions
{
    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, format);
            return ms.ToArray();
        }
    }
}
