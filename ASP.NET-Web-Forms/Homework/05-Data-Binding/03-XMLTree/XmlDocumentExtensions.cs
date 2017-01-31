using System.Text;
using System.Xml;

namespace _03_XMLTree
{
    public static class XmlDocumentExtensions
    {
        public static string Beautify(this XmlDocument doc)
        {
            var sb = new StringBuilder();
            var settings = new XmlWriterSettings
                           {
                               Indent = true,
                               IndentChars = "  ",
                               NewLineChars = "\r\n",
                               NewLineHandling = NewLineHandling.Replace
                           };

            using (var writer = XmlWriter.Create(sb, settings))
            {
                doc.Save(writer);
            }
            return sb.ToString();
        }
    }
}
