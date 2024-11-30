using FileProcessor.TextProcessor.TextFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileProcessor.Services
{
    public class FileService : IFileService
    {
        private List<IFilter> _filters;

        public FileService(List<IFilter> filters)
        {
            _filters = filters;
        }
        public string processFilters(string filePath)
        {

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(message: $"The file path cannot be is empty or white spaces.", null);
            }
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The specified file does not exist.");
            }

            string text = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(message:$"Input file cannot be empty or only white spaces.", null);
            }
            text = Regex.Replace(text, "[^a-zA-Z \n\r\t]", "");

            var words = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var filter in _filters)
            {
                words = words.Where(word => filter.Filter(word)).ToArray();
            }
            return string.Join(", ", words);
        }
    }
}
