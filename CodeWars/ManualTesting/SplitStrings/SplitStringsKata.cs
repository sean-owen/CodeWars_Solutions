using System;
using System.Collections.Generic;
using System.Text;

namespace KataSolutions.SplitStrings
{
    public class SplitStringsKata
    {
        public static string[] Solution(string str)
        {
            List<string> charPairs = new List<string>();

            string twoChars = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                twoChars += str[i];

                int isEven = (i + 1) % 2;
                if(isEven == 0)
                {
                    charPairs.Add(twoChars);
                    twoChars = string.Empty;
                }

                if (i == (str.Length - 1) && (isEven != 0))
                {
                    twoChars += "_";
                    charPairs.Add(twoChars);
                    twoChars = string.Empty;
                }
            }
            return charPairs.ToArray();
        }
    }
}
