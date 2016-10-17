namespace XMLParser
{
    using System;
    using System.Xml.Xsl;

    using DirectoryStructure;

    using Parsers;

    public class Startup
    {
        private static readonly string Divider = new string('-', 80);
        private const string InputDirectory = "..\\..\\..\\Input\\";
        private const string OutputDirectory = "..\\..\\..\\Output\\";

        private static void Main()
        {
            var albumInputUri = InputDirectory + "albumcatalogue.xml";

            var extractor = new XmlCatalogueParser();

            //Task 2
            var artists = extractor.ExtractArtistsAndAlbumCountDom(albumInputUri);
            foreach(var artist in artists)
            {
                Write($"Artist: {artist.Key}, Album Count: {artist.Value}");
            }
            Write(Divider);

            //Task 3
            var xpathArtists = extractor.ExtractArtistsAndAlbumCountXPath(albumInputUri);
            foreach(var artist in xpathArtists)
            {
                Write($"Artist: {artist.Key}, Album Count: {artist.Value}");
            }
            Write(Divider);

            //Task 4
            var filteredDocument = extractor.GetAlbumsWhere(albumInputUri, "price>20");
            filteredDocument.Save(OutputDirectory + "albumcatalogue-filtered.xml");
            Write("Filtered albumcatalogue.xml where price>20 and saved to " + OutputDirectory + "albumcatalogue-filtered.xml");
            Write(Divider);
            
            //Task 5
            var allSongTitles = extractor.GetAllSongTitlesByXmlReader(albumInputUri);
            var songTitlesString = string.Join(" | ", allSongTitles);
            Write(songTitlesString);
            Write(Divider);

            //Task 6
            var allSongTitlesByLinq = extractor.GetAllSongTitlesByXDocumentAndLinq(albumInputUri);
            var songTitlesStringByLinq = string.Join(" | ", allSongTitlesByLinq);
            Write(songTitlesStringByLinq);
            Write(Divider);

            //Task 7
            var personExtractor = new TextFileParser();
            var peopleDoc = personExtractor.GetPeopleFromFileInXml(InputDirectory + "people.txt");
            peopleDoc.Save(OutputDirectory + "people.xml");
            Write("Extracted people and saved to " + OutputDirectory + "people.xml");
            Write(Divider);

            //Task 8
            extractor.ExtractAlbumAndArtistNames(albumInputUri, OutputDirectory + "albums.xml");
            Write("Extracted albums and artists and saved to " + OutputDirectory + "albums.xml");
            Write(Divider);

            //Task 9-10
            var generator = new DirectoryXmlStructureGenerator();
            var directoryDocument = generator.GenerateXmlStructure("..\\..\\..\\");
            directoryDocument.Save(OutputDirectory + "project-directory-info.xml");
            Write("Generated folder and file structure for current project and saved to " + OutputDirectory + "project-directory-info.xml");
            Write(Divider);

            //Task 11
            var endYear = DateTime.Now.Year - 5;
            var albums = extractor.GetAlbumsWhere(albumInputUri, $"year>{endYear}");
            albums.Save(OutputDirectory + "albums-older-than-5.xml");
            Write($"Filtered albumcatalogue.xml where year>{endYear} and saved to " + OutputDirectory + "albums-older-than-5.xml");
            Write(Divider);

            //Task 12 
            var oldAlbums = extractor.GetAlbumsOlderThanFiveYears(albumInputUri);
            oldAlbums.Save(OutputDirectory + "albums-older-than-5-linq.xml");
            Write($"Filtered albumcatalogue.xml where year>{endYear} with linq and saved to " + OutputDirectory + "albums-older-than-5-linq.xml");
            Write(Divider);

            //Task 13
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(InputDirectory + "albumcatalogue.xsl");
            xslt.Transform(albumInputUri, OutputDirectory + "albumcatalogue.html");
            Write("Transformed albumcatalogue.xml and saved to " + OutputDirectory + "albumcatalogue.html");
            Write(Divider);

        }

        private static void Write(string toWrite)
        {
            Console.WriteLine(toWrite);
        }
    }
}
