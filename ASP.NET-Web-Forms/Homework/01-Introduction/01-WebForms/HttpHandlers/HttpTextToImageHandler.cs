using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

using Ninject;
using Ninject.Web;

using _01_WebForms.Extensions;
using _01_WebForms.Services;

namespace _01_WebForms.HttpHandlers
{
    public class HttpTextToImageHandler : HttpHandlerBase
    {
        [Inject]
        public ITextToImgService TextToImg { get; set; }

        [Inject]
        public IFileNameExtractorService FileNameExtractor { get; set; }

        protected override void DoProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            var filePath = request.Url.LocalPath;
            var fileName = this.FileNameExtractor.ExtractFileNameFromLocalPath(filePath);

            var font = new Font(FontFamily.GenericMonospace, 75);
            var img = this.TextToImg.DrawText(fileName, font, Color.AliceBlue, Color.RoyalBlue)
                                    .ToByteArray(ImageFormat.Png);

            response.ContentType = @"image\png";
            response.BinaryWrite(img);
        }

        public override bool IsReusable
        {
            get { return true; }
        }
    }
}
