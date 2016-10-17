namespace YoutubeRssTransformer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml;

    using Models;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using Formatting = Newtonsoft.Json.Formatting;

    internal class Startup
    {
        private const string TelerikYoutubeRssUrl =
            "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";

        private const string LocalRssFilePath = "..\\..\\telerik-rss.xml";
        private const string HtmlFilePath = "..\\..\\telerik-latest.html";

        private static void Main()
        {
            var document = PrepareRssFeed();

            var rssJsonText = JsonConvert.SerializeXmlNode(document, Formatting.Indented);
            var parsedRss = JObject.Parse(rssJsonText);
            var videoCollection = (JArray)parsedRss["feed"]["entry"];

            var allVideoTitles = videoCollection.Select(x =>  x["title"]);
            var allTitlesString = string.Join("\n", allVideoTitles);
            Console.WriteLine(allTitlesString);

            var allVideos = videoCollection.Select(x => new Video(){ Title = (string)x["title"], Url = (string)x["link"]["@href"] });

            var html = HtmlGenerator.GenerateEmbeddedVideosPage(allVideos);

            File.WriteAllText(HtmlFilePath, html);

            Console.WriteLine("**********************************************************");
            Console.WriteLine("Generated HTML and saved to " + HtmlFilePath);
        }

        private static XmlDocument PrepareRssFeed()
        {
            var webClient = new WebClient();
            webClient.DownloadFile(TelerikYoutubeRssUrl, LocalRssFilePath);
            var document = new XmlDocument();
            document.Load(LocalRssFilePath);

            return document;
        }
    }
}
