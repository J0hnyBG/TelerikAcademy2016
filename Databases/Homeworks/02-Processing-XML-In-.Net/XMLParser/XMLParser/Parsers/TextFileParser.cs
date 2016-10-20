namespace XMLParser.Parsers
{
    using System.IO;
    using System.Xml.Linq;

    public class TextFileParser
    {
        public XElement GetPeopleFromFileInXml(string uri)
        {
            var result = new XElement("people");
            using (var streamReader = new StreamReader(uri))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var splitLine = line.Split(';');
                    var personName = splitLine[0];
                    var personAddress = splitLine[1];
                    var personPhone = splitLine[2];

                    result.Add(new XElement(
                                   "person",
                                   new XElement("name", personName),
                                   new XElement("address", personAddress),
                                   new XElement("phone", personPhone)));
                }
            }

            return result;
        }
    }
}
