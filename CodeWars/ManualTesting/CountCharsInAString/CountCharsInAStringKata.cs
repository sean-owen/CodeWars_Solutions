using System;
using System.Collections.Generic;
using System.Text;

namespace KataSolutions.CountCharsInAString
{
    public class CountCharsInAStringKata
    {
        public static Dictionary<char, int> Count(string str)
        {
            var numCharsInStr = new Dictionary<char, int>();

            foreach(char letter in str)
            {
                if (numCharsInStr.ContainsKey(letter))
                {
                    numCharsInStr[letter]++;
                }
                else
                {
                    numCharsInStr.Add(letter, 1);
                }
            }

            return numCharsInStr;
        }
    }
}
