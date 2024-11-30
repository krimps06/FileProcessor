using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor.TextProcessor.TextFilter
{
    public class LengthLessThanThreeFilter : IFilter
    {
        /// <summary>
        /// Filters out words that are less than 3 characters long
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Filter(string word)
        {
            if(string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word))
            {
                return false;
            }
            return word.Length >= 3;
        }
    }
}
