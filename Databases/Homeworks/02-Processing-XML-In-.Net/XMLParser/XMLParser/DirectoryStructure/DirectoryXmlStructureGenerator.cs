namespace XMLParser.DirectoryStructure
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class DirectoryXmlStructureGenerator
    {
        public XElement GenerateXmlStructure(string directoryPath)
        {
            var dirInfo = new DirectoryInfo(directoryPath);
            var result = this.WalkDirectoryTree(dirInfo);
            return result;
        }

        private XElement WalkDirectoryTree(DirectoryInfo root)
        {
            var directoryElement = new XElement("dir", new XAttribute("name", root.Name));

            var files = root.GetFiles("*.*");
            foreach (FileInfo fileInfo in files)
            {
                var fileExtension = fileInfo.Name
                                            .Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Last();

                directoryElement.Add(new XElement(
                                         "file",
                                         new XAttribute("name", fileInfo.Name),
                                         new XAttribute("type", fileExtension)));
            }

            var subDirs = root.GetDirectories();
            foreach (DirectoryInfo dirInfo in subDirs)
            {
                directoryElement.Add(this.WalkDirectoryTree(dirInfo));
            }

            return directoryElement;
        }
    }
}
