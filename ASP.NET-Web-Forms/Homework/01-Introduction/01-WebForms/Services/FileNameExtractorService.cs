using System;

namespace _01_WebForms.Services
{
    public class FileNameExtractorService : IFileNameExtractorService
    {
        public string ExtractFileNameFromLocalPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Input string cannot be null or empty!");
            }

            var result = string.Empty;
            result = path.Split('.')[0].Replace("/", "");
            return result;
        }
    }
}