namespace XMLParser.Readers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class XmlCatalogueReader
    {
        public IDictionary<string, int> ExtractArtistsAndAlbumCountDom(string uri)
        {
            var document = new XmlDocument();
            document.Load(uri);

            //Note: Why explicitly cast when you can use a Dictionary
            var artists = new Dictionary<string, int>();
            var rootElement = document.DocumentElement;
            if (rootElement == null)
            {
                return artists;
            }

            foreach (XmlNode element in rootElement)
            {
                var artistElement = element["artist"];
                if (artistElement == null)
                {
                    continue;
                }

                var artistName = artistElement.InnerXml;
                if (artists.ContainsKey(artistName))
                {
                    artists[artistName] += 1;
                }
                else
                {
                    artists.Add(artistName, 1);
                }
            }

            return artists;
        }

        public IDictionary<string, int> ExtractArtistsAndAlbumCountXPath(string uri)
        {
            var document = new XPathDocument(uri);

            var artists = new Dictionary<string, int>();
            var nav = document.CreateNavigator();

            const string xPathQuery = "/albumCatalogue/album/artist";
            var extracted = nav.Select(xPathQuery);

            while (extracted.MoveNext())
            {
                var artistName = extracted.Current.InnerXml;
                if (artists.ContainsKey(artistName))
                {
                    artists[artistName] += 1;
                }
                else
                {
                    artists.Add(artistName, 1);
                }
            }

            return artists;
        }

        public XmlDocument GetAlbumsWhere(string url, string condition)
        {
            var document = new XmlDocument();
            document.Load(url);

            var childNodes = document.SelectNodes($"/albumCatalogue/album[{condition}]");

            if (childNodes == null)
            {
                return document;
            }

            foreach (XmlElement node in childNodes)
            {
                node.ParentNode?.RemoveChild(node);
            }

            return document;
        }

        public XDocument GetAlbumsOlderThanFiveYears(string url)
        {
            var document = XDocument.Load(url);

            var childNodes = document.Descendants("album")
                .Where(x => (int)x.Element("year") >= DateTime.Now.Year - 5)
                .ToList();

            foreach (var node in childNodes)
            {
                node.Remove();
            }

            return document;
        }

        public IEnumerable<string> GetAllSongTitlesByXmlReader(string uri)
        {
            var songs = new List<string>();
            using (var reader = XmlReader.Create(uri))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType != XmlNodeType.Element) || (reader.Name != "title"))
                    {
                        continue;
                    }

                    var outp = reader.ReadElementString();
                    songs.Add(outp);
                }
            }

            return songs;
        }

        public IEnumerable<string> GetAllSongTitlesByXDocumentAndLinq(string uri)
        {
            var document = XDocument.Load(uri);

            var songs = from title in document.Descendants("title")
                        select title.Value;

            return songs;
        }

        public void ExtractAlbumAndArtistNames(string uri, string outputUri)
        {
            var settings = new XmlWriterSettings
                           {
                               Indent = true,
                               IndentChars = "\t"
                           };

            var writer = XmlWriter.Create(outputUri, settings);
            using (writer)
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("albumList");
                using (var reader = XmlReader.Create(uri))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element)
                            && (reader.Name == "album"))
                        {
                            writer.WriteStartElement("album");
                        }
                        else if ((reader.NodeType == XmlNodeType.Element)
                                 && (reader.Name == "name"))
                        {
                            writer.WriteElementString("albumName", reader.ReadElementContentAsString());
                        }
                        else if ((reader.NodeType == XmlNodeType.Element)
                                 && (reader.Name == "artist"))
                        {
                            writer.WriteElementString("artist", reader.ReadElementContentAsString());
                            writer.WriteEndElement();
                        }
                    }
                }

                writer.WriteEndDocument();
            }
        }
    }
}
