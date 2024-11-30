using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor.TextProcessor.TextFilter
{
    public class CharTFilter : IFilter
    {
        /// <summary>
        /// Filters out words that contain the letter 't' or 'T'
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Filter(string word)
        {
            if (string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word))
            {
                return false;
            }
            return !(word.Contains('t') || word.Contains('T'));
        }
    }
}
