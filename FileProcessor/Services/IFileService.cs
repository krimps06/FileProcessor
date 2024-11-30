using FileProcessor.TextProcessor.TextFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor.Services
{
    public interface IFileService
    {
        string processFilters(string filePath);
    }
}
