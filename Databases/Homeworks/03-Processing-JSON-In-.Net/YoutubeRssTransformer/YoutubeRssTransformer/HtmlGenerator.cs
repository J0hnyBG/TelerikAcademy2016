namespace YoutubeRssTransformer
{
    using System.Collections.Generic;
    using System.Text;

    using Models;

    public static class HtmlGenerator
    {
        private const string OpeningHtml = @"<!DOCTYPE html>
                                            <html>
                                            <head>
                                            <meta charset=""UTF-8"">
                                            <title>Telerik Academy's Latest Videos</title>
                                            </head>
                                            <body style=""text-align:center;"">";

        private const string ClosingHtml = @"</body></html>";

        public static string GenerateEmbeddedVideosPage(IEnumerable<Video> videos)
        {
            var result = new StringBuilder();
            result.AppendLine(OpeningHtml);

            foreach (var video in videos)
            {
               var escapedUrl = video.Url.Replace("watch?v=", "v/");
               var currentLine = $"<p><a href=\"{video.Url}\">{video.Title}</a></p>\n<iframe width=\"853\" height=\"480\" src=\"{escapedUrl}\" frameborder=\"0\" allowfullscreen></iframe><hr/>";
               result.AppendLine(currentLine);
            }
            result.AppendLine(ClosingHtml);

            return result.ToString();
        }
    }
}
