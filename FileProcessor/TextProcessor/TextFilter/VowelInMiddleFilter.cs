using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor.TextProcessor.TextFilter
{
    public class VowelInMiddleFilter : IFilter
    {
        private readonly string _vowels = "aeiouAEIOU";

        /// <summary>
        /// Filters out words that have a vowel in the middle
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Filter(string word)
        {
            if (string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word))
            {
                return false;
            }

            int length = word.Length;
            if (length % 2 == 1) //Odd length
            {
                char middleChar = word[length / 2];
                return !_vowels.Contains(middleChar);
            }
            else
            {
                string middleTwoChars = word.Substring(length / 2 - 1, 2);
                return !middleTwoChars.Any(_vowels.Contains);
            }
        }
    }
}
