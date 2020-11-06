using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataSolutions.WhereMyAnagramsAt
{
    public class WmaaKata
    {
        public static List<string> Anagrams(string word, List<string> words)
        {
            List<string> anagramList = new List<string>();
            string wordArray = string.Concat(word.OrderBy(c => c));

            foreach (string entry in words)
            {
                string orderedItem = string.Concat(entry.OrderBy(c => c));
                if (orderedItem.Equals(wordArray))
                {
                    anagramList.Add(entry);
                }
            }
            return anagramList;
        }
    }
}
