using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataSolutions.DuplicateEncoder
{
    public class DuplicateEncoderKata
    {
        public static string DuplicateEncode(string word)
        {
            string convertedString = string.Empty;
            word = word.ToLower();
            Dictionary<char, int> countedLetters = word.GroupBy(letter => letter).ToDictionary(letter => letter.Key, letter => letter.Count());

            for (int i = 0; i < word.Length; i++)
            {
                char key = word[i];
                if(countedLetters[key] > 1)
                {
                    convertedString += ')';
                }
                else
                {
                    convertedString += '(';
                }
            }

            return convertedString;
        }
    }
}
